using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJMPS.Core;

namespace vJMPSTests
{
    public static class CGPositionTestData
    {
        public static readonly CompoundChartSeries InboardCompoundSeries, CenterLineCompoundSeries;
        public static readonly ChartSeries OutboardSeries;
        static CGPositionTestData()
        {
            InboardCompoundSeries = new CompoundChartSeries();
            CenterLineCompoundSeries = new CompoundChartSeries();
            OutboardSeries = new ChartSeries();
            buildInboardData();
            buildOutboardData();
            buildCenterData();
        }

        private static void buildOutboardData()
        {
            double[] x = { 0, 8000 }; //sheet3
            double[] y = { 17.5,19.9 }; //sheet3
            //double[] x = { 0, 6100 };
            //double[] y = { 17.5, 19.6 };
            OutboardSeries.XRange = x;
            OutboardSeries.YRange = y;

        }
        private static void buildInboardData()
        {
            double[] x1 = { 0, 6250 };
            double[] y1 = { 17.5, 21.9 };
            InboardCompoundSeries.Add(0, new ChartSeries(x1, y1));

            double[] x2 = { 1000, 6600 };
            double[] y2 = { 17.8, 21.6 };
            InboardCompoundSeries.Add(1000, new ChartSeries(x2, y2));

            double[] x3 = { 2000, 6750 };
            double[] y3 = { 18.2, 21.3 };
            InboardCompoundSeries.Add(2000, new ChartSeries(x3, y3));

            double[] x4 = { 3100, 6900 };
            double[] y4 = { 18.5, 21.0 };
            InboardCompoundSeries.Add(3000, new ChartSeries(x4, y4));

            double[] x5 = { 4100, 7150 };
            double[] y5 = { 18.8, 20.8 };
            InboardCompoundSeries.Add(4000, new ChartSeries(x5, y5));

            double[] x6 = { 5100, 7250 };
            double[] y6 = { 19.1, 20.5 };
            InboardCompoundSeries.Add(5000, new ChartSeries(x6, y6));

            double[] x7 = { 6000, 7400 };
            double[] y7 = { 19.4, 20.2 };
            InboardCompoundSeries.Add(6000, new ChartSeries(x7, y7));
        }

        private static void buildCenterData()
        {
            double[] x1 = { 0, 4000 };
            double[] y1 = { 17.5, 11.6 };
            CenterLineCompoundSeries.Add(0, new ChartSeries(x1, y1));

            double[] x2 = { 500, 4300 };
            double[] y2 = { 17.75, 12.3 };
            CenterLineCompoundSeries.Add(500, new ChartSeries(x2, y2));

            double[] x3 = { 1000, 4600 };
            double[] y3 = { 18.3, 13.0 };
            CenterLineCompoundSeries.Add(1000, new ChartSeries(x3, y3));

            double[] x4 = { 1500, 4900 };
            double[] y4 = { 18.7, 14.7 };
            CenterLineCompoundSeries.Add(1500, new ChartSeries(x4, y4));

            double[] x5 = { 2000, 5300 };
            double[] y5 = {19.1,14.3 };
            CenterLineCompoundSeries.Add(2000, new ChartSeries(x5, y5));

            double[] x6 = { 2500, 5600 };
            double[] y6 = {19.5,14.9 };
            CenterLineCompoundSeries.Add(2500, new ChartSeries(x6, y6));

            double[] x7 = {3000,6000 };
            double[] y7 = {19.8,15.5 };
            CenterLineCompoundSeries.Add(3000, new ChartSeries(x7, y7));

            double[] x8 = {3500,6300 };
            double[] y8 = {20.2,16.0 };
            CenterLineCompoundSeries.Add(3500, new ChartSeries(x8, y8));

            double[] x9 = {4000,6700 };
            double[] y9 = {20.6,16.6 };
            CenterLineCompoundSeries.Add(4000, new ChartSeries(x9, y9));

            double[] x10 = {4500,7000 };
            double[] y10 = {20.8,17.1 };
            CenterLineCompoundSeries.Add(4500, new ChartSeries(x10, y10));

            double[] x11 = {5000,7375 };
            double[] y11 = {21.2,17.5 };
            CenterLineCompoundSeries.Add(5000,new ChartSeries(x11,y11));

            double[] x12 = {5500,7700 };
            double[] y12 = {21.5,18 };
            CenterLineCompoundSeries.Add(5500,new ChartSeries(x12,y12));

            double[] x13 = {6000,8000 };
            double[] y13 = {21.7,18.6 };
            CenterLineCompoundSeries.Add(6000,new ChartSeries(x13,y13));
        }

    }
}