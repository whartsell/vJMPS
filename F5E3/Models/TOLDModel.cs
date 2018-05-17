using System;
using System.Collections.Generic;
using System.Text;
using vJMPS.Core;
using vJMPS.Models;
using vJMPS.ViewModels;

namespace F5E3.Models
{
    public abstract class TOLDModel : ViewModelBase
    {
        public WeatherModel Weather { get; set; }
        public Airport SelectedAirport { get; internal set; }
        public Runway SelectedRunway { get; internal set; }

        protected TOLDModel()
        {
            Weather = new WeatherModel();
        }
    }
}
