using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.Interpolation;

namespace vJMPS.Core
{
    public class ChartSeries
    {
        private double[] xValues;
        private double[] yValues;
        private int minX, maxX;
        private bool hasConstraints;
        private IInterpolation interpolation;

        public bool HasConstraints
        {
            get
            {
                return hasConstraints;
            }
         }

        public ChartSeries(double[] xValues,double[] yValues,int minX = 0,int maxX = 0, bool constrained = false)
        {
            this.xValues = xValues;
            this.yValues = yValues;
            this.minX = minX;
            this.maxX = maxX;
            hasConstraints = constrained;
            if (this.xValues.Length < 3 || this.yValues.Length <3)
            {
                interpolation = LinearSpline.InterpolateSorted(xValues, yValues);
            }
            else
            {
                interpolation = CubicSpline.InterpolateNaturalSorted(xValues, yValues);
            }
            

        }

        public double Interpolate(double x)
        {
            double value = interpolation.Interpolate(x);
            if (hasConstraints)
            {
                if (value > maxX || value < minX)
                {
                    throw new NotImplementedException();
                }
            }
            return value;
        }


    }
}

