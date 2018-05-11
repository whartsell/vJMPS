using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace vJMPS
{
    class IOCSetup
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            //something magical here

            return containerBuilder.Build();
        }
    }
}
