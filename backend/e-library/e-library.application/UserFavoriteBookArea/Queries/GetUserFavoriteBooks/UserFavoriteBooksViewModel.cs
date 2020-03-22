using System.Collections;
using System.Collections.Generic;

namespace Elibrary.Application.UserFavoriteBookArea.Queries.GetUserFavoriteBooks
{
    public class UserFavoriteBooksViewModel
    {
        public UserFavoriteBooksViewModel()
        {
            FavoriteBooks = new List<UserFavoriteBookDto>();
        }

        public IList<UserFavoriteBookDto> FavoriteBooks { get; private set; }
    }
}
