using System;

namespace VLFLib.Data
{
    [Serializable]
    public class KarousHjeltData:VLFDataBase
    {
        public int RawLength { get; private set; }
        public bool IsNormalized { get; private set; }
        public float SkinDepth { get; private set; }
        public int DepthLevel { get; private set; }

        public float[] Depths { get; private set; }

        
        public KarousHjeltData(string name, float spacing, int rawlength, float skindepth, int dlevel,float[] distArray, float[] depths,
            float[] kharray):base(name,distArray.Length,spacing,distArray,kharray)
        {
            SkinDepth = skindepth;
            RawLength = rawlength;
            DepthLevel = dlevel;
            Depths = depths;
            
            if (skindepth > 0)
            {
                IsNormalized = true;
            }

        }

        public override void ExportToFile(string filename)
        {
            throw new NotImplementedException();
        }

        
        public override void FlipDistance()
        {
            throw new Exception("Karous Hjelt data cannot be flipped.");
        }

        public override void FlipThenReverse()
        {
            throw new Exception("Karous Hjelt data cannot be flipped.");
        }
    }
}
