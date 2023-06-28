using AutoMapper;
using KsiegarniaProject.DTO;
using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace KsiegarniaProject.Pages.ProfileFunctions
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        public ProfileModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Id { get; set; }
        public UserDTO User { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            Id = id;
            User = _userRepository.GetUserById(id);
            if (User == null)
            {
                return RedirectToPage("ProfileNotFound");
            }
            return Page();
        }
    }
}
