using System.Collections.ObjectModel;
using vJMPS.Pages;

namespace vJMPS.Core
{
    public interface IAirframeModule
    {
        string Name { get;}

        ObservableCollection<RootPageMenuItem> MenuItems { get; }
    }
}