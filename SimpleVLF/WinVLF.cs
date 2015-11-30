using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Antiufo.Controls;
using MathNet.Numerics.LinearAlgebra;
using OxyPlot.Series;
using VLFLib;
using VLFLib.Data;
using VLFLib.Gridding;
using VLFLib.Processing;

namespace WinVLF
{
    public partial class WinVLF : Form
    {
        public static int Count;
        private static FileInfo _currentFile;

        public WinVLF()
        {
            InitializeComponent();
            _currentFile = new FileInfo(Application.StartupPath + "New Project.vlf");
        }

        private void SVLF_Load(object sender, EventArgs e)
        {
            tsToolBar.Renderer = Windows7Renderer.Instance;
            menuStrip1.Renderer = Windows7Renderer.Instance;
        }

        private void tsAddData_Click(object sender, EventArgs e)
        {
            var dlg = importRawDialog.ShowDialog();
            if (dlg != DialogResult.OK) return;

            var errcount = 0;

            foreach (var t in importRawDialog.FileNames)
            {
                TiltData input = null;
                try
                {
                    input = VLFDataReader.Read(t);
                }
                catch (Exception)
                {
                    errcount++;
                }
                finally
                {
                    if (input != null)
                    {
                        var safename = Path.GetFileNameWithoutExtension(t);
                        var newname = FindUniqeName(safename, treeViewMain.Nodes[0]);

                        AddNode(newname, treeViewMain.Nodes[0], input);

                        var form2 = new ChartPlot(input.Title, input)
                        {
                            MdiParent = this
                        };
                        form2.Show();
                    }
                }
            }

            if (errcount > 0)
            {
                MessageBox.Show(
                    $"The file(s) you are trying to import encountered an error.{Environment.NewLine}[Failed: {errcount} files, Success: {importRawDialog.FileNames.Length - errcount} files]",
                    @"Import Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddPlot(TreeNode node)
        {
            ChartPlot form2;
            // DO switch based on the root node index
            switch (node.Parent.Index)
            {
                case 0:
                    var data = node.Tag as TiltData;
                    if (data == null) return;
                    form2 = new ChartPlot(data.Title, data)
                    {
                        MdiParent = this
                    };

                    form2.Show();
                    break;
                case 1:
                    var fdata = node.Tag as FraserData;
                    if (fdata == null) return;
                    form2 = new ChartPlot(fdata.Title, fdata)
                    {
                        MdiParent = this
                    };

                    form2.Show();
                    break;
                case 2:
                    var kh = node.Tag as KarousHjeltData;
                    if (kh != null && kh.RawLength > 150)
                    {
                        MessageBox.Show(
                            @"Due to the limitation of gridding implementation in this version, the filtered result could not be shown. However, you can still export the result into an external file.",
                            @"Data Too Large To Grid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    StartGriddingWorker(new Surface2D(kh));
                    break;
                case 3:
                    var surfdata = node.Tag as Surface2D;
                    StartGriddingWorker(surfdata);
                    break;
            }
        }

        private void tsPlotChart_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewMain.SelectedNode;
            var parent = selectedNode.Parent;
            if (parent == null)
            {
                MessageBox.Show(@"Please select an object to plot", @"Nothing to plot", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            AddPlot(selectedNode);
        }

        private void tsInterpolate_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewMain.SelectedNode;

            var data = selectedNode.Tag as TiltData;
            if (data == null) return;
            var spacing = Convert.ToSingle(Math.Floor(data.Spacing));
            if (InputPrompt.InputNumberBox("Cubic Spline Interpolation", "Enter the new spacing", ref spacing) !=
                DialogResult.OK)
                return;

            var npt = Convert.ToInt32(((data.Distances.Max() - data.Distances.Min())/spacing) + 1);
            if (
                InputPrompt.InputNumberBox("Cubic Spline Interpolation", "Enter the new npts (number of points).",
                    ref npt) != DialogResult.OK)
                return;

            if ((data.Distances.Min() + ((npt - 1)*spacing) > data.Distances.Max()))
            {
                var dlg =
                    MessageBox.Show(@"The new interpolated max distances will exceed the original max distances." +
                                    $"{Environment.NewLine}" +
                                    $"{Environment.NewLine}Original: {data.Distances.Max()} m, Interpolated: {data.Distances.Min() + ((npt - 1)*spacing)} m." +
                                    $"{Environment.NewLine}" +
                                    $"{Environment.NewLine}Do you want to continue?", @"Exceed Original Max Distances",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Debug.WriteLine((data.Distances.Min() + (npt*spacing)));
                if (dlg == DialogResult.No) return;
            }


            var newname = FindUniqeName($"{selectedNode.Name}_Interpolated", treeViewMain.Nodes["NodeTilt"]);
            if (InputPrompt.InputStringBox("Cubic Spline Interpolation", "Enter a name.", ref newname) !=
                DialogResult.OK)
                return;

            var tiltData = VlfInterpolation.CubicSplineNatural(data, Convert.ToSingle(spacing), npt);
            tiltData.Rename(newname);

            AddNode(newname, treeViewMain.Nodes["NodeTilt"], tiltData);

            var form2 = new ChartPlot(newname, tiltData)
            {
                MdiParent = this
            };
            form2.Show();
        }

        private void tsbMovAvg_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewMain.SelectedNode;
            var parent = treeViewMain.Nodes["NodeTilt"];

            var order = 3;
            if (InputPrompt.InputNumberBox("Moving Average Filter", "Filter Order", ref order) != DialogResult.OK)
                return;


            var data = selectedNode.Tag as TiltData;
            if (data != null && ((Math.Abs(order)) <= 1 || order > data.Npts))
            {
                MessageBox.Show(@"Invalid filter order.", @"Error");
                return;
            }

            if (data == null) return;
            var newname = FindUniqeName($"{selectedNode.Name}_MovAvg Order {Convert.ToInt32(order)}", parent);
            if (InputPrompt.InputStringBox("Moving Average Filter", "Enter a name.", ref newname) != DialogResult.OK)
                return;

            var smooth = VlfFilter.MovingAverage(data, Convert.ToInt32(order));
            smooth.Rename(newname);

            AddNode(newname, parent, smooth);

            var form2 = new ChartPlot(newname, smooth)
            {
                MdiParent = this
            };
            form2.Show();
        }

        private void tsFraserFilter_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewMain.SelectedNode;

            var tiltData = selectedNode.Tag as TiltData;
            if (tiltData == null) return;
            if (tiltData.Npts < 4)
            {
                MessageBox.Show(@"There should be minimum of 4 data for this filter to work.");
                return;
            }

            var uniqeName = FindUniqeName(selectedNode.Name, treeViewMain.Nodes["NodeFraser"]);
            if (InputPrompt.InputStringBox("Fraser Filter", "Enter a name.", ref uniqeName) != DialogResult.OK)
                return;

            // Do Fraser Filtering
            var fraser = VlfFilter.Fraser(tiltData);
            fraser.Rename(uniqeName);

            AddNode(uniqeName, treeViewMain.Nodes["NodeFraser"], fraser);

            // Plot the result
            var form2 = new ChartPlot(uniqeName, fraser) {MdiParent = this};
            form2.Show();
        }

        private void tsKarousHjelt_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewMain.SelectedNode;

            var tiltData = selectedNode.Tag as TiltData;
            if (tiltData == null) return;
            if (tiltData.Npts < 6)
            {
                MessageBox.Show(@"There should be minimum of 7 data for this filter to work.");
                return;
            }

            var uniqeName = FindUniqeName(selectedNode.Name, treeViewMain.Nodes["NodeKH"]);
            if (InputPrompt.InputStringBox("Karous Hjelt-Filter", "Enter a name.", ref uniqeName) != DialogResult.OK)
                return;

            var skin = 0f;
            if (
                InputPrompt.InputNumberBox("Karous Hjelt-Filter",
                    $"Skin depth normalization. Enter 0 to ignore skin depth", ref skin) != DialogResult.OK)
                return;

            var kh = VlfFilter.KarousHjelt(tiltData, skin);
            kh.Rename(uniqeName);

            AddNode(uniqeName, treeViewMain.Nodes["NodeKH"], kh);

            if (kh.RawLength > 150)
            {
                MessageBox.Show(
                    @"Due to the limitation of gridding implementation in this version, the pseudosection could not be shown. However, you can still export the result into an external file.",
                    @"Data Too Large To Grid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            StartGriddingWorker(new Surface2D(kh));
        }

        private void maximizeAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window state to Maximized
            foreach (var chform in charr)
                chform.WindowState = FormWindowState.Maximized;
        }

        private void minimizeAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window state to Minimized
            foreach (var chform in charr)
                chform.WindowState = FormWindowState.Minimized;
        }

        private void tileHorizontallyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window state to Normal
            foreach (var chform in charr)
                chform.WindowState = FormWindowState.Normal;

            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window state to Normal
            foreach (var chform in charr)
                chform.WindowState = FormWindowState.Normal;

            LayoutMdi(MdiLayout.TileVertical);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window to close
            foreach (var chform in charr)
                chform.Close();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            var charr = MdiChildren;

            //for each child form set the window state to Normal
            foreach (var chform in charr)
                chform.WindowState = FormWindowState.Normal;

            LayoutMdi(MdiLayout.Cascade);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void tsmDelete_Click(object sender, EventArgs e)
        {
            treeViewMain.SelectedNode.Remove();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProjectNow();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsNow();
        }

        private void SaveAsNow()
        {
            var dlg = saveProjectDialog.ShowDialog();
            if (dlg != DialogResult.OK) return;
            var projectName = Path.GetFileNameWithoutExtension(saveProjectDialog.FileName);
            VlfProjectHandler.Save(SaveProject(projectName), saveProjectDialog.FileName);
            _currentFile = new FileInfo(saveProjectDialog.FileName);
            Text = $"WinVLF - [{_currentFile.Name}]";
            saveProjectDialog.FileName = string.Empty;
            tsStatusLabel.Text = string.Empty;
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveask = AskIfSaveFirst("opening another project");

            switch (saveask)
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.OK:
                    SaveProjectNow();
                    break;
                case DialogResult.No:
                case DialogResult.Abort:
                    break;
            }
            openProjectDialog.FileName = string.Empty;
            var dlg = openProjectDialog.ShowDialog();
            if (dlg != DialogResult.OK) return;
            LoadProject(VlfProjectHandler.Read(openProjectDialog.FileName));
            _currentFile = new FileInfo(openProjectDialog.FileName);
            tsStatusLabel.Text = string.Empty;
            treeViewMain.ExpandAll();
        }

        private void SVLF_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dlg = AskIfSaveFirst("exit");

            switch (dlg)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.OK:
                    SaveProjectNow();
                    break;
                case DialogResult.No:
                case DialogResult.Abort:
                    break;
            }
        }

