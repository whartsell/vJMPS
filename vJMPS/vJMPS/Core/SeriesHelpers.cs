using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace vJMPS.Core
{
    public static class SeriesHelpers
    {
        public static CompoundChartSeries CompoundChartSeriesFromResourceJSON(string assembly, string resourcePath, string seriesName)
        {
            CompoundChartSeries results = new CompoundChartSeries();
            JObject obj = JsonFromResource(assembly, resourcePath);
            Dictionary<string, Dictionary<string, double[]>> elements = obj[seriesName].ToObject<Dictionary<string, Dictionary<string, double[]>>>();
            foreach (KeyValuePair<string, Dictionary<string, double[]>> item in elements)
            {
                double[] xValues = item.Value["x"];
                double[] yValues = item.Value["data"];
                results.Add(Double.Parse(item.Key), new ChartSeries(xValues, yValues));

            }
            return results;
        }

        public static CompoundChartSeries CompoundChartSeriesFromResourceJSON(Assembly assembly, string resourcePath, string seriesName)
        {
            CompoundChartSeries results = new CompoundChartSeries();
            JObject obj = JsonFromResource(assembly, resourcePath);
            Dictionary<string, Dictionary<string, double[]>> elements = obj[seriesName].ToObject<Dictionary<string, Dictionary<string, double[]>>>();
            foreach (KeyValuePair<string, Dictionary<string, double[]>> item in elements)
            {
                double[] xValues = item.Value["x"];
                double[] yValues = item.Value["data"];
                results.Add(Double.Parse(item.Key), new ChartSeries(xValues, yValues));

            }
            return results;
        }

        public static ChartSeries ChartSeriesFromResourceJSON(string assembly,string resourcePath,string seriesName)
        {
            JObject obj = JsonFromResource(assembly, resourcePath);
            ChartSeries results = new ChartSeries();
            results.XRange = obj[seriesName]["x"].ToObject<double[]>();
            results.YRange = obj[seriesName]["data"].ToObject<double[]>();
            return results;
        }

        public static ChartSeries ChartSeriesFromResourceJSON(Assembly assembly, string resourcePath, string seriesName)
        {
            JObject obj = JsonFromResource(assembly, resourcePath);
            ChartSeries results = new ChartSeries();
            results.XRange = obj[seriesName]["x"].ToObject<double[]>();
            results.YRange = obj[seriesName]["data"].ToObject<double[]>();
            return results;
        }

        private static JObject JsonFromResource(string assembly, string resourcePath)
        {
            JObject results;
            using (Stream stream = Assembly.LoadFrom(assembly).GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {

                results = JObject.Parse(reader.ReadToEnd());
            }
            return results;
        }

        private static JObject JsonFromResource(Assembly assembly, string resourcePath)
        {
            JObject results;
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {

                results = JObject.Parse(reader.ReadToEnd());
            }
            return results;
        }
    }
}