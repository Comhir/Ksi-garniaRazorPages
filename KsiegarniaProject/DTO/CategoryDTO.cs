using KsiegarniaProject.Models;

namespace KsiegarniaProject.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
