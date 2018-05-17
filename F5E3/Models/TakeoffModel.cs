using System.Reflection;
using vJMPS.Core;

namespace F5E3.Models
{
    public class TakeoffModel : TOLDModel
    {



        public WandBModel WandBModel { get; private set; }
        public double TakeoffSpeed { get; internal set; }
        public double AftStickSpeed { get; internal set; }
        public double ObstacleClearanceSpeed { get; internal set; }
        public double TakeoffWeight { get; internal set; }
        public double TakeoffFactor { get; set; }
        public bool AntiIceOn { get; set; }
        private int _taxiTime;
        private readonly CompoundChartSeries takeoffSpeedSeries;
        private readonly CompoundChartSeries obstacleClearanceSpeedSeries;
        private CompoundChartSeries runwayTemperatureSeries;
        private ChartSeries maxThrust, maxThrustAI;

        public int TaxiTime //taxi time in minutes
        {
            get { return _taxiTime; }
            set
            {
                _taxiTime = value;
                TakeoffWeight = WandBModel.GrossWeight - (_taxiTime * 18);
                // the 18lbs/min should prolly be a setting somewhere
            }
        }

        public TakeoffModel(WandBModel _wandBModel) : base()
        {
            WandBModel = _wandBModel;
            TakeoffWeight = WandBModel.GrossWeight;
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resource = "F5E3.data.TakeOffSpeed.json";
            takeoffSpeedSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "TakeoffSpeed");
            obstacleClearanceSpeedSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "ObstacleClearanceSpeed");
            resource = "F5E3.data.TakeoffFactor.json";
            runwayTemperatureSeries = SeriesHelpers.CompoundChartSeriesFromResourceJSON(assembly, resource, "RunwayTemperature");
            maxThrust = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "MaxThrust");
            maxThrustAI = SeriesHelpers.ChartSeriesFromResourceJSON(assembly, resource, "MaxThrustAntiIce");

        }

        public void CalculateTOandOCSpeeds()
        {
            var interimTOSpeed = takeoffSpeedSeries.Interpolate(TakeoffWeight, WandBModel.CG);
            // should missiles count as well?
            if (WandBModel.CenterStoresWeight > 1000 && WandBModel.InboardStoresWeight == 0
                && WandBModel.OutboardStoresWeight == 0)
            {
                TakeoffSpeed = interimTOSpeed + 5;
            }
            else
            {
                TakeoffSpeed = interimTOSpeed;
            }
            AftStickSpeed = TakeoffSpeed - 10;
            ObstacleClearanceSpeed = obstacleClearanceSpeedSeries.Interpolate(TakeoffWeight, WandBModel.CG);
        }
        public void CalculateTakeoffFactor()
        {
            double elevation;
            if (SelectedAirport == null)
            {
                elevation = 0;
            }
            else
            {
                elevation = SelectedAirport.Elevation;
            }
            var fx = runwayTemperatureSeries.Interpolate(Weather.Temperature, Weather.PressureAltitude(elevation));
            if (AntiIceOn)
            {
                TakeoffFactor = maxThrustAI.Interpolate(fx);
            }
            else
            {
                TakeoffFactor = maxThrust.Interpolate(fx);
            }
        }
    }
}