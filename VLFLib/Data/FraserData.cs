using System;

namespace VLFLib.Data
{
    public class FraserData
    {
        public string Name;
        public int Count;
        public float Spacing;
        public float[] Distances;
        public float[] FraserValue;

        internal FraserData(string name, int count, float spacing, float[] distances, float[] fraserValue)
        {
            Name = name;
            Count = count;
            Spacing = spacing;
            Distances = distances;
            FraserValue = fraserValue;
        }

        public void Export(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
