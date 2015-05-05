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
     
    }
}