        private void closeStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = AskIfSaveFirst("closing this project");

            switch (dlg)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.Yes:
                    SaveProjectNow();
                    break;
                case DialogResult.No:
                case DialogResult.Abort:
                    CloseProject();
                    break;
            }
        }

        private void krigingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var surface2D = e.Argument as Surface2D;
            if (surface2D == null)
            {
                e.Cancel = true;
                return;
            }

            var inputPoints = Matrix<float>.Build.DenseOfColumnArrays(surface2D.XValues, surface2D.YValues);
            var valueVector = Vector<float>.Build.DenseOfArray(surface2D.ZValues);
            var vgram = new Powvargram(inputPoints, valueVector);
            var krig = new Kriging(inputPoints, valueVector, vgram);

            var xmin = surface2D.XValues.Min();
            var ymin = surface2D.YValues.Min();

            // Create the heatmap series
            var surfMap = new HeatMapSeries
            {
                X0 = surface2D.XValues.Min(),
                X1 = surface2D.XValues.Max(),
                Y0 = surface2D.YValues.Min(),
                Y1 = surface2D.YValues.Max(),
                Data = new double[surface2D.Nx, surface2D.Ny],
                Interpolate = false,
                CoordinateDefinition = HeatMapCoordinateDefinition.Edge
            };

            var progress = 0;

            for (var i = 0; i < surface2D.Ny; i++)
            {
                for (var j = 0; j < surface2D.Nx; j++)
                {
                    progress++;
                    krigingWorker.ReportProgress((progress*100)/(surface2D.Nx*surface2D.Ny));
                    var point2Interpolate =
                        Vector<float>.Build.DenseOfArray(new[] {xmin + (j*surface2D.Dx), ymin + (i*surface2D.Dy)});
                    surfMap.Data[j, i] = krig.Interpolate(point2Interpolate);
                }
            }

            var result = new Tuple<HeatMapSeries, Surface2D>(surfMap, surface2D);
            e.Result = result;
        }

        private void krigingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = e.Result as Tuple<HeatMapSeries, Surface2D>;
            if (result == null || e.Cancelled) return;

            var form2 = new ChartPlot(result.Item1, result.Item2)
            {
                MdiParent = this
            };

            form2.Show();
            tsStatusLabel.Text = string.Empty;
            krigingProgressBar.Visible = false;
            krigingProgressBar.Value = 0;
        }

        private void krigingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            krigingProgressBar.Value = e.ProgressPercentage;
        }

        private void reverseSignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewMain.SelectedNode;
            var parent = treeViewMain.Nodes["NodeTilt"];

            var original = selectedNode.Tag as TiltData;
            if (original == null) return;
            var tilt = original.Copy();

            var uniqeName = FindUniqeName(selectedNode.Name + "_reversed", treeViewMain.Nodes["NodeTilt"]);
            if (InputPrompt.InputStringBox("Reverse Sign", "Enter a name.", ref uniqeName) != DialogResult.OK)
                return;
            tilt.Rename(uniqeName);
            tilt.ReverseSign();
            AddNode(uniqeName, parent, tilt);
            var form2 = new ChartPlot(tilt.Title, tilt) {MdiParent = this};
            form2.Show();
        }

        private void flipDistanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewMain.SelectedNode;
            var parent = treeViewMain.Nodes["NodeTilt"];

            var original = selectedNode.Tag as TiltData;
            if (original == null) return;
            var tilt = original.Copy();
            var uniqeName = FindUniqeName(selectedNode.Name + "_flipped", treeViewMain.Nodes["NodeTilt"]);
            tilt.Rename(uniqeName);
            if (InputPrompt.InputStringBox("Flip Distance", "Enter a name.", ref uniqeName) != DialogResult.OK)
                return;

            tilt.FlipDistance();
            AddNode(uniqeName, parent, tilt);
            var form2 = new ChartPlot(tilt.Title, tilt) {MdiParent = this};
            form2.Show();
        }

        private void flipAndReverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewMain.SelectedNode;
            var parent = treeViewMain.Nodes["NodeTilt"];

            var original = selectedNode.Tag as TiltData;
            if (original == null) return;
            var tilt = original.Copy();
            var uniqeName = FindUniqeName(selectedNode.Name + "_flippedreversed", treeViewMain.Nodes["NodeTilt"]);
            if (InputPrompt.InputStringBox("Flip and Reverse", "Enter a name.", ref uniqeName) != DialogResult.OK)
                return;

            tilt.Rename(uniqeName);
            tilt.FlipThenReverse();
            AddNode(uniqeName, parent, tilt);
            var form2 = new ChartPlot(tilt.Title, tilt) {MdiParent = this};
            form2.Show();
        }

        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                propertyGrid1.SelectedObject = null;
                SetButtonsEnable(false);
                return;
            }
            SetButtonsEnable(e.Node.Tag.GetType() == typeof (TiltData));
            propertyGrid1.SelectedObject = e.Node.Tag;
        }

        private void SetButtonsEnable(bool enable)
        {
            tsProcessing.Enabled = enable;
            tsInterpolate.Enabled = enable;
            tsKarousHjelt.Enabled = enable;
            tsFraserFilter.Enabled = enable;
            tsbMovAvg.Enabled = enable;
        }

        private void treeViewMain_KeyDown(object sender, KeyEventArgs e)
        {
            var topNode = treeViewMain.SelectedNode;
            
            while (topNode.Parent != null)
            {
                topNode = topNode.Parent;
            }

            if (treeViewMain.SelectedNode == topNode) return;

            switch (e.KeyCode)
            {
                case Keys.Delete:
                    treeViewMain.SelectedNode.Remove();
                    break;

                case Keys.F2:
                    treeViewMain.SelectedNode.BeginEdit();
                    break;
            }
        }

        private void treeViewMain_MouseUp(object sender, MouseEventArgs e)
        {
            // Check if the click is a right mouse
            if (e.Button != MouseButtons.Right) return;
            // Get the coordinate of the click
            var p = new Point(e.X, e.Y);

            // Get the node on p coordinate
            var node = treeViewMain.GetNodeAt(p);
            // If it is null, get out
            if (node == null) return;

            // If it is not check if it is the root node
            // If it is root node, then get out
            treeViewMain.SelectedNode = node;
            if (node.Level == 0) return;

            // If it is not, show the context menu
            cmTreeNode.Show(treeViewMain, p);
        }

        private void tsmPlot_Click(object sender, EventArgs e)
        {
            AddPlot(treeViewMain.SelectedNode);
        }

        private void tsmExport_Click(object sender, EventArgs e)
        {
            var vlfdata = treeViewMain.SelectedNode.Tag as VLFBasicData;
            if (vlfdata == null) return;
            switch (treeViewMain.SelectedNode.Parent.Index)
            {
                case 0:
                    exportFileDialog.FileName = $"{vlfdata.Title}_tilt";
                    break;
                case 1:
                    exportFileDialog.FileName = $"{vlfdata.Title}_fraser";
                    break;
                case 2:
                    exportFileDialog.FileName = $"{vlfdata.Title}_kh";
                    break;
            }

            var dlg = exportFileDialog.ShowDialog();
            if (dlg != DialogResult.OK) return;
            vlfdata.ExportToFile(exportFileDialog.FileName);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var box = new AboutBox1();
            box.ShowDialog();
        }

        private void usingFraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nodes =
                (from TreeNode node in treeViewMain.Nodes["NodeTilt"].Nodes select (TreeNode) node.Clone()).ToList();
            var form2 = new TreeInput(nodes);
            var dlg = form2.ShowDialog();
            if (dlg != DialogResult.OK) return;

            var nodeName = "Untitled";
            if (InputPrompt.InputStringBox("2D Surface", "Enter a name.", ref nodeName) != DialogResult.OK)
                return;

            // Collect all tiltdata from treeview and apply filter fraser each and gather them in list
            IList<TiltData> gather =
                (from TreeNode node in form2.treeView1.Nodes where node.Checked select node.Tag as TiltData).ToList();

            //TODO: finish this 2D Surfacing
            var surf2D = new Surface2D(gather, Surface2D.FilterType.Fraser)
            {
                Title = nodeName,
                XAxisTitle = "Easting",
                YAxisTitle = "Northing",
                XUnit = "m",
                YUnit = "m"
            };

            nodeName = FindUniqeName(nodeName, treeViewMain.Nodes["Node2DSurface"]);
            StartGriddingWorker(surf2D);
            AddNode(nodeName, treeViewMain.Nodes["Node2DSurface"], surf2D);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewMain.SelectedNode.BeginEdit();
        }
    }
}