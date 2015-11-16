using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using VLFLib.Data;

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

        private void AddSeries(FraserData data)
        {
            var fraserSeries = new LineSeries
            {
                Title = "Tilt (%)",
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

        private static PlotModel GraphTilt(string title)
        {
            return GraphPaper("Real Comp - " + title, "Tilt Angle", "%");
        }

        private static PlotModel GraphFraser(string title)
        {
            return GraphPaper("Fraser - "+ title, "Fraser Value", "%");
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
                IsLegendVisible = false
            };
            var linearAxis1 = new LinearAxis
            {
                MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                Position = AxisPosition.Bottom,
                Title = "Distance",
                Unit = "m",
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
    }
}