using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace VLFLib.Data
{
    public static class VLFDataReader
    {
        static public TiltData Read(string filename)
        {
            int n;
            var reader = new StreamReader(filename);
            var title = reader.ReadLine();
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
            return new TiltData(title, n, spacing, distances, tiltdata);
        }
    }
}
