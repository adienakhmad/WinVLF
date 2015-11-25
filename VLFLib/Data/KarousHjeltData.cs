using System;
using System.ComponentModel;
using System.IO;
using VLFLib.Gridding;

namespace VLFLib.Data
{
    [Serializable]
    public class KarousHjeltData:VLFBasicData
    {
        [BrowsableAttribute(false)]
        public int RawLength { get; private set; }
        [BrowsableAttribute(false)]
        public bool IsNormalized { get; private set; }
        [DescriptionAttribute("Electromagnetic skin depth used to normalize this pseudosection."),CategoryAttribute("Enhancement")]
        public float SkinDepth { get; private set; }
        [BrowsableAttribute(false)]
        public int DepthLevel { get; private set; }
        [BrowsableAttribute(false)]
        public float[] Depths { get; private set; }

        
        public KarousHjeltData(string title, float spacing, int rawlength, float skindepth, int dlevel,float x, float y, float a, float[] distArray, float[] depths,
            float[] kharray):base(title,distArray.Length,spacing,x,y,a,distArray,kharray)
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
            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine($"WinVLF - Karous Hjelt Filtered Out File");
                writer.WriteLine($"{Title}");
                writer.WriteLine($"npt: {Npts}, skin: {SkinDepth}");
                writer.WriteLine($"X0,Y0: {X},{Y}, bearing: N {Bearing} °E");
                writer.WriteLine($"distance,depth,kh");
                for (var i = 0; i < Npts; i++)
                {
                    writer.WriteLine($"{Distances[i]}\t{Depths[i]}\t{Values[i]}");
                }
            }
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
