using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Models
{
    public class UserRegistrationModel
    {

        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Email jest niepoprawny")]
        [Display(Name = "Adres email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [MinLength(5, ErrorMessage = "Hasło musi mieć co najmniej 5 znaków")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła są różne")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Rola")]
        [Required(ErrorMessage = "Nie wybrano roli")]
        public string Role { get; set; }
    }
}
