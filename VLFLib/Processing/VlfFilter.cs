using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VLFLib.Data;

namespace VLFLib.Processing
{
    public static class VlfFilter
    {
        public static TiltData MovingAverage(TiltData raw, int order)
        {
            var npt = raw.Npts;
            var fLen = order - 1;
            var movDistance = new float[npt -fLen];
            var movVal = new float[npt- fLen];

            for (int i = 0; i < npt-fLen; i++)
            {
                var dist = new float[order];
                var val = new float[order];

                for (int j = 0; j < order; j++)
                {
                    dist[j] = raw.Distances[i+j];
                    val[j] = raw.Values[i + j];
                }

                movDistance[i] = dist.Average();
                movVal[i] = val.Average();
            }

            return new TiltData($"{raw.Name}_smooth",npt-fLen,raw.Spacing,movDistance,movVal);
        }
        public static FraserData Fraser(TiltData raw)
        {
            var count = raw.Npts;
            var fraserDist = new float[count - 3];
            var fraserVal = new float[count - 3];

            for (var i = 0; i < count - 3; i++)
            {
                var distanceInput = new float[4];
                var valueInput = new float[4];
                for (var j = 0; j < 4; j++)
                {
                    distanceInput[j] = raw.Distances[i+j];
                    valueInput[j] = raw.Values[i + j];
                }

                fraserDist[i] = distanceInput.Average();
                fraserVal[i] = (valueInput[0] + valueInput[1] - valueInput[2] - valueInput[3]);
            }

            Debug.Write("Fraser count: ");
            Debug.WriteLine(count - 3);

            return new FraserData(raw.Name, count - 3, raw.Spacing, fraserDist, fraserVal);
        }

        public static KarousHjeltData KarousHjelt(TiltData raw, float skindepth)
        {
            var distList = new List<float>();
            var depthList = new List<float>();
            var khList = new List<float>();


            const float a = 0.1025f;
            const float b = 0.0590f;
            const float c = 0.5615f;


            var x0 = raw.Distances[0];
            var n = raw.Npts;
            var depthStep = n/6;

            for (var i = 0; i < depthStep; i++)
            {
                var k = i + 1;
                var na = k*3;
                var nl = n - na;
                var xx = x0 + (na*raw.Spacing);
                for (var j = na; j < nl; j++)
                {
                    var i1 = j - (k*3);
                    var i2 = j - (k*2);
                    var i3 = j - (k);
                    var i4 = j + (k);
                    var i5 = j + (k*2);
                    var i6 = j + (k*3);

                    var h1 = raw.Values[i1];
                    var h2 = raw.Values[i2];
                    var h3 = raw.Values[i3];
                    var h4 = raw.Values[i4];
                    var h5 = raw.Values[i5];
                    var h6 = raw.Values[i6];
                    
                    var distance = xx + ((j - na)*raw.Spacing);
                    var depth = -k*raw.Spacing;
                    var value = (a*h1) + (-b*h2) + (c*h3) + (-c*h4) + (b*h5) + (-a*h6);

                    if (!skindepth.Equals(0))
                    {
                        var dz = Math.Exp(-k*Math.Abs(raw.Spacing)/skindepth);
                        value = value*Convert.ToSingle(dz);
                    }

                    distList.Add(distance);
                    depthList.Add(depth);
                    khList.Add(value);
                }
            }

            return new KarousHjeltData(raw.Name, raw.Spacing, raw.Npts, skindepth, depthStep, distList.ToArray(),
                depthList.ToArray(), khList.ToArray());
        }
    }
}