using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace vJMPS.Core
{
    public static class SeriesHelpers
    {
        public static CompoundChartSeries CompoundChartSeriesFromResourceJSON(string assembly,string resourcePath, string seriesName)
        {
            CompoundChartSeries results = new CompoundChartSeries();
            using (Stream stream = Assembly.LoadFrom(assembly).GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {

                JObject obj = JObject.Parse(reader.ReadToEnd());
                Dictionary<string, Dictionary<string,double[]>> elements = obj[seriesName].ToObject<Dictionary<string, Dictionary<string,double[]>>>();
                foreach (KeyValuePair<string, Dictionary<string,double[]>> item in elements)
                {
                    double[] xValues = item.Value["x"];
                    double[] yValues = item.Value["data"];
                    results.Add(Double.Parse(item.Key), new ChartSeries(xValues, yValues));
                    
                }
                return results;
            }
            
        }

        //    public static ChartSeries ChartSeriesFromJSON(JObject object)
        //    {

        //    }
        }
    }