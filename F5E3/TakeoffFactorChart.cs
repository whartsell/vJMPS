using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using vJMPS.Core;

namespace F5E3
{
    public class TakeoffFactorChart
    {
        private double _pressureAlt;

        public double PressureAlt
        {
            get { return _pressureAlt; }
            set
            {
                _pressureAlt = value;
                Calculate();
            }
        }

        private double _runwayTemp;

        public double RunwayTemp
        {
            get { return _runwayTemp; }
            set
            {
                _runwayTemp = value;
                Calculate();
            }
        }

        private double _takeoffFactor;

        public double TakeoffFactor
        {
            get { return _takeoffFactor; }
            private set { _takeoffFactor = value; }
        }

        private bool _antiIceOn;

        public bool AntiIceOn
        {
            get { return _antiIceOn; }
            set { _antiIceOn = value; }
        }

        private CompoundChartSeries runwayTemperatureSeries;
        private ChartSeries maxThrust, maxThrustAI;
        public TakeoffFactorChart()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resource = "F5E3.data.TakeoffFactor.json";
            runwayTemperatureSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "RunwayTemperature");
            maxThrust = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "MaxThrust");
            maxThrustAI = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "MaxThrustAntiIce");
            _antiIceOn = false;
            _pressureAlt = F5MissionPlanner.DefaultPA;
            _runwayTemp = F5MissionPlanner.DefaultTemp;
        }

        private void Calculate()
        {
            var fx = runwayTemperatureSeries.Interpolate(_runwayTemp, _pressureAlt);
            if (_antiIceOn)
            {
                _takeoffFactor = maxThrustAI.Interpolate(fx);
            }
            else
            {
                _takeoffFactor = maxThrust.Interpolate(fx);
            }
        }
    }
}
