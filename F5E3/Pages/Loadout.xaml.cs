using F5E3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJMPS.Core.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace F5E3.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Loadout : ContentPage , ILoadout
	{
		public Loadout ()
		{
			InitializeComponent ();
            BindingContext = new LoadoutViewModel();
		}
	}
}