using F5E3.Models;
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

        public static void CalculateTOandOCSpeeds(this TakeoffModel takeoffData)
        {
            var interimTOSpeed = takeoffSpeedSeries.Interpolate(takeoffData.TakeoffWeight, takeoffData.WandBModel.CG);
            // should missiles count as well?
            if (takeoffData.WandBModel.CenterStoresWeight > 1000 && takeoffData.WandBModel.InboardStoresWeight == 0
                && takeoffData.WandBModel.OutboardStoresWeight == 0)
            {
                takeoffData.TakeoffSpeed = interimTOSpeed + 5;
            }
            else
            {
                takeoffData.TakeoffSpeed = interimTOSpeed;
            }
            takeoffData.AftStickSpeed = takeoffData.TakeoffSpeed - 10;
            takeoffData.ObstacleClearanceSpeed = obstacleClearanceSpeedSeries.Interpolate(takeoffData.TakeoffWeight, takeoffData.WandBModel.CG);
        }


    }
}
