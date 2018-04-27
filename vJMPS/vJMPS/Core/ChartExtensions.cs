using System;
using System.Collections.Generic;
using System.Text;

namespace vJMPS.Core
{
    public static class ChartExtensions
    {
        public static double SigFigs(this double value, int n )
        {
            if (value == 0)
            {
                return 0;
            }

            double d = Math.Ceiling(Math.Log10(value < 0 ? -value : value));
            int power = n - (int)d;
            double magnitude = Math.Pow(10, power);
            long shifted = (long)Math.Round(value * magnitude);
            return shifted / magnitude;
        }
    }
}
