using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Pages.Identity.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid) return;
            if (Credential.UserName == "admin" && Credential.Password == "admin")
            {

            }
        }
    }

    public class Credential
    {
        [Required(ErrorMessage = "Nazwa u¿ytkownika jest wymagana")]
        [Display(Name = "Nazwa u¿ytkownika")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Has³o jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Has³o")]
        public string Password { get; set; }
    }
}
