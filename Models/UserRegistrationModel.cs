using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Models
{
    public class UserRegistrationModel
    {

        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana<br />")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Email jest wymagany<br />")]
        [EmailAddress(ErrorMessage = "Email jest niepoprawny<br />")]
        [Display(Name = "Adres email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane<br />")]
        [MinLength(5, ErrorMessage = "Hasło musi mieć co najmniej 5 znaków<br />")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Pole jest wymagane<br />")]
        [Compare("Password", ErrorMessage = "Hasła są różne<br />")]
        [Display(Name = "Powtórz hasło")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Rola")]
        [Required(ErrorMessage = "Nie wybrano roli<br />")]
        public string Role { get; set; }
    }
}
