using System;
using System.Collections.Generic;
using System.Text;
using vJMPS.Core;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using F5E3.Models;

namespace F5E3
{
    public static class GWandCGChart
    {
        private static CompoundChartSeries inboardSeries, centerSeries, ammoSeries;
        private static ChartSeries outboardSeries, missileSeries;
      
        
        static GWandCGChart()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resource = "F5E3.data.AircraftGrossWeightAndCGPosition.json";
            inboardSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Inboard");
            centerSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Center");
            ammoSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "Ammo");
            outboardSeries = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "Outboard");
            missileSeries = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "Missile");
        }




        public static void CalculateGWandCG(this WandBModel loadout)
        {
            var _outboardStoresWeight = loadout.OutboardStoresWeight;
            var _inboardStoresWeight = loadout.InboardStoresWeight;
            var _centerStoresWeight = loadout.CenterStoresWeight;
            var _hasMissiles = loadout.HasMissiles;
            var _ammo = loadout.Ammo;
            var interimCG =  outboardSeries.Interpolate(_outboardStoresWeight);
            var storesWeight = _outboardStoresWeight;
            interimCG = inboardSeries.Interpolate(_inboardStoresWeight, storesWeight);
            storesWeight = storesWeight + _inboardStoresWeight;
            interimCG = centerSeries.Interpolate(_centerStoresWeight, storesWeight);
            storesWeight = storesWeight + _centerStoresWeight;
            if (_hasMissiles)
            {
                interimCG = interimCG + missileSeries.Interpolate(storesWeight);
                storesWeight = storesWeight + 342; //this should be moved to a default somewhere
            }
            interimCG = interimCG + ammoSeries.Interpolate(_ammo, storesWeight);
            storesWeight = storesWeight + _ammo;
            loadout.CG = interimCG;
            loadout.GrossWeight = 15050 + storesWeight; //the should be moved to a default somewhere
        }

        

    }
}
