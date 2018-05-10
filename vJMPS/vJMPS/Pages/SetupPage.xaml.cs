using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJMPS.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vJMPS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage : ContentPage
    {
       
        public SetupPage()
        {
           
            

            InitializeComponent();
            BindingContext = new MissionSetup();

        }


        
    }
}