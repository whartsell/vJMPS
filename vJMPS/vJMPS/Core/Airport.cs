using System;
using System.Collections.Generic;
using System.Text;

namespace vJMPS.Core
{
    public class Airport
    {
        public string Name { get; set; }
        public IList<Runway> Runways { get; set; }
        public double Elevation { get; set; }

        public Airport()
        {
            Runways = new List<Runway>();
        }
    }
}
