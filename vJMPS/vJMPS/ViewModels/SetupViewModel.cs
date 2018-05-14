using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using vJMPS.Models;
using Xamarin.Forms;

namespace vJMPS.ViewModels
{
    public class SetupViewModel : ViewModelBase
    {

        public IList<string> Aircraft { get { return model.Airframes.Keys.ToList(); } }
        private SetupModel model;
        public SetupViewModel(SetupModel _model)
        {
            model = _model;
            Debug.WriteLine("SetupViewModel Setup");
            selectedAirframe = "Nothing Yet";

        }

        private string selectedAirframe;

        public string SelectedAirframe
        {
            get { return selectedAirframe; }
            set
            {
                selectedAirframe = value;
                Debug.WriteLine("ok it is getting this");
                if (model.Airframes.TryGetValue(value,out Assembly item))
                {
                    Debug.WriteLine("if check worked");
                    AppContainer.LoadAirframe(item);
                    Debug.WriteLine("AirframeLoaded");
                }
                OnPropertyChanged("SelectedAirframe");
            }
        }


        public void AircraftPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (model.Airframes.TryGetValue(picker.SelectedItem.ToString(), out Assembly item))
            {
                AppContainer.LoadAirframe(item);
                Debug.WriteLine("caught you");
            }

        }
    }
}
