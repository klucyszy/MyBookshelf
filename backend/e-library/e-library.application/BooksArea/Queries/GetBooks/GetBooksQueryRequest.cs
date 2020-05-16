using System.Collections.Generic;

namespace Elibrary.Application.BooksArea.Queries.GetBooks
{
    public class GetBooksQueryRequest
    {
        public GetBooksQueryRequest()
        {
            BookshelfIds = new List<int>();
        }

        public IList<int> BookshelfIds { get; set; }
    }
}
