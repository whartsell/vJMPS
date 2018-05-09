using System;
using System.Collections.Generic;
using vJMPS.Core;
namespace F5E3
{
    public class F5MissionPlanner
    {
        public static readonly double DefaultEmptyWeight = 15050;
        public static readonly double DefaultMissileWeight = 342;
        public static readonly double DefaultCG = 17.5;
        public static readonly double DefaultTakeoffFactor = 12;
        public static readonly bool DefaultClimbProfile = false;
        public static readonly double DefaultDragIndex = 0;

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
