using Google.Apis.Books.v1;

namespace Elibrary.Application.GoogleBooks.Interfaces
{
    public interface IGoogleBooksServiceFactory
    {
        BooksService GetBooksService();
    }
}
