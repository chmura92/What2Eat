﻿using System.Collections;
using System.Collections.Generic;

namespace What2Eat.Models
{
    public class MealViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public double TotalKcal { get; set; }
        public double TotalProteins { get; set; }
        public double TotalCarbonites { get; set; }
        public double TotalFat { get; set; }
    }
}