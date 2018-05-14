using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vJMPS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage
    {
        private RootPageMaster MasterPage;
        public RootPage(RootPageMaster masterPage)
        {
            InitializeComponent();
            MasterPage = masterPage;
            Master = MasterPage;
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as RootPageMenuItem;
            if (item == null)
                return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            Page page;
            if (item.Id==0)
            {
                page = (Page)AppContainer.Container.Resolve(item.TargetType);
            }
            else
            {
                page = (Page)AppContainer.Airframe.Resolve(item.TargetType);
            }
            
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}