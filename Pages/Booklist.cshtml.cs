using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KsiegarniaProject.Pages
{
    public class BooklistModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        public BooklistModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public ICollection<Book> books { get; set; }
        public void OnGet()
        {
            books = _bookRepository.GetBooks();
        }

    }
}
