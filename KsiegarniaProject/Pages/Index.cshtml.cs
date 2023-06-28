using KsiegarniaProject.DTO;
using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KsiegarniaProject.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        public IndexModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public ICollection<BookDTO> Books { get; set; }
        public void OnGet()
        {
            Books = _bookRepository.GetBooks();
            
        }

    }
}