using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KsiegarniaProject.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana<br />")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane<br />")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
