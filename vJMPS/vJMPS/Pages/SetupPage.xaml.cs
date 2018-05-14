using vJMPS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vJMPS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage : ContentPage
    {
       
        public SetupPage(SetupViewModel viewModel)
        {
           
            

            InitializeComponent();
            BindingContext = viewModel;
            AircraftPicker.SelectedIndexChanged += viewModel.AircraftPicker_SelectedIndexChanged;

        }

       

        

        
    }
}