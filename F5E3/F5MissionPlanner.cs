using System;
using System.Collections.Generic;
using vJMPS.Core;
namespace F5E3
{
    public class F5MissionPlanner
    {
        public Airport Departure { get; set; }
        public Airport Recovery { get; set; }
        public Airport Alternate { get; set; }

        public F5MissionPlanner(Airport departure,Airport recovery,Airport alternate)
        {
            Departure = departure;
            Recovery = recovery;
            Alternate = alternate;
            

        }

        
    }
}
