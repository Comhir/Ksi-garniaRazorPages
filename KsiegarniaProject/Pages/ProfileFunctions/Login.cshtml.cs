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
        private readonly ILogger<RegisterModel> _logger;

        public LoginModel(SignInManager<AppUser> signInManager, ILogger<RegisterModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
            LoginUser = new();
        }
        [BindProperty]
        public UserLoginModel LoginUser { get; set; }
        public string? ReturnUrl { get; set; }
        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(LoginUser.UserName, LoginUser.Password, LoginUser.RememberMe, false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Zalogowa³ siê " + LoginUser.UserName);
                    return LocalRedirect(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "Niepoprawna próba logowania");
            }
            return Page();
        }
    }
}
