namespace What2Eat.Models
{
    public class LikedProduct
    {
        public int LikedProductId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}