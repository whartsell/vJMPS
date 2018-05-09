using F5E3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using vJMPS.Core;

namespace vJMPSTests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void SigFigsTests()
        {
            double test1 = 1234.56789;
            Assert.AreEqual(1235, test1.SigFigs(4));
            Assert.AreEqual(1234.6, test1.SigFigs(5));
            Assert.AreEqual(1000, test1.SigFigs(1));
            double test2 = -1234.56789;
            Assert.AreEqual(-1235, test2.SigFigs(4));
            Assert.AreEqual(-1234.6, test2.SigFigs(5));
            Assert.AreEqual(-1000, test2.SigFigs(1));
        }


        [TestMethod]
        public void GrossWeightAndCGPositionChart()
        {
            var chart = new GrossWeightAndCGPositionChart
            {
                OutboardStoresWeight = 1318,
                InboardStoresWeight = 1306,
                CenterStoresWeight = 2174,
                Ammo = 394,
                HasMissiles = true
            };
            Assert.AreEqual(12.9, chart.CG.SigFigs(3));
            Assert.AreEqual(20584, chart.GrossWeight);
        }
        
        [TestMethod]
        public void F5_TakeoffAndObstacleClearanceSpeedChart()
        {
            //todo add test case for centerline over 1k and no wing stores
            var chart = new TakeOffAndObsticalClearanceSpeedChart(new GrossWeightAndCGPositionChart())
            {
                TakeoffGrossWeight = 18000,
                CG = 12
            };

            Assert.AreEqual(167, chart.TakeoffSpeed.SigFigs(3));
            Assert.AreEqual(157, chart.AftStickSpeed.SigFigs(3));
            Assert.AreEqual(184, chart.ObstacleClearanceSpeed.SigFigs(3));
        }

        [TestMethod]
        public void F5_TimeFuelAndDistance()
        {
            var chart = new TimeFuelDistanceClimb
            {
                TakeoffFactor = 11.6,
                TakeoffGrossWeight = 20290,
                DragIndex = 120
            };
            Assert.AreEqual(new System.TimeSpan(0, 1, 10),chart.Time);
            Assert.AreEqual(310,chart.Fuel.SigFigs(2));
            Assert.AreEqual(3.1,chart.Distance.SigFigs(2));
        }
        
        [TestMethod]
        public void ChartSeriesTests() {
            var assembly = "F5E3.dll";
            var resource = "F5E3.data.AircraftGrossWeightAndCGPosition.json";
            double outboardWeight = 1318;
            double inboardWeight = 1306;
            double centerWeight = 2174;
            double ammoWeight = 394;
            double missileWeight = 342;

            //var outboard = CGPositionTestData.OutboardSeries.Interpolate(outboardWeight);
            var outboard = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "Outboard")
                .Interpolate(outboardWeight);
            Assert.AreEqual(17.9, outboard.SigFigs(3));

            var inboard = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Inboard")
                .Interpolate(inboardWeight, outboardWeight);
            Assert.AreEqual(18.9, inboard.SigFigs(3));

            var centerLine = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Center")
                .Interpolate(centerWeight,inboardWeight+outboardWeight);
            Assert.AreEqual(16.3, centerLine.SigFigs(3)); // this one should be looked at

            var missile = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "Missile")
                .Interpolate(inboardWeight+outboardWeight+centerWeight);
            Assert.AreEqual(0.598,missile.SigFigs(3));

            var gun = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Ammo")
                .Interpolate(ammoWeight, outboardWeight+inboardWeight+centerWeight+missileWeight);
            Assert.AreEqual(-3.98,gun.SigFigs(3));

            Assert.AreEqual(12.9,(centerLine + missile + gun).SigFigs(3));
        }
        [TestMethod]
        public void TakeoffFactor()
        {
            var chart = new TakeoffFactorChart
            {
                AntiIceOn = false,
                PressureAlt = 0,
                RunwayTemp = 15
            };

            Assert.AreEqual(12.0, chart.TakeoffFactor.SigFigs(3));
    }
    }
}
