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
        public static readonly CompoundChartSeries InboardCompoundSeries, CenterLineCompoundSeries, 
            AmmoCompoundSeries;
        public static readonly ChartSeries OutboardSeries,MissileSeries;
        static CGPositionTestData()
        {
            InboardCompoundSeries = new CompoundChartSeries();
            CenterLineCompoundSeries = new CompoundChartSeries();
            OutboardSeries = new ChartSeries();
            MissileSeries = new ChartSeries();
            AmmoCompoundSeries = new CompoundChartSeries();
            buildInboardData();
            buildOutboardData();
            buildCenterData();
            BuildMissileData();
            BuildGunData();
        }

        private static void BuildGunData()
        {
            			double[] x1 = {0,400};
            double[] y1 = {0,-5.4};
            AmmoCompoundSeries.Add(0, new ChartSeries(x1,y1));
			
			double[] x2 = {500,750};
            double[] y2 = {0,-5.3};
            AmmoCompoundSeries.Add(500, new ChartSeries(x2,y2));
			
			double[] x3 = {1000,1300};
            double[] y3 = {0,-5.1};
            AmmoCompoundSeries.Add(1000, new ChartSeries(x3,y3));
			
			double[] x4 = {1500,1800};
            double[] y4 = {0,-4.95};
            AmmoCompoundSeries.Add(1500, new ChartSeries(x4,y4));
			
			double[] x5 = {2000,2300};
            double[] y5 = {0,-4.8};
            AmmoCompoundSeries.Add(2000, new ChartSeries(x5,y5));
			
			double[] x6 = {2500,2800};
            double[] y6 = {0,-4.6};
            AmmoCompoundSeries.Add(2500, new ChartSeries(x6,y6));
			
			double[] x7 = {3000,3300};
            double[] y7 = {0,-4.5};
            AmmoCompoundSeries.Add(3000, new ChartSeries(x7,y7));
			
			double[] x8 = {3500,3750};
            double[] y8 = {0,-4.3};
            AmmoCompoundSeries.Add(3500, new ChartSeries(x8,y8));
			
			double[] x9 = {4000,4250};
            double[] y9 = {0,-4.2};
            AmmoCompoundSeries.Add(4000, new ChartSeries(x9,y9));
			
			double[] x10 = {4500,4800};
            double[] y10 = {0,-4.1};
            AmmoCompoundSeries.Add(4500, new ChartSeries(x10,y10));
			
			double[] x11 = {5000,5250};
            double[] y11 = {0,-4.0};
            AmmoCompoundSeries.Add(5000, new ChartSeries(x11,y11));
			
			double[] x12 = {5500,5700};
            double[] y12 = {0,-3.95};
            AmmoCompoundSeries.Add(5500, new ChartSeries(x12,y12));
			
			double[] x13 = {6000,6200};
            double[] y13 = {0,-3.9};
            AmmoCompoundSeries.Add(6000, new ChartSeries(x13,y13));
			
			double[] x14 = {6500,6700};
            double[] y14 = {0,-3.8};
            AmmoCompoundSeries.Add(6500, new ChartSeries(x14,y14));
			
			double[] x15 = {7000,7200};
            double[] y15 = {0,-3.75};
            AmmoCompoundSeries.Add(7000, new ChartSeries(x15,y15));
			
			double[] x16 = {7500,7700};
            double[] y16 = {0,-3.7};
            AmmoCompoundSeries.Add(7500, new ChartSeries(x16,y16));
			
			double[] x17 = {8000,8200};
            double[] y17 = {0,-3.65};
            AmmoCompoundSeries.Add(8000, new ChartSeries(x17,y17));
			
			double[] x18 = {8500,8700};
            double[] y18 = {0,-3.6};
            AmmoCompoundSeries.Add(8500, new ChartSeries(x18,y18));
        }

        private static void BuildMissileData() 
        {
            double[] x = {0,500,1000,1500,2000,2500,3000,35000,4000,4500,5000,5500,6000,6500,7000,7500,8000,8500};
            double[] y = {0.3,0.35,0.4,0.4,0.45,0.45,0.5,0.5,0.55,0.6,0.6,0.65,0.65,0.65,0.65,0.65,0.6,0.6};
            MissileSeries.XRange = x;
            MissileSeries.YRange = y;
        }
        private static void buildOutboardData()
        {
            double[] x = { 0, 1000,2000,3000,4000,5000,6000,7000,8000 }; //sheet3
            double[] y = { 17.5,17.8,18.2,18.5,18.8,19.1,19.4,19.6,19.9 }; //sheet3
            //double[] x = { 0, 6100 };
            //double[] y = { 17.5, 19.6 };
            OutboardSeries.XRange = x;
            OutboardSeries.YRange = y;

        }
        private static void buildInboardData()
        {
            double[] x1 = { 0,1000,2000,3000,4000,5000, 6250 };
            double[] y1 = { 17.5,18.3,19.1,19.85,20.6,21.2,21.9 };
            InboardCompoundSeries.Add(0, new ChartSeries(x1, y1));

            double[] x2 = { 1000, 2000,3000,4000,5000,6000,6600 };
            double[] y2 = { 17.8, 18.6,19.4,20.0,20.75,21.3,21.6 };
            InboardCompoundSeries.Add(1000, new ChartSeries(x2, y2));

            double[] x3 = { 2000,3000,4000,5000,6000, 6750 };
            double[] y3 = { 18.2,18.9,19.6,20.2,20.85, 21.3 };
            InboardCompoundSeries.Add(2000, new ChartSeries(x3, y3));

            double[] x4 = { 3100, 4000,5000,6000,6900 };
            double[] y4 = { 18.5, 19.2,19.9,20.5,21.0 };
            InboardCompoundSeries.Add(3000, new ChartSeries(x4, y4));

            double[] x5 = { 4100, 5000, 6000, 7150 };
            double[] y5 = { 18.8, 19.5, 20.1, 20.8 };
            InboardCompoundSeries.Add(4000, new ChartSeries(x5, y5));

            double[] x6 = { 5100, 6000,7250 };
            double[] y6 = { 19.1, 19.7,20.5 };
            InboardCompoundSeries.Add(5000, new ChartSeries(x6, y6));

            double[] x7 = { 6000, 7000,7400 };
            double[] y7 = { 19.4, 20.0,20.2 };
            InboardCompoundSeries.Add(6000, new ChartSeries(x7, y7));
        }

        private static void buildCenterData()
        {
            double[] x1 = { 0, 1000,2000,3000,4000 };
            double[] y1 = { 17.5, 11.6 };
            CenterLineCompoundSeries.Add(0, new ChartSeries(x1, y1));

            double[] x2 = { 500, 1500,2500,3500,4300 };
            double[] y2 = { 17.75, 12.3 };
            CenterLineCompoundSeries.Add(500, new ChartSeries(x2, y2));

            double[] x3 = { 1000, 2000,3000,4000, 4600 };
            double[] y3 = { 18.3, 13.0 };
            CenterLineCompoundSeries.Add(1000, new ChartSeries(x3, y3));

            double[] x4 = { 1500, 2500,3500,4500,4900 };
            double[] y4 = { 18.7, 14.7 };
            CenterLineCompoundSeries.Add(1500, new ChartSeries(x4, y4));

            double[] x5 = { 2000, 3000,4000,,5000,5300 };
            double[] y5 = {19.1,18.5,16.0,14.8,14.3 };
            CenterLineCompoundSeries.Add(2000, new ChartSeries(x5, y5));

            double[] x6 = { 2500, 3500,4500,5000,5600 };
            double[] y6 = {19.5,17.9,16.4,15.8,14.9 };
            CenterLineCompoundSeries.Add(2500, new ChartSeries(x6, y6));

            double[] x7 = {3000,4000,5000,6000 };
            double[] y7 = {19.8,18.2,16.8,15.5 };
            CenterLineCompoundSeries.Add(3000, new ChartSeries(x7, y7));

            double[] x8 = {3500,4500,5500,6300 };
            double[] y8 = {20.2,16.0 };
            CenterLineCompoundSeries.Add(3500, new ChartSeries(x8, y8));

            double[] x9 = {4000,5000,6000,6700 };
            double[] y9 = {20.6,16.6 };
            CenterLineCompoundSeries.Add(4000, new ChartSeries(x9, y9));

            double[] x10 = {4500,5500,6500,7000 };
            double[] y10 = {20.8,17.1 };
            CenterLineCompoundSeries.Add(4500, new ChartSeries(x10, y10));

            double[] x11 = {5000,6000,7000,7375 };
            double[] y11 = {21.2,17.5 };
            CenterLineCompoundSeries.Add(5000,new ChartSeries(x11,y11));

            double[] x12 = {5500,6500,7000,7700 };
            double[] y12 = {21.5,18 };
            CenterLineCompoundSeries.Add(5500,new ChartSeries(x12,y12));

            double[] x13 = {6000,7000,8000 };
            double[] y13 = {21.7,18.6 };
            CenterLineCompoundSeries.Add(6000,new ChartSeries(x13,y13));
        }

    }
}