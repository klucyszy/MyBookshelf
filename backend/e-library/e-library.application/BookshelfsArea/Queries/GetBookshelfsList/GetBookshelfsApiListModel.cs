using Elibrary.Application.Common.Models;
using Elibrary.Application.GoogleBooks.Models;
using System.Collections.Generic;

namespace Elibrary.Application.BookshelfsArea.Queries.GetBookshelfsList
{
    public class GetBookshelfsApiListModel : ApiModel
    {
        public GetBookshelfsApiListModel() { }

        public GetBookshelfsApiListModel(IEnumerable<Bookshelf> items)
        {
            Items = items;
        }

        public IEnumerable<Bookshelf> Items { get; set; }
    }
}
