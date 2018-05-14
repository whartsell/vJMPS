using Autofac;
using System.Diagnostics;
using System.Reflection;

namespace vJMPS
{
    public static class AppContainer
    {
        public static IContainer Container { get; set; }

        public static ILifetimeScope Airframe { get; private set; }


        public static void LoadAirframe(Assembly assem)
        {
            Debug.WriteLine("in load Airframe");
            if (Airframe !=null)
            {
                Debug.WriteLine("Disposing");
                Airframe.Dispose();
                Debug.WriteLine("Disposed Airframe");
            }
            Debug.WriteLine("building airframe");
            Airframe = Container.BeginLifetimeScope(builder =>
            {
                builder.RegisterAssemblyModules(assem);
            });
            Debug.WriteLine("Done building");
        }
    }

    
}
