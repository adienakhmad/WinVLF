using System;
using System.Linq;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using VLFLib.Data;
using VLFLib.Gridding;

namespace SimpleVLF
{
    public partial class ChartPlot : Form
    {
        public ChartPlot(string title, TiltData data)
        {
            InitializeComponent();
            plotView1.Model = GraphTilt(title);
            AddSeries(data);
        }

        public ChartPlot(string title, FraserData data)
        {
            InitializeComponent();
            plotView1.Model = GraphFraser(title);
            AddSeries(data);
        }

        public ChartPlot(string title, KarousHjeltData kh)
        {
            InitializeComponent();
            plotView1.Model = HeatMapModel(title, kh.SkinDepth);
            HeatMapKriging(kh);
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

            for (var i = 0; i < data.Count; i++)
            {
                tiltSeries.Points.Add(new DataPoint(data.GetDistanceAt(i), data.GetTiltAt(i)));
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


            for (var i = 0; i < data.Count; i++)
            {
                fraserSeries.Points.Add(new DataPoint(data.Distances[i], data.FraserValue[i]));
            }

            plotView1.Model.Series.Add(fraserSeries);
        }

        private void HeatMapKriging(KarousHjeltData kh)
        {
            // Preparing Kriging Object
            var inputPoints = Matrix<float>.Build.DenseOfColumnArrays(kh.DistanceArray, kh.DepthArray);
            var valueVector = Vector<float>.Build.DenseOfArray(kh.KarousHjeltArray);
            var vgram = new Powvargram(inputPoints, valueVector);
            var krig = new Kriging(inputPoints, valueVector, vgram);


            var xmax = kh.DistanceArray.Max();
            var xmin = kh.DistanceArray.Min();
            var ymax = kh.DepthArray.Max();
            var ymin = kh.DepthArray.Min();

            // Calculate axis range
            var dx = xmax - xmin;
            var dy = Math.Abs(Math.Abs(ymax) - Math.Abs(ymin));


            // Determine spacing with 200 points grid
            const int nx = 200;
            var xSpacing = dx/(nx - 1);

            // Determine number of y grid so that the space is equal
            var ny = Convert.ToInt32(Math.Ceiling(dy/xSpacing));
            var ySpacing = dy/(ny - 1);


            // Create the heatmap series

            var khmap = new HeatMapSeries
            {
                X0 = kh.DistanceArray.Min(),
                X1 = kh.DistanceArray.Max(),
                Y0 = kh.DepthArray.Max(),
                Y1 = kh.DepthArray.Min(),
                Data = new double[nx, ny],
                Interpolate = false
            };

            khmap.Data.Fill2D(double.NaN);
            // Filling the data by interpolating using kriging
            for (var i = 0; i < ny; i++)
            {
                for (var j = 0; j < nx; j++)
                {
                    var point2Interpolate =
                        Vector<float>.Build.DenseOfArray(new[] {xmin + (j*xSpacing), ymax - (i*ySpacing)});
                    khmap.Data[j, i] = krig.Interpolate(point2Interpolate);
                }
            }

            plotView1.Model.Series.Add(khmap);
        }

        private static PlotModel HeatMapModel(string title, float skin)
        {
            var subtitle = string.Empty;
            if (!skin.Equals(0))
            {
                subtitle = $"Skin Depth = {skin}m";
            }
            var plotModel1 = new PlotModel
            {
                PlotType = PlotType.Cartesian,
                Title = $"Apparent Conductivity - {title}",
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

        private static PlotModel GraphTilt(string title)
        {
            return GraphPaper("Real Comp - " + title, "Tilt Angle", "%");
        }

        private static PlotModel GraphFraser(string title)
        {
            return GraphPaper("Fraser - " + title, "Fraser Value", "%");
        }

        private static PlotModel GraphPaper(string title, string ytitle, string yunit)
        {
            var plotModel1 = new PlotModel
            {
                PlotType = PlotType.Cartesian,
                Title = title,
                TitleFont = "Tahoma",
                TitleFontSize = 12,
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