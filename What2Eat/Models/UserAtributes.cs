using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using What2Eat.Enums;
namespace What2Eat.Models
{
    public class UserAtributes
    {
       // public int UserAtributesId { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Height { get; set; } // in cm
        [Required]
        public double Weight { get; set; }
        [Required]
        public bool IsVegan { get; set; }
        [Required]
        public SexKind Sex { get; set; }
        public Dictionary<string, double> ActivityLevel = new Dictionary<string, double>()
        {
            {"Little or no Exercise/ desk job", 1.2},
            {"Light exercise/ sports 1 – 3 days/ week", 1.375},
            {"Moderate Exercise, sports 3 – 5 days/ week", 1.55},
            {"Heavy Exercise/ sports 6 – 7 days/ week", 1.725},
            {"Very heavy exercise/ physical job/ training 2 x/ day", 1.9}
        };
    }
}