using F5E3.ViewModels;
using vJMPS.Core.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace F5E3.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeightAndBalance : ContentPage , ILoadout
	{
		public WeightAndBalance (WandBViewModel vm)
		{
			InitializeComponent ();
            BindingContext = vm;
		}
	}
}