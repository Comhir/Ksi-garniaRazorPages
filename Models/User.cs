using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? OwnerId { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

    }
}
