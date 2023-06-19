using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KsiegarniaProject.Data
{
    public class DataContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
            builder.Entity<BookCategory>()
                .HasOne(b => b.Book)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<BookCategory>()
                .HasOne(b => b.Category)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
 
            base.OnModelCreating(builder);
        }
    }
}
