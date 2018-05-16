using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJMPS;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using vJMPS.Pages;

namespace F5E3.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakeoffPage : TabbedPage
    {
        public TakeoffPage ()
        {
            InitializeComponent();
            Children.Add(AppContainer.Airframe.Resolve<TakeoffOverview>());
            Children.Add(AppContainer.Airframe.Resolve<RootPageDetail>());
        }
    }
}