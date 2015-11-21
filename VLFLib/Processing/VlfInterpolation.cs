using System;
using System.Linq;
using MathNet.Numerics.Interpolation;
using VLFLib.Data;

namespace VLFLib.Processing
{
    public class VlfInterpolation
    {
        public static TiltData CubicSplineNatural(TiltData raw, float spacing, int n)
        {
            var xmin = raw.Distances.Min();
            var npt = n;

            var newdistances = new float[npt];
            var newtilt = new float[npt];

            var interpolator = CubicSpline.InterpolateNaturalSorted(Array.ConvertAll(raw.Distances,Convert.ToDouble),Array.ConvertAll(raw.Values,Convert.ToDouble));
            for (var i = 0; i < npt; i++)
            {
                newdistances[i] = xmin + (i*spacing);
                newtilt[i] = Convert.ToSingle(interpolator.Interpolate(Convert.ToDouble(newdistances[i])));
            }

            return new TiltData(raw.Name,npt,spacing,newdistances,newtilt);
        }
    }
}
