using System;
using System.ComponentModel;

namespace VLFLib.Data
{
    [Serializable, DefaultProperty("Title")]
    public abstract class VLFBasicData
    {
        [CategoryAttribute("Basic Info"), DescriptionAttribute("Title that will be used to display on plot. Re-plotting is required.")]
        public string Title { get; set; }

        [ReadOnlyAttribute(true), CategoryAttribute("Basic Info"), 
            DescriptionAttribute("The total number of data points in this object.")]
        public int Npts { get; }

        [ReadOnlyAttribute(true), CategoryAttribute("Basic Info"), 
            DescriptionAttribute("Interval between data points (in metres).")]
        public float Spacing { get; private set; }

        [BrowsableAttribute(false)]
        public float[] Distances { get; private set; }

        [BrowsableAttribute(false)]
        public float[] Values { get; }

        [CategoryAttribute("Survey Geometry"), DescriptionAttribute("The X-Coordinate (Easting) of the first data point.")]
        public float X { get; set; }

        [CategoryAttribute("Survey Geometry"), DescriptionAttribute("The Y-Coordinate (Northing) of the first data point.")]
        public float Y { get; set; }

        [CategoryAttribute("Survey Geometry"), DescriptionAttribute("The direction of profile measured in degree azimuth.")]
        public float Bearing { get; set; }

        protected VLFBasicData(string title, int npt, float spacing, float x, float y, float a, float[] distances,
            float[] values)
        {
            Title = title;
            Npts = npt;
            Spacing = spacing;
            Distances = distances;
            Values = values;
            X = x;
            Y = y;
            Bearing = a;
        }

        public void Rename(string newname)
        {
            Title = newname;
        }

        public virtual void ReverseSign()
        {
            for (var i = 0; i < Npts; i++)
            {
                Values[i] *= -1;
            }
        }

        public virtual void FlipDistance()
        {
            Array.Reverse(Values);
            if (Bearing < 180)
            {
                Bearing += 180;
            }
            else if (Bearing >= 180)
            {
                Bearing -= 180;
            }
        }

        public virtual void FlipThenReverse()
        {
            FlipDistance();
            ReverseSign();
        }

        public void SetCoordinate(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void SetAzimuth(float az)
        {
            Bearing = az;
        }

        public abstract void ExportToFile(string filename);
    }
}