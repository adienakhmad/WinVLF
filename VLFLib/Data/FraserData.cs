using System;
using System.IO;
using VLFLib.Gridding;

namespace VLFLib.Data
{
    [Serializable]
    public class FraserData : VLFDataBase
    {
        
        internal FraserData(string title, int count, float spacing, float x, float y, float a, float[] distances, float[] fraserValue): base(title,count,spacing,x,y,a,distances,fraserValue)
        {
            
        }

        public override void ExportToFile(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine($"WinVLF - Fraser Out File");
                writer.WriteLine($"{Title}");
                writer.WriteLine($"npt: {Npts}, bearing: N {Bearing} °E");
                writer.WriteLine($"distance,fraser,x-coor,y-coor");
                for (var i = 0; i < Npts; i++)
                {
                    var xy = Displacement.NextPoint(X, Y, Bearing, (i * Spacing));
                    writer.WriteLine($"{Distances[i]}\t{Values[i]}\t{xy[0]}\t{xy[1]}");
                }
            }
        }
    }
}
