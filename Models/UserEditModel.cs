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
        public string? UserName { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Hasła są różne<br />")]
        public string? ConfirmPassword { get; set; }
    }
}
