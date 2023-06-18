using KsiegarniaProject.Data;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Identity;

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
            if(!_context.BookAuthors.Any())
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

            if (!_context.Users.Any())
            {
                string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
                string ADMIN_ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
                string MANAGER_ROLE_ID = "4f593732-1151–435c-99df-1c6a05b52071";
                string WORKER_ROLE_ID = "9faaa0de-bcc1–437e-9db9-30d6dbe8de2f";

                var users = new List<AppUser>()
                {
                    new AppUser()
                    {
                        Id = ADMIN_ID,
                        FirstName = "Pan",
                        LastName = "Admin",
                        UserName = "Administrator",
                        NormalizedUserName = "ADMINISTRATOR",
                        Email = "admin@test.com",
                        NormalizedEmail = "ADMIN@TEST.COM",
                        EmailConfirmed = true
                    }
                };

                var roles = new List<IdentityRole>()
                {
                    new IdentityRole()
                    {
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR",
                        Id = ADMIN_ROLE_ID,
                        ConcurrencyStamp = ADMIN_ROLE_ID
                    },
                    new IdentityRole()
                    {
                        Name = "Kierownik",
                        NormalizedName = "KIEROWNIK",
                        Id = MANAGER_ROLE_ID,
                        ConcurrencyStamp = MANAGER_ROLE_ID
                    },
                    new IdentityRole()
                    {
                        Name = "Pracownik",
                        NormalizedName = "PRACOWNIK",
                        Id = WORKER_ROLE_ID,
                        ConcurrencyStamp = WORKER_ROLE_ID
                    }
                };

                PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
                users[0].PasswordHash = hasher.HashPassword(users[0], "supersecret");

                var userRole = new IdentityUserRole<string>()
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                };

                _context.Users.AddRange(users);
                _context.Roles.AddRange(roles);
                _context.UserRoles.Add(userRole);
                _context.SaveChanges();
            }
        }
    }
}
