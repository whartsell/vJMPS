using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using vJMPS.Core;

namespace vJMPSTests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void SigFigsPositiveTests()
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
        public void ChartSeriesTests()
        {
            double[] x = { 2, 20, 40, 60, 82 };
            double[] y = { 43, 53, 64, 75, 86 };
            ChartSeries test = new ChartSeries(x, y);
            Assert.AreEqual(48, test.Interpolate(11).SigFigs(2));
        }

        [TestMethod]
        public void PerformanceChartTests()
        {
            
            PerformanceChartMock performanceChartMock = new PerformanceChartMock(TestData.SingleEngineROC);
            var results1 = performanceChartMock.MockToChartSeriesMap("pressureAltitudes");
            Assert.AreEqual(4, results1.Count);
            performanceChartMock = new PerformanceChartMock(TestData.PTFS);
            var results2 = performanceChartMock.MocktoChartSeries("PTFS", "x", "data");
            Assert.IsInstanceOfType(results2,typeof(ChartSeries));
        }
    }
}
