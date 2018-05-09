using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJMPS.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace vJMPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage : ContentPage
    {

        public MissionSetup Setup { get; set; }
        //MissionSetup setup;
       
        public SetupPage()
        {
           
            

            InitializeComponent();
            //BindingContext = new MissionSetup();
            Setup = new MissionSetup();

        }


        
    }
}