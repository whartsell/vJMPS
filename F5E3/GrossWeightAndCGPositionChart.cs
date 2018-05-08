using System;
using System.Collections.Generic;
using System.Text;
using vJMPS.Core;
using System.Reflection;

namespace F5E3
{
    public class GrossWeightAndCGPositionChart
    {
        private CompoundChartSeries inboardSeries, centerSeries, ammoSeries;
        private ChartSeries outboardSeries, missileSeries;
        private static double missileWeight = 342;
        private static double aircraftEmptyWeight = 15050;
        
        public GrossWeightAndCGPositionChart()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resource = "F5E3.data.AircraftGrossWeightAndCGPosition.json";
            inboardSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Inboard");
            centerSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Center");
            ammoSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Ammo");
            outboardSeries = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "Outboard");
            missileSeries = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "Missile");
            _inboardStoresWeight = 0;
            _outboardStoresWeight = 0;
            _centerStoresWeight = 0;
            _ammo = 0;
            _hasMissiles = false;
        }

        private double _inboardStoresWeight;

        public double InboardStoresWeight
        {
            get { return _inboardStoresWeight; }
            set
            {
                _inboardStoresWeight = value;
                Calculate();
            }
        }

        private double _outboardStoresWeight;

        public double OutboardStoresWeight
        {
            get { return _outboardStoresWeight; }
            set
            {
                _outboardStoresWeight = value;
                Calculate();
            }
        }

        private double _centerStoresWeight;

        public double CenterStoresWeight
        {
            get { return _centerStoresWeight; }
            set
            {
                _centerStoresWeight = value;
                Calculate();
            }
        }

        private bool _hasMissiles;

        public bool HasMissiles
        {
            get { return _hasMissiles; }
            set
            {
                _hasMissiles = value;
                Calculate();
            }
        }

        private double _ammo;

        public double Ammo
        {
            get { return _ammo; }
            set
            {
                _ammo = value;
                Calculate();
            }
        }

        private double _cg;

        public double CG
        {
            get { return _cg; }
            private set { _cg = value; }
        }

        private double _grossWeight;

        public double GrossWeight
        {
            get { return _grossWeight; }
            private set { _grossWeight = value; }
        }


        private void Calculate()
        {
            var interimCG =  outboardSeries.Interpolate(_outboardStoresWeight);
            var interimWeight = _outboardStoresWeight;
            interimCG = inboardSeries.Interpolate(_inboardStoresWeight, interimWeight);
            interimWeight = interimWeight + _inboardStoresWeight;
            interimCG = centerSeries.Interpolate(_centerStoresWeight, interimWeight);
            interimWeight = interimWeight + _centerStoresWeight;
            if (_hasMissiles)
            {
                interimCG = interimCG + missileSeries.Interpolate(interimWeight);
                interimWeight = interimWeight + missileWeight;
            }
            interimCG = interimCG + ammoSeries.Interpolate(_ammo, interimWeight);
            interimWeight = interimWeight + _ammo;
            _cg = interimCG;
            _grossWeight = aircraftEmptyWeight + interimWeight;
        }

    }
}
