using vJMPS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Autofac;
using F5E3.ViewModels;

namespace F5E3.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreflightPage : TabbedPage
    {
        public PreflightPage ()
        {
            InitializeComponent();
            Children.Add(AppContainer.Airframe.Resolve<WeightAndBalance>());
            TOLDFieldPage Takeoff = new TOLDFieldPage(AppContainer.Airframe.Resolve<TakeoffViewModel>())
            {
                Title = "Takeoff Field"
            };
            Children.Add(Takeoff);
            TOLDFieldPage Landing = new TOLDFieldPage(AppContainer.Airframe.Resolve<LandingViewModel>())
            {
                Title = "Landing Field"
            };
            Children.Add(Landing);
        }
    }
}