using System.Collections.Generic;
using System.Linq;
using VLFLib.Data;

namespace VLFLib.Gridding
{
    public class Surface2D
    {
        public float[] XValues { get; }
        public float[] YValues { get; }
        public float[] ZValues { get; }

        public int Npts { get; set; }

        public Surface2D(ICollection<VLFDataBase> datas)
        {
            Npts = datas.Sum(data => data.Npts);

            XValues = new float[Npts];
            YValues = new float[Npts];
            ZValues = new float[Npts];

            var count = 0;
            foreach (var data in datas)
            {
                for (var i = 0; i < data.Npts; i++)
                {
                    var xy = Displacement.NextPoint(data.X, data.Y, data.Bearing, data.Spacing*(i - 1));
                    XValues[count] = xy[0];
                    YValues[count] = xy[1];
                    ZValues[count] = data.Values[i];
                    count++;
                }
            }
        }
    }
}