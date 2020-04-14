using Elibrary.Application.BooksApi;
using System.Collections.Generic;

namespace Elibrary.Application.BooksArea.Queries.SearchBooks
{
    public class SearchBooksViewModel
    {
        public SearchBooksViewModel()
        {
            Results = new List<GoogleVolume>();
        }

        public List<GoogleVolume> Results { get; set; }
    }
}
