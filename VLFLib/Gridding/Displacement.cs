using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VLFLib.Gridding
{
    public static class Displacement
    {
        public static float[] NextPoint(float x, float y, float a, float dist)
        {
            var newx = x + (Math.Sin(ToRadian(a))*dist);
            var newy = y + (Math.Cos(ToRadian(a))*dist);

            return new[] {Convert.ToSingle(newx), Convert.ToSingle(newy)};
        }

        private static double  ToRadian(float degree)
        {
            return (Math.PI/180)*degree;
        }
    }
}
