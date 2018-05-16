using Autofac;
using F5E3.Models;
using F5E3.Pages;
using F5E3.ViewModels;
using System.Collections.ObjectModel;
using vJMPS.Core;
using vJMPS.Pages;

namespace F5E3
{
    class F5E3 : Module, IAirframeModule
    {
        public string Name => "F-5E3";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TakeoffModel>().SingleInstance();
            builder.RegisterType<WandBModel>().SingleInstance();
            builder.RegisterType<WandBViewModel>().SingleInstance();
            builder.RegisterType<TakeoffViewModel>().SingleInstance();
            builder.RegisterType<TakeoffOverview>();
            builder.RegisterType<WeightAndBalance>();
            builder.RegisterType<TakeoffPage>();
           
            builder.RegisterType<F5E3>().SingleInstance().As<IAirframeModule>();
            
        }
        private static ObservableCollection<RootPageMenuItem> menuItems = new ObservableCollection<RootPageMenuItem>(new[]
            {
                    new RootPageMenuItem { Id = 0, Title = "Setup", TargetType = typeof(SetupPage) },
                    new RootPageMenuItem { Id = 1, Title = "Weight and Balance" , TargetType = typeof(WeightAndBalance)},
                    new RootPageMenuItem { Id = 2, Title = "Takeoff", TargetType = typeof(TakeoffPage) },
                    //new RootPageMenuItem { Id = 3, Title = "Takeoff Tabbed", TargetType = typeof (TakeoffTabbed)},
                    //new RootPageMenuItem { Id = 3, Title = "Ingress", TargetType = typeof(RootPageDetail) },
                    //new RootPageMenuItem { Id = 4, Title = "Combat" },
                    //new RootPageMenuItem { Id = 5, Title = "Egress"},
                    //new RootPageMenuItem { Id = 6, Title = "Landing"},
                    //new RootPageMenuItem {Id = 7, Title = "Diversion"},
                    //new RootPageMenuItem {Id = 8, Title = "Mission Card"}
                });

        public  ObservableCollection<RootPageMenuItem> MenuItems => menuItems;
    }
}
