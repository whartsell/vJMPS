using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace vJMPS.Core
{
    public class Airport
    {
        public string Name { get; set; }
        public IList<Runway> Runways { get; set; }
        public double Elevation { get; set; }

        public static IList<Airport> All { get; set; }
        static Airport()
        {
            All = new ObservableCollection<Airport>
            {
                new Airport
                {
                    Name = "Test1",
                    Elevation = 0,
                    Runways = new ObservableCollection<Runway>
                    {
                        new Runway
                        {
                            Name = "18",
                            heading = 175,
                            slope = 0.0,
                            UsableDistance = 5800
                        },
                        new Runway
                        {
                            Name = "36",
                            heading = 355,
                            slope = 0.0,
                            UsableDistance = 5800
                        }
                    }
                },
                new Airport
                {
                    Name = "Test2",
                    Elevation = 1420,
                    Runways = new ObservableCollection<Runway>
                    {
                        new Runway
                        {
                            Name = "9",
                            heading = 91,
                            slope = 0.0,
                            UsableDistance = 10000
                        },
                        new Runway
                        {
                            Name = "27",
                            heading = 271,
                            slope = 0.0,
                            UsableDistance = 10000
                        }
                    }
                }
            };
        }
    }
}
