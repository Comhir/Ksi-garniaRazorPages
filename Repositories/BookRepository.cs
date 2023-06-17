using KsiegarniaProject.Data;
using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;

namespace KsiegarniaProject.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly DataContext _context;
		public BookRepository(DataContext context)
		{
			_context = context;
		}
		public bool BookExists(int id)
		{

			return _context.Books.Any(x => x.Id == id);
		}

		public Book GetBook(int id)
		{
			return _context.Books.Where(x => x.Id == id).FirstOrDefault();
		}

		public ICollection<Book> GetBooks()
		{
			return _context.Books.ToList();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
	}
}
