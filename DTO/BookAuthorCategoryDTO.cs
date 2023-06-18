using KsiegarniaProject.Models;


namespace KsiegarniaProject.DTO
{
    public class BookAuthorCategoryDTO
    {
        public int Id;
        public string Title;
        public Author Author;
        public Category Category;
        public decimal Price;
        public int Quantity;
    }
}
