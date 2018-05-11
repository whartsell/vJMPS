
using F5E3.Models;
using vJMPS.Core;

namespace F5E3.ViewModels
{
    public class TakeoffViewModel : ViewModelBase
    {
        public int TaxiTime //taxi time in minutes
        {
            get { return takeoffModel.TaxiTime; }
            set
            {
                takeoffModel.TaxiTime = value;
                CalcAndNotify();
            }
        }
        public double TakeoffWeight { get { return takeoffModel.TakeoffWeight.SigFigs(3); } }
        public double CG { get { return takeoffModel.WandBModel.CG.SigFigs(3); } }
        public double TakeoffSpeed { get { return takeoffModel.TakeoffSpeed.SigFigs(3); } }
        public double AftStickSpeed { get { return takeoffModel.AftStickSpeed.SigFigs(3); } }
        public double ObstacleClearanceSpeed { get { return takeoffModel.ObstacleClearanceSpeed.SigFigs(3); } }
        private readonly TakeoffModel takeoffModel;

        public TakeoffViewModel(TakeoffModel _takeoffModel)
        {
            takeoffModel = _takeoffModel;
            CalcAndNotify();
        }

        private void CalcAndNotify()
        {
            takeoffModel.CalculateTOandOCSpeeds();
            OnPropertyChanged("TakeoffSpeed");
            OnPropertyChanged("AftStickSpeed");
            OnPropertyChanged("ObstacleClearanceSpeed");
            OnPropertyChanged("TakeoffWeight");
        }
    }
}