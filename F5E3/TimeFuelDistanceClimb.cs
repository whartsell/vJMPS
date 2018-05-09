using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using vJMPS.Core;

namespace F5E3
{
    public class TimeFuelDistanceClimb
    {
        
        private bool _maxClimb;

        public bool MaxClimb
        {
            get { return _maxClimb; }
            set
            {
                _maxClimb = value;
                Calculate();
            }
        }


        private double _dragIndex;

        public double DragIndex
        {
            get { return _dragIndex; }
            set
            {
                _dragIndex = value;
                Calculate();
            }
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

        private double _takeoffFactor;

        public double TakeoffFactor
        {
            get { return _takeoffFactor; }
            set
            {
                _takeoffFactor = value;
                Calculate();
            }
        }

        private TimeSpan _time;

        public TimeSpan Time
        {
            get { return _time; }
            private set { _time = value; }
        }

        private double _fuel;

        public double Fuel
        {
            get { return _fuel; }
            private set { _fuel = value; }
        }

        private double _distance;

        public double Distance
        {
            get { return _distance; }
            private set { _distance = value; }
        }

        private CompoundChartSeries takeoffFactorSeries, timeSeries, fuelSeries, distanceSeries;
        public TimeFuelDistanceClimb()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resource = "F5E3.data.TimeFuelDistanceClimbMil.json";
            takeoffFactorSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "TakeoffFactor");
            timeSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Time");
            fuelSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Fuel");
            distanceSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Distance");
            _maxClimb = F5MissionPlanner.DefaultClimbProfile;
            _takeoffFactor = F5MissionPlanner.DefaultTakeoffFactor;
            _takeoffGrossWeight = F5MissionPlanner.DefaultEmptyWeight;
            _dragIndex = F5MissionPlanner.DefaultDragIndex;
            Calculate();
            
        }

        private void Calculate()
        {
            var fx = takeoffFactorSeries.Interpolate(_takeoffFactor, _takeoffGrossWeight);
            var time = timeSeries.Interpolate(fx, _dragIndex);
            
            Fuel = fuelSeries.Interpolate(fx, _dragIndex);
            Distance = distanceSeries.Interpolate(fx, _dragIndex);
            Time = new TimeSpan(0, 0, Convert.ToInt32(time));
        }
    }
}
