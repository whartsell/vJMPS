using F5E3.Models;
using vJMPS.Core;


namespace F5E3.ViewModels
{
    public class TakeoffViewModel : TOLDViewModel
    {
        private  TakeoffModel takeoffModel;
        public TakeoffViewModel(TakeoffModel _takeoffModel)
            : base(_takeoffModel)
        {

            takeoffModel = (TakeoffModel)_model;
            CalcAndNotify();
        }

        public double TakeoffWeight { get { return takeoffModel.TakeoffWeight.SigFigs(3); } }
        public double CG { get { return takeoffModel.WandBModel.CG.SigFigs(3); } }
        public double TakeoffSpeed { get { return takeoffModel.TakeoffSpeed.SigFigs(3); } }
        public double AftStickSpeed { get { return takeoffModel.AftStickSpeed.SigFigs(3); } }
        public double ObstacleClearanceSpeed { get { return takeoffModel.ObstacleClearanceSpeed.SigFigs(3); } }
        public double TakeoffFactor { get => takeoffModel.TakeoffFactor.SigFigs(3); }
        

        public int TaxiTime //taxi time in minutes
        {
            get { return takeoffModel.TaxiTime; }
            set
            {
                takeoffModel.TaxiTime = value;
                CalcAndNotify();
            }
        }
        public bool AntiIceOn { get =>takeoffModel.AntiIceOn; set { takeoffModel.AntiIceOn = value;CalcAndNotify(); } }







        protected  override void CalcAndNotify()
        {
            base.CalcAndNotify();
            takeoffModel.CalculateTOandOCSpeeds();
            takeoffModel.CalculateTakeoffFactor();
            OnPropertyChanged("TakeoffSpeed");
            OnPropertyChanged("AftStickSpeed");
            OnPropertyChanged("ObstacleClearanceSpeed");
            OnPropertyChanged("TakeoffWeight");
            OnPropertyChanged("TakeoffFactor");
        }
    }
}