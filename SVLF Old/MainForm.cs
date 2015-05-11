using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AwokeKnowing.GnuplotCSharp;
using DotNetPerls;
using FileHelpers;
using Simple_VLF.Properties;
using ZedGraph;


namespace Simple_VLF
{
    public partial class MainForm : Form
    {
        public const string PROGRAM_NAME = @"Simple VLF-EM Filtering";
        public const string VERSION = @"v1.0";
        public string PROGRAM_NAME_VERSION = String.Join(" ", new[] {PROGRAM_NAME, VERSION});
        
        private string x86ProgramFiles;
        private string gnupath;
        private bool contourModeEnabled;
        private Image ecdPlot_png;

        private BindingList<VLF_SurveyRecord> vlfSurveyRecords;
        private BindingList<VLF_FraserRecord> fraserRecords;
        private BindingList<VLF_KarousHjeltRecord> karousHjeltRecords;

        public MainForm()
        {
            InitializeComponent();

            var emComponents = new BindingList<VLF_EMComponent>();
            emComponents.Add(VLF_EMComponents.Real);
            emComponents.Add(VLF_EMComponents.Imaginary);
            
            cboxComponents.DataSource = emComponents;
        }

        private void Contour(BindingList<VLF_KarousHjeltRecord> khRecordList , double spacing,VLF_EMComponent comp, string mode = "terminal wxt size 1100,320 enhanced font 'Verdana,10' persist")
        {
            buttonKH.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            
            GnuPlot.CallNew(gnupath);

            var X = new double[khRecordList.Count];
            var Y = new double[khRecordList.Count];
            var Z = new double[khRecordList.Count];

            for (int i = 0; i < khRecordList.Count; i++)
            {
                X[i] = khRecordList[i].Distance;
                Y[i] = khRecordList[i].Depth;
                Z[i] = khRecordList[i].KH;
            }
            
            int gridSizeX = (int) ((X.Max() - X.Min())/(spacing/2.0));
            int gridSizeY = (int) ((Y.Max() - Y.Min())/(spacing/4.0));
            
            string terminal = mode;

            if (mode == "ecdPlot_png")
            {
                terminal = "terminal pngcairo size 1200,400 font 'Tahoma,11' persist";
            }

            GnuPlot.Set(terminal);
            //GnuPlot.Set("dgrid3d 15,50");
            GnuPlot.Set(string.Format("dgrid3d {0},{1}",gridSizeY,gridSizeX));
            GnuPlot.Set("style line 12 lc rgb '#808080' lt 0 lw 1");
            //GnuPlot.Set("grid back ls 12");
            GnuPlot.Set("tics nomirror");
            GnuPlot.Set("mxtics");
            GnuPlot.Set("xtics border out");
            GnuPlot.Set("border 4095 front linetype -1 linewidth 1");
            GnuPlot.Set(string.Format("title 'Karous Hjelt Filter ({0})' font 'Tahoma,13'",comp.Type));
            GnuPlot.Set("view map");
            GnuPlot.Set("size 1.284,1; set origin -0.122,0.1");
            GnuPlot.Set("xlabel 'Distance (m)");
            GnuPlot.Set("ylabel 'Depth (m)'");
            GnuPlot.Set("colorbox horizontal");
            GnuPlot.Set("colorbox user origin 0.15,0.09 size 0.3,0.05");
            GnuPlot.Set("cbtics border out");
            GnuPlot.Set("palette rgb 33,13,10 ");
            GnuPlot.SPlot(X, Y, Z, "with pm3d notitle");

            if (!mode.Equals("ecdPlot_png"))
            {
                buttonKH.Enabled = true;
                return;
            }
            GnuPlot.WriteLine("exit");
            ecdPlot_png = Image.FromStream(GnuPlot.GetImageStream.BaseStream);
            picBoxKarous.Image = ecdPlot_png;
            saveContourAsPNG.Enabled = true;

            buttonKH.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        static string ProgramFiles_x86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }
        
