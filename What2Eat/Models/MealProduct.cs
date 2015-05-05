namespace What2Eat.Models
{
    public class MealProduct
    {
        public int MealProductId { get; set; }
        public  virtual Product Product { get; set; }
        public double BaseWaight { get; set; }
    }
}