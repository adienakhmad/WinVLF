using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VLFLib.Data
{
    public  abstract class VLFDataBase
    {
        public string Name { get; private set; }
        public int Npts { get; private set; }
        public float Spacing { get; private set; }
        public float[] Distances { get; private set; }
        public float[] Values { get; private set; }

        protected VLFDataBase(string name, int npt, float spacing, float[] distances, float[] values)
        {
            Name = name;
            Npts = npt;
            Spacing = spacing;
            Distances = distances;
            Values = values;
        }
        public void Rename(string newname)
        {
            Name = newname;
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
        }

        public virtual void FlipThenReverse()
        {
            FlipDistance();
            ReverseSign();
        }

        public abstract void ExportToFile(string filename);

    }
}
