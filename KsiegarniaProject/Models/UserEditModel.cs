using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KsiegarniaProject.Models
{
    public class UserEditModel
    {
        [Display(Name = "Imię")]
        public string? FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string? LastName { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string UserName { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Stare hasło")]
        public string? OldPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string? NewPassword { get; set; }
    }
}
