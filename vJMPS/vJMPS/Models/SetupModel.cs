using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using vJMPS.Core;

namespace vJMPS.Models
{
    public class SetupModel
    {
        public IDictionary<string,Assembly> Airframes { get; set; }

        public SetupModel()
        {
            Airframes = new Dictionary<string, Assembly>();
            FindAirframeModels();
        }


        private void FindAirframeModels()
        {
            Assembly[] assems = AppDomain.CurrentDomain.GetAssemblies();
            Debug.WriteLine("hold on to your butts!");
            foreach (Assembly item in assems)
            {
                foreach (Type t in item.GetTypes())
                {
                    if (t.IsTypeOf<IAirframeModule>())
                    {
                        var obj = (IAirframeModule)item.CreateInstance(t.FullName);
                        Airframes.Add(obj.Name, item);
                    }
                }
            }
        }
    }
}
