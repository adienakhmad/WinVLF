using System;
using System.Collections.Generic;
using System.Linq;
using VLFLib.Data;

namespace VLFLib.Filter
{
    internal static class VlfFilter
    {
        public static FraserData Fraser(TiltData raw)
        {
            var count = raw.Count;
            var fraserDist = new float[count];
            var fraserVal = new float[count];

            for (var i = 0; i < count - 3; i++)
            {
                var distanceInput = new float[4];
                var valueInput = new float[4];
                for (var j = 0; j < 4; j++)
                {
                    distanceInput[j] = raw.GetDistanceAt(i + j);
                    valueInput[j] = raw.GetTiltAt(i + j);
                }

                fraserDist[i] = distanceInput.Average();
                fraserVal[i] = valueInput[0] + valueInput[1] - valueInput[2] - valueInput[3];
            }

            return new FraserData(raw.Name, fraserDist, fraserVal);
        }

        public static KarousHjeltData KarousHjelt(TiltData raw, float skindepth)
        {
            var distList = new List<float>();
            var depthList = new List<float>();
            var khList = new List<float>();


            const float a = 0.1025f;
            const float b = 0.0590f;
            const float c = 0.05615f;


            var x0 = raw.GetDistanceAt(0);
            var n = raw.Count;
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

                    float h1 = raw.GetTiltAt(i1);
                    float h2 = raw.GetTiltAt(i2);
                    float h3 = raw.GetTiltAt(i3);
                    float h4 = raw.GetTiltAt(i4);
                    float h5 = raw.GetTiltAt(i5);
                    float h6 = raw.GetTiltAt(i6);

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

            return new KarousHjeltData(raw.Name,raw.Spacing,skindepth,distList.ToArray(),depthList.ToArray(),khList.ToArray());
        }
    }
}