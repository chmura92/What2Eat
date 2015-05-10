using System.Collections.Generic;

namespace What2Eat.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Proteins { get; set; }
        public double Carbonites { get; set; }
        public double Fat { get; set; }
        public double Kcal { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public double TotalCarbonites { get; set; }
        public double TotalFat { get; set; }
        public double TotalKcal { get; set; }
        public double TotalProteins { get; set; }
        public double TotalWeight { get; set; }
    }
}