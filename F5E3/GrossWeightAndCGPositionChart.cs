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
        
        public GrossWeightAndCGPositionChart()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resource = "F5E3.data.AircraftGrossWeightAndCGPosition.json";
            inboardSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Inboard");
            centerSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Center");
            ammoSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Ammo");
            outboardSeries = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "Outboard");
            missileSeries = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "Missile");
        }

        private double _inboardStoresWeight;

        public double InboardStoresWeight
        {
            get { return _inboardStoresWeight; }
            set { _inboardStoresWeight = value; }
        }

        private double _outboardStoresWeight;

        public double OutboardStoresWeight
        {
            get { return _outboardStoresWeight; }
            set { _outboardStoresWeight = value; }
        }

        private double _centerStoresWeight;

        public double CenterStoresWeight
        {
            get { return _centerStoresWeight; }
            set { _centerStoresWeight = value; }
        }

        private bool _hasMissiles;

        public bool HasMissiles
        {
            get { return _hasMissiles; }
            set { _hasMissiles = value; }
        }

        private double _ammo;

        public double Ammo
        {
            get { return _ammo; }
            set { _ammo = value; }
        }

        private double _cg;

        public double CG
        {
            get { return _cg; }
            private set { _cg = value; }
        }

    }
}
