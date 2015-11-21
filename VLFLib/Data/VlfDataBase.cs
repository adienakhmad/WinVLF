using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VLFLib.Data
{
    public  abstract class VlfDataBase
    {
        public string Name { get; private set; }
        public int Npts { get; private set; }
        public float Spacing { get; private set; }
        public float[] Distances { get; private set; }
        public float[] Values { get; private set; }

        protected VlfDataBase(string name, int npt, float spacing, float[] distances, float[] values)
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

        public abstract void ExportToFile(string filename);

    }
}
