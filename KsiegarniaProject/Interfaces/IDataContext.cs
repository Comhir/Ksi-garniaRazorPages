using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KsiegarniaProject.Interfaces
{
    public interface IDataContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<BookCategory> BookCategories { get; set; }
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<IdentityRole> AppRoles { get; set; }
        DbSet<IdentityUserRole<string>> AppUserRoles { get; set; }
        int SaveChanges();
    }
}
