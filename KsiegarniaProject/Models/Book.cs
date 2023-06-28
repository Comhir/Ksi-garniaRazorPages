using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Models
{
	public class Book
	{
		public int Id { get; set; }
		
		public string Title { get; set; }
		public ICollection<BookCategory> BookCategories { get; set; }
		public Author Author { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }

    }
}
