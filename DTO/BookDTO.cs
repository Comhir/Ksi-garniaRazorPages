using KsiegarniaProject.Models;

namespace KsiegarniaProject.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public ICollection<Category> Categories { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
