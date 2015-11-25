using System;
using System.IO;
using System.Linq;
using VLFLib.Gridding;

namespace VLFLib.Data
{
    [Serializable]
    public class TiltData: VLFBasicData
    {
        public TiltData(string title, int n, float spacing, 
            float xcoor, float ycoor, float azimuth, float[] distanceArray, float[] tiltdata) 
            :base(title, n,spacing,xcoor,ycoor,azimuth,distanceArray,tiltdata)
        {
            
        }

        public TiltData Copy()
        {
            return new TiltData(Title,Npts,Spacing,X,Y,Bearing,Distances.ToArray(),Values.ToArray());
        }
        public override void ExportToFile(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine($"WinVLF - VLF Tilt Angle Out File");
                writer.WriteLine($"{Title}");
                writer.WriteLine($"npt: {Npts}, bearing: N {Bearing} °E");
                writer.WriteLine($"distance,tilt-angle,x-coor,y-coor");
                for (var i = 0; i < Npts; i++)
                {
                    var xy = Displacement.NextPoint(X, Y, Bearing, (i*Spacing));
                    writer.WriteLine($"{Distances[i]}\t{Values[i]}\t{xy[0]}\t{xy[1]}");
                }
            }
        }

        public override string ToString()
        {
            var str = $"Name: {Title}{Environment.NewLine}" +
                      $"Spacing: {Spacing} m{Environment.NewLine}" +
                      $"X,Y,a: {X},{Y},{Bearing}";
            return str;
        }
    }
}