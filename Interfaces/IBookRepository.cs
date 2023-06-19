using KsiegarniaProject.DTO;
using KsiegarniaProject.Models;

namespace KsiegarniaProject.Interfaces
{
	public interface IBookRepository
	{
		ICollection<BookDTO> GetBooks();
		BookDTO GetBook(int id);
		bool BookExists(int id);
		bool Save();
	}
}
