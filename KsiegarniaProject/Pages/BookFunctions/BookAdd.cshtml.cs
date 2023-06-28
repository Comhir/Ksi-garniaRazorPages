using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using KsiegarniaProject.Models;
using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Repositories;

namespace KsiegarniaProject.Pages.BookFunctions
{
	public class BookAddModel : PageModel
	{
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        public BookAddModel(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }
		[BindProperty]
		public Author Author { get; set; }
        [BindProperty]
        public BookCreateModel newBook { get; set; }
        [BindProperty]
        public Book book { get; set; }
		[BindProperty]
		public ICollection<string> categoryList { get; set; }
        public void OnGet()
		{
			categoryList = _categoryRepository.GetCategories().Select(c => c.Name).ToList();
		}
		public IActionResult OnPost()
		{
			var x = newBook.temp.Split(' ');
			var a = newBook.BookCategories.ElementAt(0).Split(',');
			book.BookCategories = new List<BookCategory>();
            foreach (var category in a)
            {
                Category existing = _categoryRepository.GetCategoryByName(category);
				if(existing != null)
				{
					BookCategory bc = new BookCategory
					{
						Category = existing,
						CategoryId = existing.Id
					};
					book.BookCategories.Add(bc);
				}
				else
				{
					Category newCategory = new Category
					{
						Name = category
					};
					Category c = _categoryRepository.Create(newCategory);
                    BookCategory bc = new BookCategory
                    {
                        CategoryId = c.Id
                    };
                    book.BookCategories.Add(bc);
                }
            }
            Author = new Author();
			Author.FirstName = x[0];
			Author.LastName = x[1];
			newBook.Author = Author;
			book.Title = newBook.Title;
            book.Price = newBook.Quantity;
            book.Quantity = newBook.Quantity;
			book.Author = newBook.Author;
			if(_bookRepository.Create(book) == true)
			{
				return RedirectToPage("/Index");
			}
			else
			{
				return RedirectToPage("/Error");
			}
		}
        public IActionResult OnGetSearch(string term)
        {
            var categories = _categoryRepository.GetCategoriesContaining(term);
            return new JsonResult(categories);
        }
    }
}
