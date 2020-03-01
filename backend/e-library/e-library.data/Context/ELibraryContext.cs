using Elibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elibrary.Data.Context
{
    public class ELibraryContext : DbContext
    {
        public ELibraryContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookOnLoan> BooksOnLoan { get; set; }
        public DbSet<UserFavoriteBook> UserFavoriteBooks { get; set; }

        public ELibraryContext(DbContextOptions<ELibraryContext> opts)
            : base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ELibraryContext).Assembly);
        }
    }
}
