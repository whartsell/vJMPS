
using F5E3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using vJMPS.Core;
using vJMPS.ViewModels;
using Xamarin.Forms;

namespace F5E3.ViewModels
{
    public class TakeoffViewModel : ViewModelBase
    {
        private readonly TakeoffModel takeoffModel;
        public TakeoffViewModel(TakeoffModel _takeoffModel)
        {
            takeoffModel = _takeoffModel;
            CalcAndNotify();
        }

        public double TakeoffWeight { get { return takeoffModel.TakeoffWeight.SigFigs(3); } }
        public double CG { get { return takeoffModel.WandBModel.CG.SigFigs(3); } }
        public double TakeoffSpeed { get { return takeoffModel.TakeoffSpeed.SigFigs(3); } }
        public double AftStickSpeed { get { return takeoffModel.AftStickSpeed.SigFigs(3); } }
        public double ObstacleClearanceSpeed { get { return takeoffModel.ObstacleClearanceSpeed.SigFigs(3); } }
        public IList<string> Airports { get => Airport.All.Select(o => o.Name).ToList(); }
        public Airport SelectedAirport { get => takeoffModel.SelectedAirport; }

        public IList<string> Runways
        {
            get
            {

                if (SelectedAirport != null && SelectedAirport.Runways != null)
                {

                    return SelectedAirport.Runways.Select(o => o.Name).ToList();
                }
                else return new List<string> { "No Runways Availible" };
            }
        }

        public int TaxiTime //taxi time in minutes
        {
            get { return takeoffModel.TaxiTime; }
            set
            {
                takeoffModel.TaxiTime = value;
                CalcAndNotify();
            }
        }

        internal void SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var index = picker.SelectedIndex;
            Debug.WriteLine("I been picked yo");
            Debug.WriteLine(picker.SelectedItem + ":" + picker.SelectedIndex);
            if (index != -1)
            {
                takeoffModel.SelectedAirport = Airport.All[picker.SelectedIndex];
                CalcAndNotify();
            }
        }







        private void CalcAndNotify()
        {
            takeoffModel.CalculateTOandOCSpeeds();
            OnPropertyChanged("TakeoffSpeed");
            OnPropertyChanged("AftStickSpeed");
            OnPropertyChanged("ObstacleClearanceSpeed");
            OnPropertyChanged("TakeoffWeight");
            OnPropertyChanged("SelectedAirport");
            OnPropertyChanged("Runways");
        }
    }
}