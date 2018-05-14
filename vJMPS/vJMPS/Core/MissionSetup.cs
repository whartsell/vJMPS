using System.Collections.Generic;
using System.Reflection;
using vJMPS.ViewModels;

namespace vJMPS.Core
{
    public class MissionSetup : ViewModelBase
    {
        public IDictionary<string,Assembly> Aircraft { get; set; }
        public IList<Airport> Airports { get; set; }

        public MissionSetup()
        {
            Aircraft = new Dictionary<string,Assembly>();
            Airports = new List<Airport>();
            stubData();
        }

        private void stubData()
        {
            Aircraft.Add("F-5E3" , Assembly.GetExecutingAssembly());
            Aircraft.Add("AV-8b",Assembly.GetExecutingAssembly());
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
