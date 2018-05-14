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
