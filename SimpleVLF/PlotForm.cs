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
    public partial class PlotForm : Form
    {
        public PlotForm(string title, TiltData data)
        {
            InitializeComponent();
            plotView1.Model = GraphPaper(title);
            AddSeries(data);
        }

        private void AddSeries(TiltData data)
        {
            var tiltSeries = new LineSeries {Title = "Tilt (%)"};

            for (var i = 0; i < data.Count; i++)
            {
                tiltSeries.Points.Add(new DataPoint(data.GetDistanceAt(i), data.GetTiltAt(i)));
            }

            plotView1.Model.Series.Add(tiltSeries);
        }

        public static PlotModel GraphPaper(string title)
        {
            var plotModel1 = new PlotModel {PlotType = PlotType.Cartesian, Title = title};
            var linearAxis1 = new LinearAxis
            {
                MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                Position = AxisPosition.Bottom,
                Title = "Distance (m)",
            };
            plotModel1.Axes.Add(linearAxis1);
            var linearAxis2 = new LinearAxis
            {
                MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
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