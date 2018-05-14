using Autofac;
using vJMPS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vJMPS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPageMaster : ContentPage
    {
        public ListView ListView;
        public RootPageMaster()
        {
            InitializeComponent();
            BindingContext = AppContainer.Container.Resolve<RootPageMasterViewModel>();
            ListView = MenuItemsListView;
        }


    }
}