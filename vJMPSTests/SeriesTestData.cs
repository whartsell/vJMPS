using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJMPS.Core;

namespace vJMPSTests 
{
    public static class SeriesTestData 
    {
        public static Dictionary<double,ChartSeries> buildTestData() {
            Dictionary<double,ChartSeries> seriesMap = new Dictionary<double,ChartSeries>();
            ChartSeries inboard1 = new ChartSeries({0,6250},{17.3,21.9});
            ChartSeries inboard2 = new ChartSeries({0,1000,6600},{17.3,17.8,21.6});
            ChartSeries inboard3 = new ChartSeries({0,2000,6750},{17.3,18.2,21.3});
            ChartSeries inboard4 = new ChartSeries({0,3100,6900},{17.3,18.5,21.0});
            ChartSeries inboard5 = new ChartSeries({0,4100,7150},{17.3,18.8,20.8});
            ChartSeries inboard6 = new ChartSeries({0,5100,7250},{17.3,19.1,20.5});
            ChartSeries inboard7 = new ChartSeries({0,6000,7400},{17.3,19.4,20.2});
            seriesMap.Add(17.3,inboard1);
            seriesMap.Add(17.8,inboard2);
            seriesMap.Add(18.2,inboard3);
            seriesMap.Add(18.5,inboard4);
            seriesMap.Add(18.8,inboard5);
            seriesMap.Add(19.1,inbaord6);
            seriesMap.Add(19.4,inboard7);
            return seriesMap;
        }

    }
}