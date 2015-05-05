namespace What2Eat.Models
{
    public class UserAtributes
    {
        public int UserAtributesId { get; set; }
        public int Age { get; set; }
        public int Haight { get; set; } // in cm
        public double Weight { get; set; }
        public bool IsVegan { get; set; }
        public string Sex { get; set; }
    }
}