using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using vJMPS.Models;
using vJMPS.Pages;

namespace vJMPS.ViewModels
{
    public class SetupViewModel : ViewModelBase
    {

        public IList<string> Aircraft { get { return model.Airframes.Keys.ToList(); } }
        private SetupModel model;
        public SetupViewModel(SetupModel _model)
        {
            model = _model;
            model.PropertyChanged += Model_PropertyChanged;
            Debug.WriteLine("SetupViewModel Setup");
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        public string SelectedAirframe
        {
            get { return model.SelectedAirframe.Key; }
            set
            {
                if (model.Airframes.ContainsKey(value))
                {
                    model.SelectedAirframe = new KeyValuePair<string, Assembly>(value, model.Airframes[value]);
                    OnPropertyChanged("SelectedAirframe");
                }
            }
        }

        
    }
}
