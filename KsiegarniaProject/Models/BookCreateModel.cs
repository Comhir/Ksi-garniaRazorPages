using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Models
{
    public class BookCreateModel
    {
        public int Id { get; set; }
        [Display(Name = "Podaj Tytuł Książki")]
        public string Title { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        [Display(Name = "Podaj Imię i Nazwisko autora Książki")]
        public Author Author { get; set; }
        [Display(Name = "Podaj Cenę Książki")]
        public decimal Price { get; set; }
        [Display(Name = "Podaj ilość danej książki")]
        public int Quantity { get; set; }
        public string temp { get; set; }
    }
}
