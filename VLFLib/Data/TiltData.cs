using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace VLFLib.Data
{
    [Serializable]
    public class TiltData
    {
        public string Name;
        public int Count { get; }
        public float Spacing { get; }

        public float[] DistancesArray { get; }

        public float[] Tildata { get; }

        public bool IsAscending
        {
            get
            {
                for (var i = 0; i < Count - 1; i++)
                {
                    if (DistancesArray[i] > DistancesArray[i + 1]) return false;
                }
                return true;
            }
        }

        public TiltData(string name, int n, float spacing, float[] distanceArray, float[] tiltdata)
        {
            Name = name;
            Count = n;
            Spacing = spacing;
            DistancesArray = distanceArray;
            Tildata = tiltdata;
            
        }

        private bool CheckifAscending()
        {
            for (var i = 0; i < Count - 1; i++)
            {
                if (DistancesArray[i] > DistancesArray[i + 1]) return false;
            }

            return true;
        }

        public void Export(string filename)
        {
            throw new NotImplementedException();
        }

        public float GetDistanceAt(int index)
        {
            return DistancesArray[index];
        }

        public float GetTiltAt(int index)
        {
            return Tildata[index];
        }

        public float MaxDistance()
        {
            return DistancesArray.Max();
        }

        public float MinDistance()
        {
            return DistancesArray.Min();
        }

        public float MaxTilt()
        {
            return Tildata.Max();
        }
        public float MinTilt()
        {
            return Tildata.Min();
        }
    }
}