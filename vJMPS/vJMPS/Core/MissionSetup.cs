using System;
using System.Collections.Generic;
using System.Text;

namespace vJMPS.Core
{
    public class MissionSetup
    {
        public IList<string> Aircraft { get; set; }
        public IList<Airport> Airports { get; set; }

        public MissionSetup()
        {
            Aircraft = new List<string>();
            Airports = new List<Airport>();
            stubData();
        }

        private void stubData()
        {
            Aircraft.Add("F-5E3");
            Aircraft.Add("AV-8b");
            var ap1 = new Airport
            {
                Name = "Test1",
                Elevation = 1420
            };
            var runway1 = new Runway
            {
                Name = "27",
                heading = 267,
                UsableDistance = 5001,
                slope = 0
            };
            ap1.Runways.Add(runway1);
            Airports.Add(ap1);
        }
    }


}
