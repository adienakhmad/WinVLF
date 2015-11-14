using System;

namespace VLFLib.Data
{
    class FraserData
    {
        public string Name;
        public float[] Distances;
        public float[] Data;

        internal FraserData(string name, float[] distances, float[] data)
        {
            Name = name;
            Distances = distances;
            Data = data;
        }

        public void Export(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
