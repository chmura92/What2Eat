namespace What2Eat.Models
{
    public class MealProduct
    {
        public int MealProductId { get; set; }
        public Meal Meal { get; set; }
        public Product Product { get; set; }
        public double BaseWaight { get; set; }
    }
}