using System.IO;
using System.Reflection;
    
#endregion
namespace vJMPS.Core
{
    public static class SeriesHelpers
    {
        public static ChartSeries ChartSeriesFromResourceJSON(string resourcePath, string seriesName) 
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                JObject obj = JObject.Parse(reader.ReadToEnd());
            }
        }

        public static ChartSeries ChartSeriesFromJSON(JObject object)
        {
            
        }
    }
}