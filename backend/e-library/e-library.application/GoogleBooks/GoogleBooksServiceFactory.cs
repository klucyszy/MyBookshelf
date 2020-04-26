using System.Collections.Generic;
using System.Threading.Tasks;
using Elibrary.Application.GoogleBooks.Interfaces;
using Elibrary.Domain.Entities;
using Google.Apis.Books.v1;

namespace Elibrary.Application.GoogleBooks
{
    public class GoogleBooksServiceFactory : IGoogleBooksServiceFactory
    {
        private readonly IGoogleClientInitializer _initializer;

        public GoogleBooksServiceFactory(IGoogleClientInitializer clientInitializer)
        {
            _initializer = clientInitializer;
        }

        public BooksService GetBooksService()
        {
            return new BooksService(_initializer.Initialize());
        }
    }

}
