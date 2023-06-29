using AutoMapper;
using KsiegarniaProject.Data;
using KsiegarniaProject.DTO;
using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KsiegarniaProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(IDataContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public UserDTO GetUserById(string id)
        {
            var userRole = _context.AppUserRoles.Where(u => u.UserId.Equals(id)).FirstOrDefault();
            if (userRole == null)
            {
                return null;
            }
            var roleId = userRole.RoleId;
            var role = _roleManager.Roles.Where(r => r.Id.Equals(roleId)).FirstOrDefault();
            return _userManager.Users
                .AsNoTracking()
                .Where(u => u.Id.Equals(id))
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    Email = u.Email,
                    Role = role.Name

                }).FirstOrDefault();
        }

        public ICollection<UserDTO> GetUsers()
        {
            return _userManager.Users
                .AsNoTracking()
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    Email = u.Email,
                    Role = _context.AppUserRoles.Join(_roleManager.Roles, a => a.RoleId, b => b.Id, (a,b) => b.Name).FirstOrDefault()

                }).ToList();
        }

        public bool ModifyUser(string id, UserEditModel user)
        {
            AppUser appUser = _context.AppUsers.Where(u => u.Id.Equals(id)).FirstOrDefault();
            if (appUser == null) { return false; }
            if (appUser.UserName != user.UserName) 
            {
                return false; 
            }
        }
    }
}
