using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using VLFLib.Data;
using VLFLib.Gridding;

namespace WinVLF
{
    public partial class ChartPlot : Form
    {
        public ChartPlot(string title, TiltData data)
        {
            InitializeComponent();
            plotView1.Model = GraphTilt(title,$"dx={data.Spacing} m, N {data.Bearing} °E");
            AddSeries(data);
            Text = $"Real Comp [{title}]";
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public ChartPlot(string title, HeatMapSeries surf2d)
        {
            InitializeComponent();
            plotView1.Model = Surf2DModel(title);
            plotView1.Model.Series.Add(surf2d);
        }

        private void AddSeries(Surface2D surf)
        {
            throw new NotImplementedException();
        }

        public ChartPlot(string title, FraserData data)
        {
            InitializeComponent();
            plotView1.Model = GraphFraser(title, $"dx={data.Spacing} m, N {data.Bearing} °E");
            AddSeries(data);
            Text = $"Fraser [{title}]";
        }

        public ChartPlot(string title, HeatMapSeries khmap, float skin, float dx, float az)
        {
            InitializeComponent();
            Text = $"KH Filter [{title}]";
            plotView1.Model = HeatMapModel(title, skin, dx, az);
            plotView1.Model.Series.Add(khmap);
            
        }

        private static PlotModel Surf2DModel(string title)
        {
            var plotModel1 = new PlotModel
            {
                PlotType = PlotType.Cartesian,
                Title = $"2D Surface - {title}",
                SubtitleFontSize = 10,
                TitleFont = "Tahoma",
                TitleFontSize = 12,
                DefaultFont = "Tahoma",
                IsLegendVisible = false
            };

            var linearColorAxis1 = new LinearColorAxis
            {
                Position = AxisPosition.Right,
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
                Title = "Easting",
                Unit = "m"
            };
            plotModel1.Axes.Add(linearAxis1);
            var linearAxis2 = new LinearAxis
            {
                MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                Title = "Northing",
                Unit = "m"
            };
            plotModel1.Axes.Add(linearAxis2);

            return plotModel1;
        }

        private void AddSeries(TiltData data)
        {
            var tiltSeries = new LineSeries
            {
                Title = "Tilt (%)",
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.DarkOrange,
                Color = OxyColors.DarkOrange
            };

            for (var i = 0; i < data.Npts; i++)
            {
                tiltSeries.Points.Add(new DataPoint(data.Distances[i], data.Values[i]));
            }

            plotView1.Model.Series.Add(tiltSeries);
        }

        private void AddSeries(FraserData data)
        {
            var fraserSeries = new LineSeries
            {
                Title = "Fraser (%)",
                MarkerType = MarkerType.Circle,
                MarkerFill = OxyColors.DarkViolet,
                Color = OxyColors.DarkViolet
            };


            for (var i = 0; i < data.Npts; i++)
            {
                fraserSeries.Points.Add(new DataPoint(data.Distances[i], data.Values[i]));
            }

            plotView1.Model.Series.Add(fraserSeries);
        }

        private static PlotModel HeatMapModel(string title, float skin, float dx, float az)
        {
            var subtitle = $"dx = {dx} m, skin depth = {skin}m, N {az}°E";
            
            var plotModel1 = new PlotModel
            {
                PlotType = PlotType.Cartesian,
                Title = $"KH Filtered - {title}",
                Subtitle = subtitle,
                SubtitleFontSize = 10,
                TitleFont = "Tahoma",
                TitleFontSize = 12,
                DefaultFont = "Tahoma",
                IsLegendVisible = false
            };
            var linearColorAxis1 = new LinearColorAxis
            {
                Position = AxisPosition.Right,
                InvalidNumberColor = OxyColors.Transparent,
                //Palette = OxyPalettes.BlueWhiteRed(128)
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
                Title = "Depth",
                Unit = "m"
            };
            plotModel1.Axes.Add(linearAxis2);

            return plotModel1;
        }

        private static PlotModel GraphTilt(string title, string subtitle)
        {
            return GraphPaper("Real Comp - " + title, subtitle,"Tilt Angle", "%");
        }

        private static PlotModel GraphFraser(string title, string subtitle)
        {
            return GraphPaper("Fraser - " + title, subtitle,"Fraser Value", "%");
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
            foreach (var axise in plotView1.Model.Axes)
            {
                axise.Reset();
            }
        }

        public static double BilinearInterpolation(double[] x, double[] y, double[,] z, double xval, double yval)
        {
            //calculates single point bilinear interpolation
            var zval = 0.0;
            for (var i = 0; i < x.Length - 1; i++)
            {
                for (var j = 0; j < y.Length - 1; j++)
                {
                    if (xval >= x[i] && xval < x[i + 1] && yval >= y[j] && yval < y[j + 1])
                    {
                        zval = z[i, j]*(x[i + 1] - xval)*(y[j + 1] - yval)/(x[i + 1] - x[i])/(y[j + 1] - y[j]) +
                               z[i + 1, j]*(xval - x[i])*(y[j + 1] - yval)/(x[i + 1] - x[i])/(y[j + 1] - y[j]) +
                               z[i, j + 1]*(x[i + 1] - xval)*(yval - y[j])/(x[i + 1] - x[i])/(y[j + 1] - y[j]) +
                               z[i + 1, j + 1]*(xval - x[i])*(yval - y[j])/(x[i + 1] - x[i])/(y[j + 1] - y[j]);
                    }
                }
            }
            return zval;
        }

        public static double[] BilinearInterpolation(double[] x, double[] y, double[,] z, double[] xvals, double[] yvals)
        {
            //calculates multiple point bilinear interpolation
            var zvals = new double[xvals.Length];
            for (var i = 0; i < xvals.Length; i++)
                zvals[i] = BilinearInterpolation(x, y, z, xvals[i], yvals[i]);
            return zvals;
        }
    }
}