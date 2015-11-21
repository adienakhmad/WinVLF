using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Antiufo.Controls;
using MathNet.Numerics.LinearAlgebra;
using OxyPlot;
using OxyPlot.Series;
using VLFLib.Data;
using VLFLib.Gridding;
using VLFLib.Processing;

namespace SimpleVLF
{
    public partial class SVLF : Form
    {
        public static int Count;
        private static FileInfo _currentFile;

        public SVLF()
        {
            InitializeComponent();
            _currentFile = new FileInfo(Application.StartupPath + string.Empty);
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
            TiltData input;

            try
            {
                input = VLFDataReader.Read(importRawDialog.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show(@"An error has occured on your file. Please check your file.");
                return;
            }

            var newname = FindUniqeName(input.Name, listViewRaw);

            var item = new ListViewItem {Text = newname, Name = newname};
            item.SubItems.Add(input.Npts.ToString());
            item.SubItems.Add(input.Spacing.ToString(CultureInfo.InvariantCulture));
            item.Tag = input;
            if (!input.IsAscending) item.BackColor = Color.Orange;
            listViewRaw.Items.Add(item);

            var form2 = new ChartPlot(item.Name, input)
            {
                MdiParent = this
            };
            form2.Show();
        }

        private void tsPlotChart_Click(object sender, EventArgs e)
        {
            if (listViewRaw.Focused)
            {
                if (listViewRaw.SelectedItems.Count == 0)
                {
                    MessageBox.Show(@"You have not selected any data.", @"No Data", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    return;
                }

                var selected = listViewRaw.SelectedItems[0];

                var form2 = new ChartPlot(selected.Name, selected.Tag as TiltData)
                {
                    MdiParent = this
                };

                form2.Show();
            }

            else if (listViewFraser.Focused)
            {
                if (listViewFraser.SelectedItems.Count == 0)
                {
                    MessageBox.Show(@"You have not selected any data.", @"No Data", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    return;
                }

                var selected = listViewFraser.SelectedItems[0];

                var form2 = new ChartPlot(selected.Name, selected.Tag as FraserData)
                {
                    MdiParent = this
                };

                form2.Show();
            }

            else if (listViewKH.Focused)
            {
                if (listViewKH.SelectedItems.Count == 0)
                {
                    MessageBox.Show(@"You have not selected any data.", @"No Data", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    return;
                }
                var selected = listViewKH.SelectedItems[0];
                tsStatusLabel.Text = @"Building grid..";
                krigingProgressBar.Visible = true;
                krigingWorker.RunWorkerAsync(selected.Tag as KarousHjeltData);
            }

            else
            {
                MessageBox.Show(@"There is nothing to plot");
            }
        }

        private void tsbMovAvg_Click(object sender, EventArgs e)
        {
            if (!listViewRaw.Focused || listViewRaw.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"You have not selected any tilt data.", @"No Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return;
            }

            var order = 3;
            if (InputPrompt.InputNumberBox("Moving Average Filter", "Filter Order", ref order) != DialogResult.OK)
                return;


            var data = listViewRaw.SelectedItems[0].Tag as TiltData;
            if (data != null && ((Math.Abs(order)) <= 1 || order > data.Npts))
            {
                MessageBox.Show(@"Invalid filter order.", @"Error");
                return;
            }

            if (data == null) return;
            var newname = FindUniqeName($"{data.Name}_MovAvg Order {Convert.ToInt32(order)}", listViewRaw);
            if (InputPrompt.InputStringBox("Moving Average Filter", "Enter a name.", ref newname) != DialogResult.OK)
                return;

            var smooth = VlfFilter.MovingAverage(data, Convert.ToInt32(order));
            smooth.Rename(newname);

            var item = new ListViewItem {Text = newname, Name = newname};
            item.SubItems.Add(smooth.Npts.ToString());
            item.SubItems.Add(smooth.Spacing.ToString(CultureInfo.InvariantCulture));
            item.Tag = smooth;
            listViewRaw.Items.Add(item);

            var form2 = new ChartPlot(item.Name, smooth)
            {
                MdiParent = this
            };
            form2.Show();
        }

        private void tsFraserFilter_Click(object sender, EventArgs e)
        {
            if (listViewRaw.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"You have not selected any tilt data.", @"No Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return;
            }

            var tiltData = listViewRaw.SelectedItems[0].Tag as TiltData;
            if (tiltData != null && tiltData.Npts < 4)
            {
                MessageBox.Show(@"There should be minimum of 4 data for this filter to work.");
                return;
            }

            var name = FindUniqeName(listViewRaw.SelectedItems[0].Name, listViewFraser);
            if (InputPrompt.InputStringBox("Fraser Filter", "Enter a name.", ref name) != DialogResult.OK)
                return;

            // Do Fraser Filtering
            var fraser = VlfFilter.Fraser(tiltData);
            fraser.Rename(name);

            // Create a new listview item to be added to ListViewFraser
            var item = new ListViewItem
            {
                Name = name,
                Text = name,
                Tag = fraser
            };

            item.SubItems.Add(fraser.Npts.ToString());
            item.SubItems.Add(fraser.Spacing.ToString(CultureInfo.InvariantCulture));
            listViewFraser.Items.Add(item);

            // end of creating new item to be added to ListViewFraser

            // Plot the result
            var form2 = new ChartPlot(item.Name, fraser) {MdiParent = this};
            form2.Show();
        }

        private void tsKarousHjelt_Click(object sender, EventArgs e)
        {
            if (listViewRaw.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"You have not selected any tilt data.", @"No Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return;
            }

            var tiltData = listViewRaw.SelectedItems[0].Tag as TiltData;
            if (tiltData != null && tiltData.Npts < 6)
            {
                MessageBox.Show(@"There should be minimum of 7 data for this filter to work.");
                return;
            }

            var name = FindUniqeName(listViewRaw.SelectedItems[0].Name, listViewKH);
            if (InputPrompt.InputStringBox("Karous Hjelt-Filter", "Enter a name.", ref name) != DialogResult.OK)
                return;

            var skin = 0f;
            if (
                InputPrompt.InputNumberBox("Karous Hjelt-Filter",
                    $"Skin depth normalization. Enter 0 to ignore skin depth", ref skin) != DialogResult.OK)
                return;

            var kh = VlfFilter.KarousHjelt(tiltData, skin);
            kh.Rename(name);

            var item = new ListViewItem()
            {
                Name = name,
                Text = name,
                Tag = kh
            };
            item.SubItems.Add((-1*kh.Depths.Min()).ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(kh.Spacing.ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(kh.SkinDepth.ToString(CultureInfo.InvariantCulture));
            listViewKH.Items.Add(item);

            if (kh.RawLength > 150)
            {
                MessageBox.Show(
                    @"Due to the limitation of gridding implementation in this version, the filtered result could not be shown. However, you can still export the result into an external file.",
                    @"Data Too Large To Grid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            tsStatusLabel.Text = @"Building grid..";
            krigingProgressBar.Visible = true;
            krigingWorker.RunWorkerAsync(kh);
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


        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            var lv = sender as ListView;
            if (e.KeyCode == Keys.Delete)
            {
                if (lv == null) return;
                foreach (ListViewItem item in lv.SelectedItems)
                {
                    lv.Items.Remove(item);
                }
            }

            else if (e.Control && e.KeyCode == Keys.A)
            {
                if (lv == null) return;
                foreach (ListViewItem item in lv.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            var tsm = sender as ToolStripMenuItem;
            var cm = tsm?.Owner as ContextMenuStrip;
            var lv = cm?.SourceControl as ListView;

            if (lv == null) return;
            foreach (ListViewItem item in lv.SelectedItems)
            {
                lv.Items.Remove(item);
            }
        }

        private void tsInterpolate_Click(object sender, EventArgs e)
        {
            if (!listViewRaw.Focused || listViewRaw.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"You have not selected any data.");
                return;
            }

            var data = listViewRaw.SelectedItems[0].Tag as TiltData;

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


            var newname = FindUniqeName($"{data.Name}_Interpolated", listViewRaw);
            if (InputPrompt.InputStringBox("Cubic Spline Interpolation", "Enter a name.", ref newname) !=
                DialogResult.OK)
                return;

            var tiltData = VlfInterpolation.CubicSplineNatural(data, Convert.ToSingle(spacing), npt);
            tiltData.Rename(newname);
            var item = new ListViewItem {Text = newname, Name = newname};
            item.SubItems.Add(tiltData.Npts.ToString());
            item.SubItems.Add(tiltData.Spacing.ToString(CultureInfo.InvariantCulture));
            item.Tag = tiltData;
            listViewRaw.Items.Add(item);

            var form2 = new ChartPlot(item.Name, tiltData)
            {
                MdiParent = this
            };
            form2.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProjectNow();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = saveProjectDialog.ShowDialog();
            if (dlg != DialogResult.OK) return;

            VlfProjectHandler.Save(SaveProject(saveProjectDialog.FileName), saveProjectDialog.FileName);
            _currentFile = new FileInfo(saveProjectDialog.FileName);
            Text = $"WinVLF - [{_currentFile.Name}]";
            tsStatusLabel.Text = string.Empty;
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = openProjectDialog.ShowDialog();
            if (dlg != DialogResult.OK) return;
            LoadProject(VlfProjectHandler.Read(openProjectDialog.FileName));
            _currentFile = new FileInfo(openProjectDialog.FileName);
            MessageBox.Show(@"Project opened succesfully.", @"Open Project", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            tsStatusLabel.Text = string.Empty;
        }

        private void SVLF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listViewRaw.Items.Count == 0 && listViewFraser.Items.Count == 0 && listViewKH.Items.Count == 0)
            {
                return;
            }
            var dlg = MessageBox.Show(@"Do you want to save before exit?", @"Save before exit",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (dlg)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.OK:
                    SaveProjectNow();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void closeStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewRaw.Items.Count == 0 && listViewFraser.Items.Count == 0 && listViewKH.Items.Count == 0)
            {
                return;
            }
            var dlg = MessageBox.Show(@"Do you want to save before closing this project?", @"Save before closing",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (dlg)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.OK:
                    SaveProjectNow();
                    break;
                case DialogResult.No:
                    CloseProject();
                    break;
            }
        }

        private void krigingWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Debug.WriteLine("Starting to do some work");
            var kh = e.Argument as KarousHjeltData;
            if (kh == null) return;
            Debug.WriteLine($"Will process {kh.Values.Length} datas");

            // Preparing Matrix Object
            var inputPoints = Matrix<float>.Build.DenseOfColumnArrays(kh.Distances, kh.Depths);
            var valueVector = Vector<float>.Build.DenseOfArray(kh.Values);

            var vgram = new Powvargram(inputPoints, valueVector);
            Debug.WriteLine("Done with variogram");
            var krig = new Kriging(inputPoints, valueVector, vgram);
            Debug.WriteLine("Done with kriging");

            //var krig = new Shepard(inputPoints,valueVector);


            var xmax = kh.Distances.Max();
            var xmin = kh.Distances.Min();
            var ymax = kh.Depths.Max();
            var ymin = kh.Depths.Min();

            // Calculate axis range
            var dx = xmax - xmin;
            var dy = Math.Abs(Math.Abs(ymax) - Math.Abs(ymin));


            // Determine spacing with nx points grid
            const int nx = 200;
            var xSpacing = dx/(nx - 1);

            // Determine number of y grid so that the space is equal
            var ny = Convert.ToInt32(Math.Ceiling(dy/xSpacing));
            var ySpacing = dy/(ny - 1);

            Debug.WriteLine($"{nx} {ny} {xSpacing} {ySpacing}");


            // Create the heatmap series

            var khmap = new HeatMapSeries
            {
                X0 = kh.Distances.Min(),
                X1 = kh.Distances.Max(),
                Y0 = kh.Depths.Max(),
                Y1 = kh.Depths.Min(),
                Data = new double[nx, ny],
                Interpolate = false,
                CoordinateDefinition = HeatMapCoordinateDefinition.Edge
            };

            int progress = 0;

            khmap.Data.Fill2D(double.NaN);
            // Filling the data by interpolating using kriging
            for (var i = 0; i < ny; i++)
            {
                for (var j = 0; j < nx; j++)
                {
                    progress++;
                    krigingWorker.ReportProgress((progress*100)/(nx*ny));
                    var point2Interpolate =
                        Vector<float>.Build.DenseOfArray(new[] {xmin + (j*xSpacing), ymax - (i*ySpacing)});
                    khmap.Data[j, i] = krig.Interpolate(point2Interpolate);
                }
            }

            e.Result = new Tuple<HeatMapSeries, string, float>(khmap, kh.Name, kh.SkinDepth);
        }

        private void krigingWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            tsStatusLabel.Text = string.Empty;
            krigingProgressBar.Value = 0;
            krigingProgressBar.Visible = false;
            var result = e.Result as Tuple<HeatMapSeries, string, float>;
            if (result == null) return;
            var form2 = new ChartPlot(result.Item2, result.Item1, result.Item3) {MdiParent = this};
            form2.Show();
        }

        private void krigingWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            krigingProgressBar.Value = e.ProgressPercentage;
        }
    }
}