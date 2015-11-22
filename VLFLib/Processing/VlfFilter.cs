using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VLFLib.Data;
using VLFLib.Gridding;

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

            var displacement = movDistance.First() - raw.Distances.First();
            var xy = Displacement.NextPoint(raw.X, raw.Y, raw.Bearing, displacement);

            return new TiltData($"{raw.Title}_smooth",npt-fLen,raw.Spacing,xy[0],xy[1],raw.Bearing,movDistance,movVal);
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

            var displacement = fraserDist.First() - raw.Distances.First();
            var xy = Displacement.NextPoint(raw.X, raw.Y, raw.Bearing, displacement);
            return new FraserData(raw.Title, count - 3, raw.Spacing,xy[0],xy[1],raw.Bearing, fraserDist, fraserVal);
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

            var displacement = 3*raw.Spacing;
            var xy = Displacement.NextPoint(raw.X, raw.Y, raw.Bearing, displacement);

            return new KarousHjeltData(raw.Title, raw.Spacing, raw.Npts, skindepth, depthStep, xy[0], xy[1], raw.Bearing, distList.ToArray(),
                depthList.ToArray(), khList.ToArray());
        }
    }
}