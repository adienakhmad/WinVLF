using System;

namespace VLFLib.Data
{
    [Serializable]
    public class TiltData: VLFDataBase
    {
        
        public bool IsAscending
        {
            get
            {
                for (var i = 0; i < Npts - 1; i++)
                {
                    if (Distances[i] > Distances[i + 1]) return false;
                }
                return true;
            }
        }

        public TiltData(string name, int n, float spacing, float[] distanceArray, float[] tiltdata) :base(name, n,spacing,distanceArray,tiltdata)
        {
          
        }


        public override void ExportToFile(string filename)
        {
            throw new NotImplementedException();
        }
    }
}