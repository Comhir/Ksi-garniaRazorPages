using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public ICollection<BookCategory> BookCategories { get; set; }
		public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
