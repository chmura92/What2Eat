using What2Eat.Enums;

namespace What2Eat.Models
{
    public class Meal
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        public MealCategory MealCategory { get; set; }
    }
}