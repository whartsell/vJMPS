using F5E3.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace F5E3.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Takeoff : ContentPage
	{
        //private TakeoffViewModel vm;
		public Takeoff (TakeoffViewModel _vm)
		{
			InitializeComponent ();
            BindingContext = _vm;
		}
	}
}