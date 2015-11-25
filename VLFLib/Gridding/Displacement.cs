using System;
using System.Diagnostics;

namespace VLFLib.Gridding
{
    public static class Displacement
    {
        public static float[] NextPoint(float x, float y, float a, float dist)
        {
            var newx = x + (Math.Sin(ToRadian(a))*dist);
            var newy = y + (Math.Cos(ToRadian(a))*dist);

            Debug.WriteLine($"{Math.Sin(ToRadian(a))},{Math.Cos(ToRadian(a))},{newx},{newy},{Convert.ToSingle(newx)},{Convert.ToSingle(newy)}");

            return new[] {Convert.ToSingle(newx), Convert.ToSingle(newy)};
        }

        private static double  ToRadian(float degree)
        {
            return (Math.PI/180)*degree;
        }
    }
}
