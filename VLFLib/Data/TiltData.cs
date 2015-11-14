using System;
using System.Runtime.InteropServices;

namespace VLFLib.Data
{
    public class TiltData
    {
        public string Name;
        public int Count;
        public float Spacing;
        private float[] _distances;
        private float[] _tildata;

        public TiltData(string name, int n, float[] distance, float[] tiltdata)
        {
            Name = name;
            Count = n;
            _distances = distance;
            _tildata = tiltdata;
        }

        public void Export(string filename)
        {
            throw new NotImplementedException();
        }

        public float GetDistanceAt(int index)
        {
            return _distances[index];
        }

        public float GetTiltAt(int index)
        {
            return _tildata[index];
        }
    }
}