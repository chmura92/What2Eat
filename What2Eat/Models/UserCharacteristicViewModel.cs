using What2Eat.Enums;

namespace What2Eat.Models
{
    public class UserCharacteristicViewModel
    {
        public UserAtributes UserAtributes { get; set; }
        public double Bmi { get; set; }
        public double Bmr { get; set; }
        public MealCategory? MealCategory { get; set; }
    }
}