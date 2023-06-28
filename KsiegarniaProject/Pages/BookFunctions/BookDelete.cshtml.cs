using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;
using KsiegarniaProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KsiegarniaProject.Pages.BookFunctions
{
    public class BookDeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Book Book { get; set; }
        private readonly IBookRepository _bookRepository;
        public BookDeleteModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult OnGet(int id)
        {
            _bookRepository.Delete(id);
            return RedirectToPage("/Index");
        }
    }
}
