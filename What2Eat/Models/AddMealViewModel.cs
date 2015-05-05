using System.Collections.Generic;
using What2Eat.Enums;

namespace What2Eat.Models
{
    public class AddMealViewModel
    {
        public string Name { get; set; }
        public MealCategory MealCategory { get; set; }
        public virtual ICollection<Product> AllProducts { get; set; }

        public int? Product1 { get; set; }
        public int? Product2 { get; set; }
        public int? Product3 { get; set; }
        public int? Product4 { get; set; }

        public double? MP1 { get; set; }
        public double? MP2 { get; set; }
        public double? MP3 { get; set; }
        public double? MP4 { get; set; }
    }
}