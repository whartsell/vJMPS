
using vJMPS.ViewModels;

namespace vJMPS.Models
{
    class WeatherModel : ViewModelBase
    {
        public double Pressure { get; set; }
        public double Temperature { get; set; }
        public WindModel  Wind { get; set; }
    }
}
