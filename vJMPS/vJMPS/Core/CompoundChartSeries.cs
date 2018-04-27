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
                seriesKeys.Add(item.Key);
                seriesValues.Add(item.Value.Interpolate(x));
            }
            interpolatedChartSeries = new ChartSeries(seriesKeys.ToArray(), seriesValues.ToArray());
            return interpolatedChartSeries.Interpolate(index);
        }

    }
}