        private void AddNewGraph(ZedGraphControl zgc, PointPairList points, string legend, float lineWidth, Color curveColor, DashStyle style, SymbolType symbol, bool useSymbol = true)
        {
            GraphPane myPane = zgc.GraphPane;

            // clear previous graph
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            myPane.Legend.FontSpec.Size = 14.0f;

            zgc.Invalidate();

            LineItem myCurve = new LineItem(legend, points, curveColor, symbol)
            {
                Line = {Width = lineWidth, IsSmooth = true, IsAntiAlias = true, Style = style},
                Symbol = {IsVisible = useSymbol, Size = 4, Fill = new Fill(curveColor)}
            };
            
            myPane.CurveList.Add(myCurve);

            zgc.AxisChange();
            zgc.Refresh();
        }

        private void AddGraph(ZedGraphControl zgc, PointPairList points, string legend, float lineWidth, Color curveColor, DashStyle style, SymbolType symbol)
        {
            GraphPane myPane = zgc.GraphPane;

            LineItem myCurve = new LineItem(legend, points, curveColor, symbol)
            {
                Line = { Width = lineWidth, IsSmooth = true, IsAntiAlias = true, Style = style },
                Symbol = { IsVisible = true, Size = 4, Fill = new Fill(curveColor) }
            };

            myPane.CurveList.Add(myCurve);

            zgc.AxisChange();
            zgc.Refresh();
        }

