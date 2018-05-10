using F5E3.Structs;

using System;
using System.Reflection;
using vJMPS.Core;

namespace F5E3
{
    public static class TOandOCSpeedChart
    {
        private static CompoundChartSeries takeoffSpeedSeries, obstacleClearanceSpeedSeries;


        static TOandOCSpeedChart()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resource = "F5E3.data.TakeOffSpeed.json";
            takeoffSpeedSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "TakeoffSpeed");
            obstacleClearanceSpeedSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "ObstacleClearanceSpeed");
        }

        //public static TakeoffData Calculate(TakeoffData takeoffData)
        //{
        //    var interimTOSpeed = takeoffSpeedSeries.Interpolate(takeoffData.TakeoffWeight, loadout.CG);
        //    // should missiles count as well?
        //    if (loadout.CenterStoresWeight > 1000 && loadout.InboardStoresWeight == 0
        //        && loadout.OutboardStoresWeight == 0)
        //    {
        //        takeoffData.TakeoffSpeed = interimTOSpeed + 5;
        //    }
        //    else
        //    {
        //        takeoffData.TakeoffSpeed = interimTOSpeed;
        //    }
        //    takeoffData.AftStickSpeed = takeoffData.TakeoffSpeed - 10;
        //    takeoffData.ObstacleClearanceSpeed = obstacleClearanceSpeedSeries.Interpolate(takeoffData.TakeoffWeight, loadout.CG);

        //    return takeoffData;
        //}


    }
}
