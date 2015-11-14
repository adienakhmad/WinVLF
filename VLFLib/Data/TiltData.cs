using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace VLFLib.Data
{
    public class TiltData
    {
        public string Name;
        public int Count;
        public float Spacing;
        private readonly float[] _distances;
        private readonly float[] _tildata;
        private readonly bool _isAscending;

        public TiltData(string name, int n, float spacing, float[] distance, float[] tiltdata)
        {
            Name = name;
            Count = n;
            Spacing = spacing;
            _distances = distance;
            _tildata = tiltdata;
            _isAscending = CheckifAscending();
        }

        private bool CheckifAscending()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                if (_distances[i] > _distances[i + 1]) return false;
            }

            return true;
        }

        public bool IsAscending()
        {
            return _isAscending;
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

        public float MaxDistance()
        {
            return _distances.Max();
        }

        public float MinDistance()
        {
            return _distances.Min();
        }

        public float MaxTilt()
        {
            return _tildata.Max();
        }
        public float MinTilt()
        {
            return _tildata.Min();
        }
    }
}