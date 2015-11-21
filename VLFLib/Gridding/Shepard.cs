using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace VLFLib.Gridding
{
    public class Shepard
    {
        private readonly int _dim;
        private readonly int _n;
        private readonly Matrix<float> _pts;
        private readonly Vector<float> _vals;
        private readonly float _pneg;

        public Shepard(Matrix<float> ptss, Vector<float> valss, float p = 2f)
        {
            _dim = ptss.ColumnCount;
            _n = ptss.RowCount;
            _pts = ptss;
            _vals = valss;
            _pneg = -p;
        }

        public float Interpolate(Vector<float> pt)
        {
            var sum = 0.0;
            var sumw = 0.0;

            if (pt.Count != _dim)
            {
                throw new Exception("bad points size");
            }

            for (int i = 0; i < _n; i++)
            {
                double r = Convert.ToSingle(CartesianDistance(pt, _pts, i));
                if (Math.Abs(r) < 1e-12)
                {
                    return _vals[i];
                }
                double w;
                sum += (w = Math.Pow(r, _pneg));
                sumw += w*_vals[i];
            }
            return Convert.ToSingle(sumw/sum);
        }

        private double CartesianDistance(Matrix<float> m, int indexa, int indexb)
        {
            var d = 0.0;
            for (var i = 0; i < _dim; i++)
            {
                d += Math.Pow((m[indexa, i] - m[indexb, i]), 2);
            }

            return Math.Sqrt(d);
        }

        private double CartesianDistance(Vector<float> points, Matrix<float> x, int index)
        {
            var d = 0.0;
            for (var i = 0; i < _dim; i++)
            {
                d += Math.Pow(points[i] - x[index, i], 2);
            }

            return Math.Sqrt(d);
        }
    }
}
