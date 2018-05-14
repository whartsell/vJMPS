using Autofac;
using System.Reflection;

namespace vJMPS
{
    public static class AppContainer
    {
        public static IContainer Container { get; set; }

        public static ILifetimeScope Airframe { get; private set; }


        public static void LoadAirframe(Assembly assem)
        {
            Airframe.Dispose();
            Airframe = Container.BeginLifetimeScope(builder =>
            {
                builder.RegisterAssemblyModules(assem);
            });
        }
    }

    
}
