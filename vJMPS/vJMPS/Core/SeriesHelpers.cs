using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
namespace vJMPS.Core
{
    public static class SeriesHelpers
    {
        public static ChartSeries ChartSeriesFromResourceJSON(string assembly,string resourcePath, string seriesName)
        {
          
            using (Stream stream = Assembly.LoadFrom(assembly).GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                JObject obj = JObject.Parse(reader.ReadToEnd());
                return new ChartSeries();
            }
            
        }

        //    public static ChartSeries ChartSeriesFromJSON(JObject object)
        //    {

        //    }
        }
    }