using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using vJMPS.Core;
using vJMPS.Pages;
using vJMPS.ViewModels;
using Autofac;

namespace vJMPS.Models
{
    public class SetupModel : ViewModelBase
    {
        public IDictionary<string, Assembly> Airframes { get; set; }

        public SetupModel()
        {
            Airframes = new Dictionary<string, Assembly>();
            FindAirframeModels();
            MenuItems = new ObservableCollection<RootPageMenuItem>(new[] { new RootPageMenuItem { Id = 0, Title = "Setup", TargetType = typeof(SetupPage) } });
            

        }

        private KeyValuePair<string, Assembly> selectedAirframe;
        public KeyValuePair<string, Assembly> SelectedAirframe
        {
            get { return selectedAirframe; }
            set
            {

                Debug.WriteLine("ok it is getting this");
                if (Airframes.TryGetValue(value.Key, out Assembly item))
                {
                    selectedAirframe = value;
                    Debug.WriteLine("if check worked");
                    AppContainer.LoadAirframe(item);
                    Debug.WriteLine("AirframeLoaded");
                    var module =  AppContainer.Airframe.Resolve<IAirframeModule>();
                    MenuItems = module.MenuItems;
                }
                OnPropertyChanged("SelectedAirframe");
                OnPropertyChanged("MenuItems");
            }
        }


        public ObservableCollection<RootPageMenuItem> MenuItems { get; internal set; }

        private void FindAirframeModels()
        {
            Assembly[] assems = AppDomain.CurrentDomain.GetAssemblies();
            Debug.WriteLine("hold on to your butts!");
            foreach (Assembly item in assems)
            {
                foreach (Type t in item.GetTypes())
                {
                    if (t.IsTypeOf<IAirframeModule>())
                    {
                        var obj = (IAirframeModule)item.CreateInstance(t.FullName);
                        Airframes.Add(obj.Name, item);

                    }
                }
            }
        }
    }
}
