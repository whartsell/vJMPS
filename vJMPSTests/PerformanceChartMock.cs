using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJMPS.Core;

namespace vJMPSTests
{
    public class PerformanceChartMock : PerformanceChart

    {
        public PerformanceChartMock(string json) : base(json)
        {
            
        }

        public  Dictionary<Double, ChartSeries> MockToChartSeriesMap(String fieldName)
        {
            return this.ToChartSeriesMap(fieldName);
        }

        public ChartSeries MocktoChartSeries(String seriesName, String xField, String yField)
        {
            return this.ToChartSeries(seriesName, xField, yField);
        }
    }
}
