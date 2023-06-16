using KsiegarniaProject.Models;

namespace KsiegarniaProject.Interfaces
{
	public interface IBookRepository
	{
		ICollection<Book> GetBooks();
		Book GetBook(int id);
		bool BookExists(int id);
		bool Save();
	}
}
