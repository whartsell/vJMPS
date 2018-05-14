using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using vJMPS.Pages;

namespace vJMPS.ViewModels
{
    class RootPageMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<RootPageMenuItem> MenuItems { get; set; }
        public RootPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<RootPageMenuItem>(new[]
            {
                    new RootPageMenuItem { Id = 0, Title = "Setup", TargetType = typeof(SetupPage) },
                    //new RootPageMenuItem { Id = 1, Title = "Weight and Balance" , TargetType = test},
                    new RootPageMenuItem { Id = 2, Title = "Takeoff" },
                    new RootPageMenuItem { Id = 3, Title = "Ingress" },
                    new RootPageMenuItem { Id = 4, Title = "Combat" },
                    new RootPageMenuItem { Id = 5, Title = "Egress"},
                    new RootPageMenuItem { Id = 6, Title = "Landing"},
                    new RootPageMenuItem {Id = 7, Title = "Diversion"},
                    new RootPageMenuItem {Id = 8, Title = "Mission Card"}
                });
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
