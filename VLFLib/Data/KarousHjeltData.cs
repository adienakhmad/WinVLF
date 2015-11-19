using System;

namespace VLFLib.Data
{
    [Serializable]
    public class KarousHjeltData
    {
        public string Name { get; set; }
        public float Spacing { get; private set; }
        public int RawLength { get; private set; }
        public bool IsNormalized { get; private set; }
        public float SkinDepth { get; private set; }
        public int DepthLevel { get; private set; }

        public float[] DistanceArray { get; private set; }

        public float[] DepthArray { get; private set; }

        public float[] KarousHjeltArray { get; private set; }

        public KarousHjeltData(string name, float spacing, int rawlength, float skindepth, int dlevel,float[] distArray, float[] depthArray,
            float[] kharray)
        {
            Name = name;
            Spacing = spacing;
            SkinDepth = skindepth;
            RawLength = rawlength;
            DepthLevel = dlevel;
            DistanceArray = distArray;
            DepthArray = depthArray;
            KarousHjeltArray = kharray;

            if (skindepth > 0)
            {
                IsNormalized = true;
            }

        }

        public void Export(string filename)
        {
            throw new NotImplementedException();
        }

    }
}
