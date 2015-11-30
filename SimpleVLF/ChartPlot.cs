using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using VLFLib.Data;

namespace WinVLF
{
    public partial class ChartPlot : Form
    {
        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public ChartPlot(HeatMapSeries map, Surface2D surf)
        {
            InitializeComponent();
            plotView1.Model = Surf2DModel(surf);
            plotView1.Model.Series.Add(map);

            switch (surf.SurfType)
            {
                case Surface2D.SurfaceType.Pseudosections:
                    Text = $"Pseudosections [{surf.Title}]";
                    break;
                case Surface2D.SurfaceType.Surface:
                    Text = $"2D Surface [{surf.Title}]";
                    break;
            }
        }

        public ChartPlot(string title, VLFBasicData data)
        {
            InitializeComponent();
            if (data.GetType() == typeof (TiltData))
            {
                plotView1.Model = GraphPaper(title, $"dx: {data.Spacing} m, N {data.Bearing} °E",
                    "Tilt", "%");
                AddSeries(data,OxyColors.DarkOrange);
                Text = $"Tilt [{title}]";
            }
            else
            {
                plotView1.Model = GraphPaper(title, $"dx: {data.Spacing} m, N {data.Bearing} °E",
                    "Fraser Value", "%");
                AddSeries(data,OxyColors.MidnightBlue);
                Text = $"Fraser [{title}]";
            }
        }

        private static PlotModel Surf2DModel(Surface2D surf)
        {
            var plotModel1 = new PlotModel
            {
                PlotType = PlotType.Cartesian,
                Title = surf.Title,
                Subtitle = surf.Subtitle,
                SubtitleFontSize = 10,
                TitleFont = "Tahoma",
                TitleFontSize = 12,
                DefaultFont = "Tahoma",
                IsLegendVisible = false
            };

            var linearColorAxis1 = new LinearColorAxis
            {
                Title = surf.ZAxisTitle,
                Unit = surf.ZUnit,
                Position = AxisPosition.Right,
                AxisDistance = 5.0,
                InvalidNumberColor = OxyColors.Transparent,
                Palette = OxyPalettes.Jet(256)
            };
            plotModel1.Axes.Add(linearColorAxis1);

            var linearAxis1 = new LinearAxis
            {
                MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                Position = AxisPosition.Bottom,
                Title = surf.XAxisTitle,
                Unit = surf.XUnit
            };
            plotModel1.Axes.Add(linearAxis1);
            var linearAxis2 = new LinearAxis
            {
                MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                Title = surf.YAxisTitle,
                Unit = surf.YUnit
            };
            plotModel1.Axes.Add(linearAxis2);

            return plotModel1;
        }

        private void AddSeries(VLFBasicData data, OxyColor color)
        {
            var str = data.GetType() == typeof (TiltData) ? "Tilt (%)" : "Fraser (%)";

            var series = new LineSeries
            {
                Title = str,
                MarkerType = MarkerType.Circle,
                MarkerFill = color,
                Color = color
            };

            for (var i = 0; i < data.Npts; i++)
            {
                series.Points.Add(new DataPoint(data.Distances[i], data.Values[i]));
            }

            plotView1.Model.Series.Add(series);
        }

        private static PlotModel GraphPaper(string title, string subtitle, string ytitle, string yunit)
        {
            var plotModel1 = new PlotModel
            {
                PlotType = PlotType.Cartesian,
                Title = title,
                TitleFont = "Tahoma",
                TitleFontSize = 12,
                Subtitle = subtitle,
                SubtitleFontSize = 10,
                DefaultFont = "Tahoma",
                IsLegendVisible = true
            };
            var linearAxis1 = new LinearAxis
            {
                MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                Position = AxisPosition.Bottom,
                Title = "Distance",
                Unit = "m"
            };
            plotModel1.Axes.Add(linearAxis1);
            var linearAxis2 = new LinearAxis
            {
                MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                Title = ytitle,
                Unit = yunit
            };
            plotModel1.Axes.Add(linearAxis2);
            return plotModel1;
        }

        private void PlotForm_Load(object sender, EventArgs e)
        {
        }

        private void plotView1_Resize(object sender, EventArgs e)
        {
            foreach (var axis in plotView1.Model.Axes)
            {
                axis.Reset();
            }
        }

        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = saveFileDialog1.ShowDialog();
            if (dlg != DialogResult.OK) return;

            using (var stream = File.Create(saveFileDialog1.FileName))
            {
                var pngExporter = new PngExporter()
                {
                    Width = (int) plotView1.Model.Width,
                    Height = (int) plotView1.Model.Height
                };
                pngExporter.Export(plotView1.Model, stream);
            }

            saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var stream = new MemoryStream())
            {
                var pngExporter = new PngExporter()
                {
                    Width = (int) plotView1.Model.Width,
                    Height = (int) plotView1.Model.Height
                };
                pngExporter.Export(plotView1.Model, stream);
                var img = Image.FromStream(stream);
                Clipboard.SetImage(img);
            }

            MessageBox.Show(@"Image copied to clipboard", @"Copy Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}