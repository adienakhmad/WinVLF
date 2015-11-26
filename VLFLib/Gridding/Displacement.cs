using System;
using MathNet.Numerics;

namespace VLFLib.Gridding
{
    public static class Displacement
    {
        public static float[] NextPoint(float x, float y, float a, float dist)
        {
            var newx = x + (Trig.Sin(Trig.DegreeToRadian(a))*dist);
            var newy = y + (Trig.Cos(Trig.DegreeToRadian(a))*dist);
            
            return new[] {Convert.ToSingle(newx), Convert.ToSingle(newy)};
        }
    }
}
