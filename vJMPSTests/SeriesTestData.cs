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
        static readonly CompoundChartSeries InboardCompoundSeries;
        static SeriesTestData()
        {
                InboardCompoundSeries = new CompoundChartSeries();
                buildInboardData();
        }

        private static void buildInboardData()
        {
            double[] x1 = {0,6250};
            double[] y1 = {17.3,21.9};
            InboardCompoundSeries.Add(17.3,new ChartSeries(x1,y1));

            double[] x2 = {1000,6600};
            double[] y2 = {17.8,21.6};         
            InboardCompoundSeries.Add(17.8,new ChartSeries(x2,y2));

            double[] x3 = {2000,6750};
            double[] y3 = {18.2,21.3};
            InboardCompoundSeries.Add(18.2,new ChartSeries(x3,y3));

            double[] x4 = {3100,6900};
            double[] y4 = {18.5,21.0};
            InboardCompoundSeries.Add(18.5,ChartSeries(x4,y4));

            double[] x5 = {4100,7150};
            double[] y5 = {18.8,20.8};
            InboardCompoundSeries.Add(18.8,new ChartSeries(x5,y5));

            double[] x6 = {5100,7250};
            double[] y6 = {19.1,20.5};
            InboardCompoundSeries.Add(19.1,new ChartSeries(x6,y6));

            double[] x7 = {6000,7400};
            double[] y7 = {19.4,20.2};
            InboardCompoundSeries.Add(19.1,new ChartSeries(x7,y7));
        }

    }
}