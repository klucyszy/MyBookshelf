using Elibrary.Application.Common.Models;
using Elibrary.Application.GoogleBooks.Models;
using System.Collections.Generic;
using System.Linq;

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
        public int? ItemCount => Items?.Count();
    }
}
