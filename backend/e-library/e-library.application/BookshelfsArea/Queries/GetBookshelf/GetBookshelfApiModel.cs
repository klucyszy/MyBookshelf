using Elibrary.Application.Common.Models;
using Elibrary.Application.GoogleBooks.Models;

namespace Elibrary.Application.BookshelfsArea.Queries.GetBookshelf
{
    public class GetBookshelfApiModel : ApiModel
    {
        public GetBookshelfApiModel() { }

        public GetBookshelfApiModel(Bookshelf bookshelf)
        {
            Bookshelf = bookshelf;
        }

        public Bookshelf Bookshelf { get; set; }
    }
}
