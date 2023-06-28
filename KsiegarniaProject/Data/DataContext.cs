using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KsiegarniaProject.Data
{
    public class DataContext : IdentityDbContext<AppUser, IdentityRole, string>, IDataContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<IdentityRole> AppRoles { get; set; }
        public virtual DbSet<IdentityUserRole<string>> AppUserRoles { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            AppUsers = base.Users;
            AppRoles = base.Roles;
            AppUserRoles = base.UserRoles;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
            builder.Entity<BookCategory>()
                .HasOne(b => b.Book)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<BookCategory>()
                .HasOne(b => b.Category)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
 
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
