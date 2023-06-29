using KsiegarniaProject.DTO;
using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KsiegarniaProject.Pages.BookFunctions
{
    [Authorize]
    public class BookDetailsModel : PageModel
    {
        public int Id { get; set; }
        public BookDTO Book { get; set; }
        private readonly IBookRepository _bookRepository;

        public BookDetailsModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Id = id;
            Book = _bookRepository.GetBook(id);
            if (Book == null)
            {
                return RedirectToPage("Error");
            }
            return Page();
        }
    }
}
