using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace KsiegarniaProject.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public ProfileModel(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public string Id { get; set; }
        public AppUser User { get; set; }
        public async void OnGetAsync(string id)
        {
            Id = id;
            User = await _userManager.FindByIdAsync(id);
            
        }
    }
}
