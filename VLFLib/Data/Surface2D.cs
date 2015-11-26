using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using VLFLib.Gridding;
using VLFLib.Processing;

namespace VLFLib.Data
{
    [Serializable]
    public class Surface2D
    {
        [Category("Basic Info"),
         Description(
             "Title that will be used to display on plot. Re-plotting is required.")]
        public string Title { get; set; }

        [Browsable(false)]
        public string Subtitle { get; set; }

        [Browsable(false)]
        public string XAxisTitle { get; set; }

        [Browsable(false)]
        public string YAxisTitle { get; set; }

        [Browsable(false)]
        public string ZAxisTitle { get; set; }

        [Browsable(false)]
        public string XUnit { get; set; }

        [Browsable(false)]
        public string YUnit { get; set; }

        [Browsable(false)]
        public string ZUnit { get; set; }

        [Browsable(false)]
        public float[] XValues { get; private set; }

        [Browsable(false)]
        public float[] YValues { get; private set; }

        [Browsable(false)]
        public float[] ZValues { get; private set; }

        [Browsable(false)]
        public int Nx { get; private set; }

        [Browsable(false)]
        public int Ny { get; private set; }

        [Browsable(false)]
        public float Dx { get; private set; }

        [Browsable(false)]
        public float Dy { get; private set; }

        [ReadOnly(true), Category("Basic Info"),
         Description("The total number of data points used to create this object.")]
        public int Npts { get; private set; }

        [Browsable(false)]
        public SurfaceType SurfType { get; }

        [Browsable(false)]
        public FilterType FiltType { get; private set; }


        /// <summary>
        /// Constructor to build a 2D Surface
        /// </summary>
        /// <param name="tilts">The tilt data that is going to be gridded.</param>
        /// <param name="filterType">VLF Filter to be used.</param>
        public Surface2D(IList<TiltData> tilts, FilterType filterType)
        {
            SurfType = SurfaceType.Surface;
            // Decide which filter to use
            switch (filterType)
            {
                case FilterType.Fraser:
                    BuildUsingFraser(tilts);
                    break;
                case FilterType.KarousHjelt:
                    BuildUsingKH(tilts);
                    break;
            }
        }

        /// <summary>
        /// Constructor To Build 2D Pseudosections
        /// </summary>
        /// <param name="kh"></param>
        public Surface2D(KarousHjeltData kh)
        {
            SurfType = SurfaceType.Pseudosections;
            Title = kh.Title;
            Subtitle = $"dx: {kh.Spacing}m, skin depth: {kh.SkinDepth}m, bearing: N {kh.Bearing}° E";
            XUnit = "m";
            YUnit = "m";
            ZUnit = "%";
            XAxisTitle = "Distance";
            YAxisTitle = "Depth";
            ZAxisTitle = "KH";
            XValues = kh.Distances.ToArray();
            YValues = kh.Depths.ToArray();
            ZValues = kh.Values.ToArray();
            Npts = kh.Npts;
            CalcGridSize();
        }

        private void BuildUsingFraser(IList<TiltData> tilts)
        {
            FiltType = FilterType.Fraser;
            ZAxisTitle = "Fraser";
            ZUnit = "%";
            var x = new List<float>();
            var y = new List<float>();
            var z = new List<float>();

            foreach (var fraser in tilts.Select(VlfFilter.Fraser))
            {
                for (var i = 0; i < fraser.Npts; i++)
                {
                    var xy = Displacement.NextPoint(fraser.X, fraser.Y, fraser.Bearing, fraser.Spacing*(i - 1));
                    x.Add(xy[0]);
                    y.Add(xy[1]);
                    z.Add(fraser.Values[i]);
                }
            }

            Npts = x.Count;
            XValues = new float[x.Count];
            YValues = new float[y.Count];
            ZValues = new float[z.Count];

            XValues = x.ToArray();
            YValues = y.ToArray();
            ZValues = z.ToArray();

            CalcGridSize();
        }

        private void CalcGridSize()
        {
            var xmax = XValues.Max();
            var ymax = YValues.Max();
            var xmin = XValues.Min();
            var ymin = YValues.Min();

            // Calculate axis range
            var xrange = Math.Abs(xmax - xmin);
            var yrange = Math.Abs(ymax - ymin);

            if (xrange > yrange)
            {
                // Determine spacing with nx points grid
                Nx = 200;
                Dx = xrange/(Nx - 1);

                // Determine number of y grid so that the space is equal
                Ny = Convert.ToInt32(Math.Ceiling(yrange/Dx));
                Dy = yrange/(Ny - 1);
            }
            else
            {
                Ny = 200;
                Dy = yrange/(Ny - 1);

                Nx = Convert.ToInt32(Math.Ceiling(xrange/Dy));
                Dx = xrange/(Nx - 1);
            }
        }

        private void BuildUsingKH(ICollection<TiltData> tilts)
        {
            FiltType = FilterType.KarousHjelt;
            ZAxisTitle = "KH";
            ZUnit = "%";
            throw new NotImplementedException();
        }

        public enum FilterType
        {
            Fraser,
            KarousHjelt
        }

        public enum SurfaceType
        {
            Pseudosections,
            Surface
        }
    }
}