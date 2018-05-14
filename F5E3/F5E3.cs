using Autofac;
using F5E3.Models;
using F5E3.Pages;
using F5E3.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using vJMPS.Core;

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
            builder.RegisterType<Takeoff>();
            builder.RegisterType<WeightAndBalance>();
        }
    }
}
