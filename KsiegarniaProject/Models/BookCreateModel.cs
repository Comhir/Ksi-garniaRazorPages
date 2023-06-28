using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Models
{
    public class BookCreateModel
    {
        public int Id { get; set; }
        [Display(Name = "Podaj Tytuł Książki")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Title { get; set; }
        public ICollection<string> BookCategories { get; set; }
        [Display(Name = "Podaj Imię i Nazwisko autora Książki")]
        [Required(ErrorMessage = "Autor jest wymagany")]
        public Author Author { get; set; }
        [Display(Name = "Podaj Cenę Książki")]
        [Required(ErrorMessage = "Cena jest wymagana")]
        public decimal Price { get; set; }
        [Display(Name = "Podaj ilość danej książki")]
        [Required(ErrorMessage = "Ilość jest wymagana")]
        [Range(1, 9999)]
        public int Quantity { get; set; }
        [Display(Name = "Podaj Imię i Nazwisko autora Książki")]
        [Required(ErrorMessage = "Autor jest wymagany")]
        public string temp { get; set; }
    }
}
