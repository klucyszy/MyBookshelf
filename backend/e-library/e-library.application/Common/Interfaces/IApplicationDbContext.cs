using Elibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Elibrary.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<BookOnLoan> BooksOnLoan { get; set; }
        DbSet<UserFavoriteBook> UserFavoriteBooks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
