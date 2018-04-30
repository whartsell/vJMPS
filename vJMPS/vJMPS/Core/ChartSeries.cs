using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.Interpolation;

namespace vJMPS.Core
{
    public class ChartSeries
    {
  
        public ChartSeries()
        {

        }
        public ChartSeries(double[] xValues,double[] yValues)
        {
            //this.xValues = xValues;
            //this.yValues = yValues;
            ////this.minX = xValues.Min();
            ////this.maxX = maxX;
            ////hasConstraints = constrained;
            //if (this.xValues.Length < 3 || this.yValues.Length <3)
            //{
            //    interpolation = LinearSpline.InterpolateSorted(xValues, yValues);
            //}
            //else
            //{
            //    interpolation = CubicSpline.InterpolateNaturalSorted(xValues, yValues);
            //}
            this.XRange = xValues;
            this.YRange = yValues;

        }


        private double[] _xRange;

        public double[] XRange
        {
            get { return _xRange; }
            set
            {
                //todo we need to look at bounding min,max etc
                _xRange = value;
            }
        }

        private double[] _yRange;

        public double[] YRange
        {
            get { return _yRange; }
            set { _yRange = value; }
        }


        public double Interpolate(double x)
        {
            //double value = interpolation.Interpolate(x);
            if (_xRange.Length < 3 || _yRange.Length < 3)
            {
                //return LinearSpline.InterpolateSorted(_xRange, _yRange).Interpolate(x);
                return LinearSpline.Interpolate(_xRange, _yRange).Interpolate(x);
            }
            else
            {
                return CubicSpline.InterpolateNatural(_xRange, _yRange).Interpolate(x);
            }
        }


    }
}

