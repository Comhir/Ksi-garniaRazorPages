using KsiegarniaProject.Data;
using KsiegarniaProject.Models;

namespace KsiegarniaProject
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if(!_context.Books.Any())
            {
                var bookAuthors = new List<BookAuthor>()
                {
                    new BookAuthor()
                    {
                        Book = new Book()
                        {
                            Title = "Lord of the Rings",
                            BookCategories = new List<BookCategory>()
                            {
                                new BookCategory { Category = new Category() {Name = "Fantasy" } }
                            }
                        },
                        Author = new Author {
                            FirstName = "J.R.R",
                            LastName = "Tolkien"
                        }                   
                    },
                    new BookAuthor()
                    {
                        Book = new Book()
                        {
                            Title = "Zbrodnia i kara",
                            BookCategories = new List<BookCategory>()
                            {
                                new BookCategory { Category = new Category() {Name = "Powieść kryminalna" } }
                            }
                        },
                        Author = new Author {
                            FirstName = "Fiodor",
                            LastName = "Dostojewski"
                        }
                    }

                };
                _context.BookAuthors.AddRange(bookAuthors);
                _context.SaveChanges();
            }
        }
    }
}
