using Elibrary.Application.Common.Mappings;
using Elibrary.Domain.Entities;
using Elibrary.Domain.Enums;

namespace Elibrary.Application.UserFavoriteBookArea.Queries.GetUserFavoriteBooks
{
    public class BookDto : IMapFrom<Book>
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
    }
}
