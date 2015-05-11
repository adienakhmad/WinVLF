using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Simple_VLF
{
    static class VLF_Filter
    {
        public static double SkinDepth;
        public static VLF_EMComponent EMComponent;
        public static BindingList<VLF_FraserRecord> Fraser(BindingList<VLF_SurveyRecord> input, object component)
        {
            var fraserOutput = new BindingList<VLF_FraserRecord>();
            
            
            for (int i = 0; i < (input.Count - 3); i++)
            {
                var distances = new double[4];
                var value = new double[4];

                if (component == VLF_EMComponents.Real) // use real component
                {
                    for (int j = 0; j < 4; j++)
                    {
                        distances[j] = input[i + j].Distance;
                        value[j] = input[i + j].Tilt;
                    }
                }
                else // use imaginary component
                {
                    for (int j = 0; j < 4; j++)
                    {
                        distances[j] = input[i + j].Distance;
                        value[j] = input[i + j].Ellips;
                    }
                }
                

                var midPoint = FraserMidPoint(distances);
                var fraserValue = CalculateFraser(value);
                fraserOutput.Add(new VLF_FraserRecord(midPoint,fraserValue));
            }

            return fraserOutput;

        }

        public static BindingList<VLF_KarousHjeltRecord> KarousHjelt(BindingList<VLF_SurveyRecord> input, object selectedItem, double skinDepth, double spacing)
        {
            EMComponent = (VLF_EMComponent) selectedItem;
            SkinDepth = skinDepth;
            var khOutput = new BindingList<VLF_KarousHjeltRecord>();

            const double a = 0.1025;
            const double b = 0.0590;
            const double c = 0.5615;

            var m = input.Count/6;
            var x0 = input[0].Distance; // minimum distance
            var n = input.Count;


            for (int i = 0; i < m; i++)
            {
                var k = i + 1;
                var na = k * 3;
                var nl = n - (k*3);
                var xx = x0 + (3*k*spacing);

                for (int j = na; j < nl; j++)
                {
                    var i1 = j - (3*k);
                    var i2 = j - (2*k);
                    var i3 = j - k;
                    var i4 = j + k;
                    var i5 = j + (2*k);
                    var i6 = j + (3*k);

                    double h1, h2, h3, h4, h5, h6;

                    if (selectedItem == VLF_EMComponents.Real) // use real component
                    {
                        h1 = input[i1].Tilt;
                        h2 = input[i2].Tilt;
                        h3 = input[i3].Tilt;
                        h4 = input[i4].Tilt;
                        h5 = input[i5].Tilt;
                        h6 = input[i6].Tilt;
                    }
                    else // use imaginary
                    {
                        h1 = input[i1].Ellips;
                        h2 = input[i2].Ellips;
                        h3 = input[i3].Ellips;
                        h4 = input[i4].Ellips;
                        h5 = input[i5].Ellips;
                        h6 = input[i6].Ellips;
                    }
                    

                    var distance = xx + ((j - na) * spacing);
                    var depth = -k * spacing;
                    var value = (a * h1) + (-b * h2) + (c * h3) + (-c * h4) + (b * h5) + (-a * h6);

                    if (!skinDepth.Equals(0))
                    {
                        var dz = Math.Exp(-k * Math.Abs(spacing) / skinDepth);
                        value = value * dz;
                    }

                    khOutput.Add(new VLF_KarousHjeltRecord(distance,depth,value));
                }

            }

            return khOutput;
        } 

        private static double FraserMidPoint(IEnumerable<double> distance)
        {
            return distance.Average();
        }

        private static double CalculateFraser(IList<double> d )
        {
            var result = d[0] + d[1] - d[2] - d[3];

            return result;
        }
    }
}
