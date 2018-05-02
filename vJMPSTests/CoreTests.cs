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
        public void Experimental()
        {
            
            
        }
        
        [TestMethod]
        public void F5_TakeoffSpeed()
        {
            CompoundChartSeries takeoffSpeedSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON("vJMPSTests.dll", "vJMPSTests.data.TakeOffSpeed.json", "TakeoffSpeed");
            Assert.AreEqual(167, takeoffSpeedSeries.Interpolate(18000, 12).SigFigs(3));
        }

        [TestMethod]
        public void F5_ObstacleClearanceSpeed()
        {
            CompoundChartSeries obstacleClearanceSpeedSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON("vJMPSTests.dll", "vJMPSTests.data.TakeOffSpeed.json", "ObstacleClearanceSpeed");
            Assert.AreEqual(183, obstacleClearanceSpeedSeries.Interpolate(18000, 12).SigFigs(3));
        }
        
        [TestMethod]
        public void ChartSeriesTests() {
            double outboardWeight = 1318;
            double inboardWeight = 1306;
            double centerWeight = 2174;
            double ammoWeight = 394;
            double missileWeight = 342;
            
            var outboard = CGPositionTestData.OutboardSeries.Interpolate(outboardWeight);
            Assert.AreEqual(17.9, outboard.SigFigs(3));
            var inboard =  CGPositionTestData.InboardCompoundSeries.Interpolate(inboardWeight, outboardWeight);
            Assert.AreEqual(18.9, inboard.SigFigs(3));
            var centerLine = CGPositionTestData.CenterLineCompoundSeries.Interpolate(centerWeight,inboardWeight+outboardWeight);
            Assert.AreEqual(16.3, centerLine.SigFigs(3)); // this one should be looked at
            var missile = CGPositionTestData.MissileSeries.Interpolate(inboardWeight+outboardWeight+centerWeight);
            Assert.AreEqual(0.598,missile.SigFigs(3));
            var gun = CGPositionTestData.AmmoCompoundSeries.Interpolate(ammoWeight, outboardWeight+inboardWeight+centerWeight+missileWeight);
            Assert.AreEqual(-3.98,gun.SigFigs(3));
            Assert.AreEqual(12.9,(centerLine + missile + gun).SigFigs(3));
        }
    }
}
