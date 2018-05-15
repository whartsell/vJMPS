using Autofac;
using System;
using System.Collections.ObjectModel;
using vJMPS.Core;
using vJMPS.Pages;

namespace TestAirframe
{

    public class TestAirframe : Module, IAirframeModule
    {
        public string Name => "Test Airframe";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestAirframe>().SingleInstance().As<IAirframeModule>();

        }

        public ObservableCollection<RootPageMenuItem> MenuItems => new ObservableCollection<RootPageMenuItem>(new[]
        {
            new RootPageMenuItem { Id = 0, Title = "Setup", TargetType = typeof(SetupPage) },
            new RootPageMenuItem { Id = 1, Title = "Test1" , TargetType = typeof(RootPageDetail)},
            new RootPageMenuItem { Id = 2, Title = "Test2", TargetType = typeof(RootPageDetail) },

            });
    }
}
