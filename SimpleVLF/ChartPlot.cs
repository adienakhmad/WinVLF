using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        public ChartPlot(string title, KarousHjeltData kh)
        {
            InitializeComponent();
            plotView1.Model = MultiGraphPaper(title, "Z", "%", kh.DepthLevel);
            AddSampleSeries();
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

        private void AddSeries(KarousHjeltData kh)
        {
            for (var i = 0; i < kh.DepthLevel; i++)
            {
                var key = $"D{i}";
                var series = new LineSeries
                {
                    Title = "Tilt (%)",
                    MarkerType = MarkerType.Circle,
                    MarkerFill = OxyColors.DarkViolet,
                    Color = OxyColors.DarkViolet,
                    XAxisKey = "Dx",
                    YAxisKey = key
                };

                for (int j = 0; j < kh.KarousHjeltArray.Length; j++)
                {
                    if (Math.Abs(kh.DepthArray[i] - (-((i+1)*kh.Spacing))) > 1e-5)
                    {
                        
                    }
                }


                plotView1.Model.Series.Add(series);
            }
        }

        private void AddSampleSeries()
        {
            for (int i = 0; i < 5; i++)
            {
                var key = $"D{i}";
                var series = new LineSeries
                {
                    Title = "Tilt (%)",
                    MarkerType = MarkerType.Circle,
                    MarkerFill = OxyColors.DarkViolet,
                    Color = OxyColors.DarkViolet
                };

                series.Points.Add(new DataPoint(0,0));
                series.XAxisKey = "Dx";
                series.YAxisKey = key;
                plotView1.Model.Series.Add(series);
            }
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

        private static PlotModel MultiGraphPaper(string title, string ytitle, string yunit, int n)
        {
            var plotmodel1 = new PlotModel()
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
                Key = "Dx"
            };
            plotmodel1.Axes.Add(linearAxis1);

            var splitter = 1.0/n;
            var startpos = 0.0;
            var endpos = 1.0/n;
            for (var i = 0; i < n; i++)
            {
                var key = $"D{i}";
                
                var linearAxis2 = new LinearAxis
                {
                    MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139),
                    MajorGridlineStyle = LineStyle.Solid,
                    MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                    MinorGridlineStyle = LineStyle.Solid,
                    Title = ytitle + $"{n - i}",
                    StartPosition = startpos,
                    EndPosition = endpos,
                    Unit = yunit,
                    Key = key
                    
                };
                Debug.Write("StartPosition: ");
                Debug.WriteLine(startpos);
                startpos = endpos + (splitter/10);
                endpos += splitter;
                plotmodel1.Axes.Add(linearAxis2);
            }

            return plotmodel1;
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