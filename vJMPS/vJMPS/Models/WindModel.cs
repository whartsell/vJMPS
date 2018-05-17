namespace vJMPS.Models
{
    public class WindModel
    {
        public int Direction { get; set; }
        public int Magnitude { get; set; }

        public WindModel()
        {
            Direction = 0;
            Magnitude = 0;
        }
    }
}