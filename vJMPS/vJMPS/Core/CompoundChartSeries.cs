using System;
using System.Collections.Generic;
using System.Text;

namespace vJMPS.Core
{
    public class CompoundChartSeries
    {
        private Dictionary<double, ChartSeries> _compoundSeries;

        public CompoundChartSeries()
        {
            _compoundSeries = new Dictionary<double, ChartSeries>();
        }

        public string Name { get; set; }


        public void Add(double index,ChartSeries series)
        {
            _compoundSeries.Add(index, series);
        }

        public double Interpolate(double x, double index)
        {
            ChartSeries interpolatedChartSeries;
            List<double> seriesKeys = new List<double>();
            List<double> seriesValues = new List<double>();
            foreach (KeyValuePair<double, ChartSeries> item in _compoundSeries)
            {
                Console.WriteLine("key:" + item.Key);
                seriesKeys.Add(item.Key);
                Console.WriteLine("Value:" + item.Value.Interpolate(x));
                seriesValues.Add(item.Value.Interpolate(x));
            }
            interpolatedChartSeries = new ChartSeries(seriesKeys.ToArray(), seriesValues.ToArray());
            return interpolatedChartSeries.Interpolate(index);
        }
        //this is a hack to test stuff out
        public double BoundedInterpolate(double x,double x1, double fx1)
        {
            var seriesKeys = _compoundSeries.Keys;
            double delta = 100;
            double offset = 0;
            double index=0;
            foreach (KeyValuePair<double,ChartSeries>item in _compoundSeries)
            {
                double result = item.Value.Interpolate(x1);
                double diff = result - fx1;
              

                if (Math.Abs(diff) < delta)
                {
                    delta = Math.Abs(diff);
                    offset = diff;
                    index = item.Key;
                }
            }
            double value = _compoundSeries[index].Interpolate(x);
            return value - offset;
            
            
        }
    }
}
