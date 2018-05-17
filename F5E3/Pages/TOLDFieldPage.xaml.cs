using F5E3.Models;
using F5E3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace F5E3.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TOLDFieldPage : ContentPage
	{
		public TOLDFieldPage (TOLDViewModel _vm)
		{
			InitializeComponent ();
            BindingContext = _vm;
            AirportPicker.SelectedIndexChanged += _vm.SelectedAirportIndexChanged;
            RunwayPicker.SelectedIndexChanged += _vm.SelectedRunwayIndexChanged;
        }
	}
}