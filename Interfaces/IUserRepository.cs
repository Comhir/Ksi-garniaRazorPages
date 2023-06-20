using KsiegarniaProject.DTO;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KsiegarniaProject.Interfaces
{
    public interface IUserRepository
    {
        ICollection<UserDTO> GetUsers();
        UserDTO GetUserById(string id);
    }
}
