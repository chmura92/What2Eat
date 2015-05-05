using What2Eat.Enums;

namespace What2Eat.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public ProductKind ProductKind { get; set; }
    }
}