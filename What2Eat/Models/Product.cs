using System.ComponentModel.DataAnnotations;
using What2Eat.Enums;

namespace What2Eat.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public ProductKind ProductKind { get; set; }
        public double? KcalPer100g { get; set; }
        public double? ProteinsPer100g { get; set; }
        public double? CarbonitesPer100g { get; set; }
        public double? FatPer100g { get; set; }
    }
}