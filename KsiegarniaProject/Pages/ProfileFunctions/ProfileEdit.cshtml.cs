using KsiegarniaProject.DTO;
using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Sockets;

namespace KsiegarniaProject.Pages.ProfileFunctions
{
    [Authorize]
    public class ProfileEditModel : PageModel
    {
        public string Id { get; set; }
        [BindProperty]
        public UserEditModel EditUser { get; set; }
        public string? ReturnUrl { get; set; }

        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileEditModel(IUserRepository userRepository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void OnGet(string id, string? returnUrl = null)
        {
            Id = id;
            UserDTO temp = _userRepository.GetUserById(id);
            EditUser = new UserEditModel
            {
                UserName = temp.UserName,
                FirstName = temp.FirstName ?? null,
                LastName = temp.LastName ?? null,
                Email = temp.Email,
                OldPassword = null,
                NewPassword = null
            };
            ReturnUrl = returnUrl;
        }

        public IUserRepository Get_userRepository()
        {
            return _userRepository;
        }

        public async Task<IActionResult> OnPost(string id, string? returnUrl = null)
        {
            Id = id;
            returnUrl ??= Url.Content("~/");
            bool changed = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            AppUser temp = _userRepository.GetAppUserById(Id);
            if (temp == null)
            {
                return Page();
            }
            if(EditUser.UserName != temp.UserName)
            {
                temp.UserName = EditUser.UserName;
                changed = true;
            }
            if(EditUser.FirstName != temp.FirstName)
            {
                temp.FirstName = EditUser.FirstName;
                changed = true;
            }
            if (EditUser.LastName != temp.LastName)
            {
                temp.LastName = EditUser.LastName;
                changed = true;
            }
            if (EditUser.Email != temp.Email)
            {
                temp.Email = EditUser.Email;
                changed = true;
            }
            if (changed == true)
            {
                var result = _userRepository.ModifyUser(temp);
                if(result <= 0)
                {
                    return Page();
                } 
            }
            if (EditUser.OldPassword == null)
            {
                return Page();
            }
            var userInstance = _userManager.FindByIdAsync(Id);
            var passwordResult = await _userManager.ChangePasswordAsync(userInstance.Result, EditUser.OldPassword, EditUser.NewPassword);
            if (passwordResult.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(userInstance.Result);
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}
