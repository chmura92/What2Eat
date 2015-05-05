using System.Collections;
using System.Web.UI;

namespace What2Eat.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual UserAtributes Atributes { get; set; }
    }
}