        private void AddGraph(ZedGraphControl zgc, CurveItem points)
        {
            var myPane = zgc.GraphPane;
            var myCurve = (LineItem) points;

            myCurve.Symbol.IsVisible = true;
            myPane.CurveList.Add(myCurve);
            zgc.AxisChange();
            zgc.Refresh();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = readVlfDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = readVlfDialog.FileName;
                try
                {
                    BindingList<VLF_SurveyRecord> inputRecords = ReadDelimiter(file);
                    if (inputRecords != null)
                    {
                        vlfSurveyRecords = new BindingList<VLF_SurveyRecord>(inputRecords.OrderBy(x => x.Distance).ToList());
                    }
                    
                    dgvMeasurement.DataSource = vlfSurveyRecords;
                    ClearAll();

                    tabControl1.SelectTab(tabPageData);

                    if (vlfSurveyRecords != null)
                    {
                        
                        Text = String.Join(" - ", new[] { PROGRAM_NAME_VERSION, readVlfDialog.SafeFileName });
                        
                        numSpacing.Value = CalculateSpacing(vlfSurveyRecords);

                        PointPairList tiltPoints = ListToPointPairList(vlfSurveyRecords, VLF_EMComponents.Real);
                        PointPairList ellipsPoints = ListToPointPairList(vlfSurveyRecords, VLF_EMComponents.Imaginary);

                        AddNewGraph(zgcMeasurement, tiltPoints, "Real (Tilt Angle)", 1.6f, Color.Coral, DashStyle.Solid, SymbolType.Square);
                        AddGraph(zgcMeasurement, ellipsPoints, "Imaginary (Ellipticity)", 1.6f, Color.DarkTurquoise,DashStyle.Solid, SymbolType.Square);
                    }
                    readVlfDialog.FileName = string.Empty;
                }
                catch (IOException)
                {
                    MessageBox.Show(@"File Read Error", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ClearAll()
        {
            if (fraserRecords != null) fraserRecords.Clear();
            if (karousHjeltRecords != null) karousHjeltRecords.Clear();
            if (zgcMeasurement != null)
            {
                zgcMeasurement.GraphPane.CurveList.Clear();
                zgcMeasurement.Refresh();
            }
            if (zgcFraser != null)
            {
                zgcFraser.GraphPane.CurveList.Clear();
                zgcFraser.GraphPane.GraphObjList.Clear();
                zgcFraser.Refresh();
            }
            if (picBoxKarous != null) picBoxKarous.Image = null;
        }

        private static decimal CalculateSpacing(BindingList<VLF_SurveyRecord> vlfSurveyRecords)
        {
            double temp = 0.0;

            for (int i = 0; i < vlfSurveyRecords.Count - 1; i++)
            {
                temp += Math.Abs(vlfSurveyRecords[i].Distance - vlfSurveyRecords[i + 1].Distance);
            }

            return (decimal) temp/(vlfSurveyRecords.Count - 1);
        }

        private BindingList<VLF_SurveyRecord> ReadDelimiter(string file)
        {
            var engine = new DelimitedFileEngine(typeof(VLF_SurveyRecord));
            engine.ErrorManager.ErrorMode = ErrorMode.ThrowException;
            VLF_SurveyRecord [] input;

            try
            {
                input = (VLF_SurveyRecord[]) engine.ReadFile(file);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Error: Input Format Invalid. Please check again.", @"Invalid Format", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return null;
            }

            var bindList = new BindingList<VLF_SurveyRecord>(input);
            
            MessageBox.Show(@"File Successfully Loaded.", @"Load Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            return bindList;
        }

        private PointPairList ListToPointPairList(BindingList<VLF_SurveyRecord> bindList, VLF_EMComponent component)
        {
            var returnList = new PointPairList();

            if (component == VLF_EMComponents.Real)
            {
                foreach (var vlfSurveyRecord in bindList)
                {
                    returnList.Add(vlfSurveyRecord.Distance,vlfSurveyRecord.Tilt);
                }
            }
            else
            {
                foreach (var vlfSurveyRecord in bindList)
                {
                    returnList.Add(vlfSurveyRecord.Distance, vlfSurveyRecord.Ellips);
                }
            }
            return returnList;
        }


        private void MainForm_Load_1(object sender, EventArgs e)
        {
            SetupGNUPlot();
            SetupGraphPane(zgcFraser,"Fraser Filtered", "Distance (m)", "Response (%)");
            SetupGraphPane(zgcMeasurement, "Observed Data", "Distance (m)", "Response (%)");

            saveContourAsPNG.Enabled = false;
            saveFraser.Enabled = false;
            saveKarousHjelt.Enabled = false;
        }

        private void SetupGraphPane(ZedGraphControl zgc, string title, string xlabel, string ylabel)
        {
            GraphPane myPane = zgc.GraphPane;
            
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = xlabel;
            myPane.YAxis.Title.Text = ylabel;

            zgc.Refresh();

        }

        private void SetupGNUPlot()
        {
            Text = PROGRAM_NAME_VERSION;
            x86ProgramFiles = ProgramFiles_x86();
            gnupath = string.Format("{0}{1}gnuplot{1}bin{1}gnuplot.exe", x86ProgramFiles, (char)92);
            

            if (!File.Exists(gnupath))
            {
                MessageBox.Show(@"No installation of GNU Plot is detected, equivalent current density plot is disabled.");
                contourModeEnabled = false;
                buttonGnu.Enabled = false;
                textBoxGnuPlotAddress.Text = string.Empty;
            }
            else
            {
                contourModeEnabled = true;
                textBoxGnuPlotAddress.Text = gnupath;
            }
        }


        private void buttonFraser_Click(object sender, EventArgs e)
        {
            if (vlfSurveyRecords == null)
            {
                MessageBox.Show(@"There is no data.", @"Insufficient Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (vlfSurveyRecords.Count < 4)
            {
                MessageBox.Show(@"Fraser Filter Requires at least 4 data.", @"Insufficient Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fraserRecords = VLF_Filter.Fraser(vlfSurveyRecords,cboxComponents.SelectedItem);

            dgvFraser.DataSource = fraserRecords;
            dgvFraser.Columns[1].HeaderText = string.Format("Fraser-{0}", cboxComponents.SelectedValue);
            dgvFraser.Refresh();

            saveFraser.Enabled = true;

            PointPairList fraser_points = ListToPointPairList(fraserRecords);

            AddNewGraph(zgcFraser,fraser_points,string.Format("Fraser Filtered ({0})",cboxComponents.SelectedValue),1.7f,Color.BlueViolet,DashStyle.Dash,SymbolType.Square,false);
            AddGraph(zgcFraser,zgcMeasurement.GraphPane.CurveList[cboxComponents.SelectedIndex]);

            tabControl1.SelectTab(tabPageFraser);
        }

        
        private PointPairList ListToPointPairList(BindingList<VLF_FraserRecord> bindList)
        {
            PointPairList returnList = new PointPairList();
            foreach (var vlfFraserRecord in bindList)
            {
                returnList.Add(vlfFraserRecord.Distance,vlfFraserRecord.Fraser);
            }
            return returnList;
        }

        private void buttonKH_Click(object sender, EventArgs e)
        {
            if (vlfSurveyRecords == null)
            {
                MessageBox.Show(@"There is no data", @"Insufficient Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (vlfSurveyRecords.Count < 7)
            {
                MessageBox.Show(@"Karous Hjelt Filter Requires at least 7 data.", @"Insufficient Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            karousHjeltRecords = VLF_Filter.KarousHjelt(vlfSurveyRecords,cboxComponents.SelectedItem,(double) numSkinDepth.Value,(double) numSpacing.Value);
            dgvKH.DataSource = karousHjeltRecords;
            dgvKH.Columns[2].HeaderText = string.Format("KH-{0}", cboxComponents.SelectedValue);
            dgvKH.Refresh();

            if (contourModeEnabled)
            {
               Contour(karousHjeltRecords, (double) numSpacing.Value ,VLF_Filter.EMComponent,"ecdPlot_png");   
            }

            saveKarousHjelt.Enabled = true;
            tabControl1.SelectTab(tabPageKH);

        }

        private void buttonGnu_Click(object sender, EventArgs e)
        {
            if (karousHjeltRecords == null)
            {
                MessageBox.Show(@"No Data to Plot", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Contour(karousHjeltRecords,(double) numSpacing.Value,VLF_Filter.EMComponent);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileKarous.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = saveFileKarous.FileName;
                try
                {
                    const string line1 = @"# ------------------------------------------------------
# Results from S-VLF: Karous Hjelt filtered VLF-data  
# ------------------------------------------------------";
                    const string line2 = "# Distance and depth unit: meter";
                    string line3 = string.Format("# Depth Normalization : {0} m", VLF_Filter.SkinDepth);
                    string line4 = string.Format("Distance\tDepth\t{0}",dgvKH.Columns[2].HeaderText);
                    if (numSkinDepth.Value == 0)
                    {
                        line3 = "# Depth normalization is not used.";
                    }
                    var engine = new FileHelperEngine(typeof(VLF_KarousHjeltRecord))
                    {
                        HeaderText = string.Join(Environment.NewLine,new []{line1,line2,line3,line4})
                    };

                    var records = karousHjeltRecords.ToArray();
                    engine.WriteFile(file, records);

                    saveFileKarous.FileName = string.Empty;

                    MessageBox.Show(@"Saved Successfully", @"Save Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (IOException)
                {
                    MessageBox.Show(@"File Read Error", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveContourAsPNG_Click(object sender, EventArgs e)
        {
            saveAsPng.ShowDialog();
        }

        private void saveAsPng_FileOk(object sender, CancelEventArgs e)
        {
            ecdPlot_png.Save(saveAsPng.FileName);
            saveAsPng.FileName = string.Empty;
        }

        private void buttonBrowseGnu_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string dir = string.Format("{0}{1}gnuplot.exe", folderBrowserDialog1.SelectedPath, (char)92);

                if (!File.Exists(dir))
                {
                    MessageBox.Show(@"No GNU Plot Installation is detected in current directory.");
                    return;
                }

                MessageBox.Show(@"GNU Plot Installation detected.");
                gnupath = dir;
                textBoxGnuPlotAddress.Clear();
                textBoxGnuPlotAddress.Text = dir;
                contourModeEnabled = true;
                buttonGnu.Enabled = true;

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BetterDialog.ShowDialog("About S-VLF", PROGRAM_NAME_VERSION,
                "S-VLF (Simple VLF) are an easy to use, one click away, data filtering application made for Very Low Frequency EM Surveys.\n\n" +
                "© 2014 Adien Akhmad. All rights reserved.", null, "Close",
                (Image)Resources.ResourceManager.GetObject("aboutIco"));
        }

        private void saveFraser_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileFraser.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = saveFileFraser.FileName;
                try
                {
                    const string line1 = @"# ------------------------------------------------------
# Results from S-VLF: Fraser filtered VLF-data  
# ------------------------------------------------------";
                    const string line2 = "# Distance unit: meter";
                    string line3 = string.Format("Distance\t{0}", dgvFraser.Columns[1].HeaderText);
                    var engine = new FileHelperEngine(typeof(VLF_FraserRecord))
                    {
                        HeaderText = string.Join(Environment.NewLine, new[] { line1, line2, line3 })
                    };

                    var records = fraserRecords.ToArray();
                    engine.WriteFile(file, records);
                    saveFileFraser.FileName = string.Empty;
                    MessageBox.Show(@"Saved Successfully", @"Save Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (IOException)
                {
                    MessageBox.Show(@"File Read Error", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        
    }
}
