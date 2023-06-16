using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using KsiegarniaProject.Models;
namespace KsiegarniaProject.Pages.BookFunctions
{
	public class BookAddModel : PageModel
	{
		public BookAddModel():base()
		{
		}

		[BindProperty]
		public Book newBook { get; set; }
		[BindProperty]
		[Required(ErrorMessage = "Cena jest wymagana.")]
		[Range(0, Int32.MaxValue, ErrorMessage = "Cena nie mo¿e byæ ujemna")]
		public int price { get; set; }

		public void OnGet()
		{
		}
		public IActionResult OnPost()
		{
			LoadDB();
			productDB.Create(newBook);
			SaveDB();
			return RedirectToPage("List");
		}

	}
}
