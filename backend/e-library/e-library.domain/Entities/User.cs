using Elibrary.Domain.Common;
using System;
using System.Collections.Generic;

namespace Elibrary.Domain.Entities
{
    public class User : BaseEntity
    {
        public Guid UserGuid { get; set; }
        public string Login { get; set; }

        public ICollection<BookOnLoan> BooksOnLoan { get; set; }
        public ICollection<UserFavoriteBook> FavoriteBooks { get; set; }
    }
}
