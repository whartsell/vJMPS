using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using vJMPS.Models;
using vJMPS.Pages;
using vJMPS.ViewModels;

namespace vJMPS
{
    public class IOCSetup
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            //something magical here

            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        protected virtual void RegisterDependencies(ContainerBuilder cb)
        {
            cb.RegisterType<SetupModel>().SingleInstance();
            cb.RegisterType<SetupViewModel>().SingleInstance();
            cb.RegisterType<RootPageMasterViewModel>().SingleInstance();
            cb.RegisterType<SetupPage>().SingleInstance();
            cb.RegisterType<RootPageDetail>();
            cb.RegisterType<RootPageMaster>();
            cb.RegisterType<RootPage>();
        }
    }
}
