using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Pages.Account
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

        }
    }

    public class Credential
    {
        [Required(ErrorMessage = "Nazwa u¿ytkownika jest wymagana")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Has³o jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
