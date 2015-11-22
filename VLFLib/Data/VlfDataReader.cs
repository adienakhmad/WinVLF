using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace VLFLib.Data
{
    public static class VLFDataReader
    {
        static public TiltData Read(string filename)
        {
            int n;
            var reader = new StreamReader(filename);
            // Read title first
            var title = reader.ReadLine();

            // Read position information
            var location = reader.ReadLine();

            // Parse the position
            var xya = location.Split(new []{'\t',' '},StringSplitOptions.RemoveEmptyEntries);
            float x, y, a;
            float.TryParse(xya[0], out x);
            float.TryParse(xya[1], out y);
            float.TryParse(xya[2], out a);

            int.TryParse(reader.ReadLine(), out n);
            var distances = new float[n];
            var tiltdata = new float[n];


            for (var i = 0; i < n; i++)
            {
                var s = reader.ReadLine();
                var ss = s.Split('\t');
                float dist, val;
                float.TryParse(ss[0], out dist);
                float.TryParse(ss[1], out val);

                distances[i] = dist;
                tiltdata[i] = val;

            }

            reader.Close();

            
            Array.Sort(distances,tiltdata);
            Array.Sort(distances);
            for (int i = 0; i < distances.Length; i++)
            {
                Debug.WriteLine($"{distances[i]},{tiltdata[i]}");
            }
            var spacing = (distances.Last() - distances.First())/ (n-1);
            return new TiltData(title, n, spacing,x,y,a, distances, tiltdata);
        }
    }
}
