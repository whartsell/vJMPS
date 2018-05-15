using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using vJMPS.Models;
using vJMPS.Pages;

namespace vJMPS.ViewModels
{
    class RootPageMasterViewModel : INotifyPropertyChanged
    {
        private SetupModel model;
        public ObservableCollection<RootPageMenuItem> MenuItems { get => model.MenuItems; }
        public RootPageMasterViewModel(SetupModel _model)
        {
            model = _model;
            model.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
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
