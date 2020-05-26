using Elibrary.Application.GoogleBooks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Elibrary.Application.GoogleBooks.Interfaces
{
    public interface IGoogleBooksRepository
    {
        Task<IEnumerable<Volume>> GetBooks(List<int> bookshelfsIds);
    }
}
