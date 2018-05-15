

using vJMPS.ViewModels;

namespace F5E3.Models
{
    public class TakeoffModel : ViewModelBase
    {


        public WandBModel WandBModel { get; private set; }
        public double TakeoffSpeed { get; internal set; }
        public double AftStickSpeed { get; internal set; }
        public double ObstacleClearanceSpeed { get; internal set; }
        public double TakeoffWeight { get; internal set; }
        private int _taxiTime;
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

        public TakeoffModel(WandBModel _wandBModel)
        {
            WandBModel = _wandBModel;
            TakeoffWeight = WandBModel.GrossWeight;
        }
    }
}