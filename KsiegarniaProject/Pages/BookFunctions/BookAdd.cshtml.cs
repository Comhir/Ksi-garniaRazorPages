using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using KsiegarniaProject.Models;
using KsiegarniaProject.Interfaces;

namespace KsiegarniaProject.Pages.BookFunctions
{
	public class BookAddModel : PageModel
	{
        private readonly IBookRepository _bookRepository;
        public BookAddModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
		[BindProperty]
		public Author Author { get; set; }
        [BindProperty]
        public BookCreateModel newBook { get; set; }
        [BindProperty]
        public Book book { get; set; }
        public void OnGet()
		{
		}
		public IActionResult OnPost()
		{
			var x = newBook.temp.Split(' ');
			Author = new Author();
			Author.FirstName = x[0];
			Author.LastName = x[1];
			newBook.Author = Author;
			book.Title = newBook.Title;
            book.Price = newBook.Quantity;
            book.Quantity = newBook.Quantity;
			book.Author = newBook.Author;
            _bookRepository.Create(book);
			var y = _bookRepository.Save();
			return RedirectToPage("/Index");
		}

	}
}
