using CodeFistApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFistApproach.Entity
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> dbContext):base(dbContext) 
        { 
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        }

    }
}
