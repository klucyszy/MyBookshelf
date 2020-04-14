using Elibrary.Application.Common.Interfaces;
using System.Collections.Generic;

namespace Elibrary.Application.UserFavoriteBookArea.Queries.GetUserFavoriteBooks
{
    public class UserFavoriteBooksViewModel : Paginator
    {
        public UserFavoriteBooksViewModel()
        {
            FavoriteBooks = new List<UserFavoriteBookDto>();
        }

        public IList<UserFavoriteBookDto> FavoriteBooks { get; set; }

    }
}
