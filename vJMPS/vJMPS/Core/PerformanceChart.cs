using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace vJMPS.Core
{
    public abstract class PerformanceChart
    {
        private JObject root;
        protected PerformanceChart(string json)
        {
            root = JObject.Parse(json);
            
        }

        protected Dictionary<Double, ChartSeries> ToChartSeriesMap(String fieldName)
        {
            Dictionary<Double, ChartSeries> results = new Dictionary<Double, ChartSeries>();
            double[] xValues = root[fieldName]["x"].ToObject<double[]>();
            Dictionary<string, double[]> elements = root[fieldName]["data"].ToObject<Dictionary<string, double[]>>();
            foreach (KeyValuePair<string,double[]> item in elements)
            {
                results.Add(Double.Parse(item.Key), new ChartSeries(xValues, item.Value));
            }
        return results;
        }

        protected ChartSeries ToChartSeries(String seriesName, String xField, String yField)
        {
            return new ChartSeries(root[seriesName][xField].ToObject<double[]>(), root[seriesName][yField].ToObject<double[]>());
        }

        public static double interpolateBetweenSeries(Dictionary<double, ChartSeries> seriesMap, double x, double interpolatedSeries)
        {
            ChartSeries interpolatedChartSeries;
            List<double> seriesKeys = new List<double>();
            List<double> seriesValues = new List<double>();
            foreach (KeyValuePair<double,ChartSeries> item in seriesMap)
            {
                seriesKeys.Add(item.Key);
                seriesValues.Add(item.Value.Interpolate(x));
            }
            var test = seriesKeys.ToArray();
            var alsoTest = seriesValues.ToArray();
            interpolatedChartSeries = new ChartSeries(seriesKeys.ToArray(),seriesValues.ToArray());
            return interpolatedChartSeries.Interpolate(interpolatedSeries);
        }
    }

}
