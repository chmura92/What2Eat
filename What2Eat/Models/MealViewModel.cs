using System.Collections;
using System.Collections.Generic;
using What2Eat.Enums;

namespace What2Eat.Models
{
    public class MealViewModel
    {
        public string MealViewModelId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public double TotalKcal { get; set; }
        public double TotalProteins { get; set; }
        public double TotalCarbonites { get; set; }
        public double TotalFat { get; set; }
        public double TotalWeight { get; set; }
        public UserAtributes UserAtributes { get; set; }
        public double Bmi { get; set; }
        public double Bmr { get; set; }
        public MealCategory? MealCategory { get; set; }
        public int DayPercent { get; set; }
    }
}