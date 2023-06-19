using KsiegarniaProject.DTO;
using KsiegarniaProject.Models;

namespace KsiegarniaProject.Interfaces
{
	public interface IBookRepository
	{
		ICollection<BookAuthorCategoryDTO> GetBooks();
		Book GetBook(int id);
		bool BookExists(int id);
		bool Save();
	}
}
