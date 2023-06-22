using KsiegarniaProject.DTO;
using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Sockets;

namespace KsiegarniaProject.Pages.ProfileFunctions
{
    public class ProfileEditModel : PageModel
    {
        public string Id { get; set; }
        public UserEditModel User { get; set; }
        public string? ReturnUrl { get; set; }

        private readonly IUserRepository _userRepository;
        public ProfileEditModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void OnGet(string id, string? returnUrl = null)
        {
            Id = id;
            UserDTO temp = _userRepository.GetUserById(id);
            User = new UserEditModel();
            User.UserName = temp.UserName != null ? temp.UserName : null;
            User.FirstName = temp.FirstName != null ? temp.FirstName : null;
            User.LastName = temp.LastName != null ? temp.LastName : null;
            User.Email = temp.Email != null ? temp.Email : null;
            User.Password = null;
            User.ConfirmPassword = null;
            ReturnUrl = returnUrl;
        }
    }
}
