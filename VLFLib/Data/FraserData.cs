using System;

namespace VLFLib.Data
{
    [Serializable]
    public class FraserData
    {
        public string Name { get; set; }
        public int Count { get; private set; }
        public float Spacing { get; private set; }
        public float[] Distances { get; private set; }
        public float[] FraserValue { get; private set; }

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
