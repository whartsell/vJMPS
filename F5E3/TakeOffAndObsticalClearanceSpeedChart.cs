using System;
using System.Reflection;
using vJMPS.Core;

namespace F5E3
{
    public class TakeOffAndObsticalClearanceSpeedChart
    {
        private CompoundChartSeries takeoffSpeedSeries, obstacleClearanceSpeedSeries;
        private GrossWeightAndCGPositionChart GrossWeightAndCGPositionChart;


        public TakeOffAndObsticalClearanceSpeedChart(GrossWeightAndCGPositionChart grossWeightAndCGPositionChart)
        {
            GrossWeightAndCGPositionChart = grossWeightAndCGPositionChart;
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resource = "F5E3.data.TakeOffSpeed.json";
            takeoffSpeedSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "TakeoffSpeed");
            obstacleClearanceSpeedSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "ObstacleClearanceSpeed");
            _takeoffGrossWeight = grossWeightAndCGPositionChart.GrossWeight;
            _cg = grossWeightAndCGPositionChart.CG;
            
            Calculate();
        }

        private void Calculate()
        {
            var interimTOSpeed = takeoffSpeedSeries.Interpolate(TakeoffGrossWeight, CG);
            // should missiles count as well?
            if (GrossWeightAndCGPositionChart.CenterStoresWeight > 1000 && GrossWeightAndCGPositionChart.InboardStoresWeight == 0 
                && GrossWeightAndCGPositionChart.OutboardStoresWeight == 0)
            {
                TakeoffSpeed = interimTOSpeed + 5;
            }
            else
            {
                TakeoffSpeed = interimTOSpeed;
            }
            AftStickSpeed = TakeoffSpeed - 10;
            ObstacleClearanceSpeed = obstacleClearanceSpeedSeries.Interpolate(TakeoffGrossWeight, CG);
        }

        private double _takeoffGrossWeight;
        public double TakeoffGrossWeight
        {
            get { return _takeoffGrossWeight; }
            set
            {
                _takeoffGrossWeight = value;
                Calculate();

            }
        }

        private double _cg;

        public double CG
        {
            get { return _cg; }
            set
            {
                _cg = value;
                Calculate();
            }
        }

        private double _takeoffSpeed;

        public double TakeoffSpeed
        {
            get { return _takeoffSpeed; }
            private set { _takeoffSpeed = value; }
        }

        private double _aftStickSpeed;

        public double AftStickSpeed
        {
            get { return _aftStickSpeed; }
            private set { _aftStickSpeed = value; }
        }

        private double _obstacleClearanceSpeed;

        public double ObstacleClearanceSpeed
        {
            get { return _obstacleClearanceSpeed; }
            private set { _obstacleClearanceSpeed = value; }
        }


    }
}
