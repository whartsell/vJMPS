using F5E3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using vJMPS.Core;
using vJMPS.Models;
using vJMPS.ViewModels;
using Xamarin.Forms;

namespace F5E3.ViewModels
{
    public abstract class TOLDViewModel : ViewModelBase
    {
        protected TOLDModel _model;
        public double Pressure
        {
            get => _model.Weather.Pressure;
            set
            {
                _model.Weather.Pressure = value;
                OnPropertyChanged("Pressure");
            }
        }
        protected TOLDViewModel(TOLDModel model)
        {
            _model = model;
            Notify();
        }

        public IList<string> Airports { get => Airport.All.Select(o => o.Name).ToList(); }
        public Airport SelectedAirport { get => _model.SelectedAirport; }
        public Runway SelectedRunway { get => _model.SelectedRunway; private set { _model.SelectedRunway = value; } }

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

        internal void SelectedAirportIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var index = picker.SelectedIndex;
            Debug.WriteLine("I been picked yo");
            Debug.WriteLine(picker.SelectedItem + ":" + picker.SelectedIndex);
            if (index != -1)
            {
                _model.SelectedAirport = Airport.All[picker.SelectedIndex];
                OnPropertyChanged("SelectedAirport");
                OnPropertyChanged("Runways");
                SelectedRunway = null;
                OnPropertyChanged("SelectedRunway");
                CalcAndNotify();
            }
        }

        internal void SelectedRunwayIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var index = picker.SelectedIndex;
            Debug.WriteLine("I been picked yo");
            Debug.WriteLine(picker.SelectedItem + ":" + picker.SelectedIndex);
            if (index != -1)
            {
                if (SelectedAirport != null && SelectedAirport.Runways != null)
                {
                    _model.SelectedRunway = SelectedAirport.Runways[picker.SelectedIndex];
                    OnPropertyChanged("SelectedRunway");
                    CalcAndNotify();
                }

            }

        }



        private void Notify()
        {


        }

        protected virtual void CalcAndNotify()
        {
            Notify();
        }
    }
}
