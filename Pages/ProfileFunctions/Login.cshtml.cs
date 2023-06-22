using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Pages.ProfileFunctions
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LoginModel(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<RegisterModel> logger, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
        }
        [BindProperty]
        public UserLoginModel User { get; set; }
        public string ReturnUrl { get; set; }
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(User.UserName, User.Password, User.RememberMe, false);
                if (result.Succeeded)
                {

                    _logger.LogInformation("Zalogowa³ siê " + User.UserName);
                    return LocalRedirect(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "Niepoprawna próba logowania");
            }
            return Page();
        }
    }
}
