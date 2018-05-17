using vJMPS.ViewModels;

namespace vJMPS.Models
{
    public class WeatherModel : ViewModelBase
    {
        public double Pressure { get; set; }
        public double Temperature { get; set; }
        public WindModel  Wind { get; set; }

        public WeatherModel()
        {
            Pressure = 29.92; //inhg
            Temperature = 15; //C          
            Wind = new WindModel();
        }

        public double PressureAltitude(double elevation)
        {
           
            return (29.92 - Pressure)*1000 + elevation;
        }
    }
}
