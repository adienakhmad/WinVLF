using System;
using System.Diagnostics;
using MathNet.Numerics.LinearAlgebra;

namespace VLFLib.Gridding
{
    public class Kriging
    {
        private readonly int _ndim;
        private readonly int _npt;
        private readonly Powvargram _powvargram;
        private readonly Matrix<float> _x;
        private readonly Vector<float> _vstar;
        private readonly Vector<float> _yvi;
        private double _lastval;

        public Kriging(Matrix<float> xx, Vector<float> yy, Powvargram vgram)
        {
            _x = xx;
            _powvargram = vgram;
            _npt = xx.RowCount;
            _ndim = xx.ColumnCount;
            _vstar = Vector<float>.Build.Dense(_npt + 1);
            _yvi = Vector<float>.Build.Dense(_npt + 1);

            var v = Matrix<float>.Build.Dense(_npt + 1, _npt + 1);
            Debug.WriteLine($"The size of matrix to be solved: {v.RowCount} x {v.ColumnCount}");
            var y = Vector<float>.Build.Dense(_npt + 1);

            for (var i = 0; i < _npt; i++)
            {
                y[i] = yy[i];
                for (var j = i; j < _npt; j++)
                {
                    v[i, j] = v[j, i] = Convert.ToSingle(vgram.Calc(CartesianDistance(_x, i, j)));
                }
                v[i, _npt] = v[_npt, i] = 1.0f;
            }
            v[_npt, _npt] = y[_npt] = 0f;
            Debug.WriteLine("LU Decomposing..");
            _yvi = v.LU().Solve(y);
        }

        public double Interpolate(Vector<float> points)
        {
            for (var i = 0; i < _npt; i++)
            {
                _vstar[i] = Convert.ToSingle(_powvargram.Calc(CartesianDistance(points, _x, i)));
            }
            _vstar[_npt] = 1.0f;
            _lastval = 0.0f;
            for (var i = 0; i <= _npt; i++)
            {
                _lastval += _yvi[i]*_vstar[i];
            }
            return _lastval;
        }

        private double CartesianDistance(Matrix<float> m, int indexa, int indexb)
        {
            var d = 0.0;
            for (var i = 0; i < _ndim; i++)
            {
                d += Math.Pow((m[indexa, i] - m[indexb, i]), 2);
            }

            return Math.Sqrt(d);
        }

        private double CartesianDistance(Vector<float> points, Matrix<float> x, int index)
        {
            var d = 0.0;
            for (var i = 0; i < _ndim; i++)
            {
                d += Math.Pow(points[i] - x[index, i], 2);
            }

            return Math.Sqrt(d);
        }
    }

    public class Powvargram
    {
        private readonly double _alpha;
        private readonly double _bet;
        private readonly double _nugsq;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="beta"></param>
        /// <param name="nugget"></param>
        public Powvargram(Matrix<float> x, Vector<float> y, float beta = 1.5f, float nugget = 0.0f)
        {
            _bet = beta;
            _nugsq = nugget*nugget;

            int npt = x.RowCount, ndim = x.ColumnCount;
            double num = 0.0f, denom = 0.0f;

            for (var i = 0; i < npt; i++)
            {
                for (var j = i + 1; j < npt; j++)
                {
                    double rb = 0.0f;
                    for (var k = 0; k < ndim; k++)
                    {
                        rb += Math.Pow(x[i, k] - x[j, k], 2);
                    }
                    rb = Math.Pow(rb, 0.5*beta);
                    num += rb*(0.5*Math.Pow(y[i] - y[j], 2) - _nugsq);
                    denom += Math.Pow(rb, 2);
                }
            }
            _alpha = num/denom;
        }

        public double Calc(double r)
        {
            return _nugsq + _alpha*Math.Pow(r, _bet);
        }
    }
}