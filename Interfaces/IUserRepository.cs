using KsiegarniaProject.DTO;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Identity;

namespace KsiegarniaProject.Interfaces
{
    public interface IUserRepository
    {
        ICollection<UserDTO> GetUsers();
        UserDTO GetUserById(string id);
    }
}
