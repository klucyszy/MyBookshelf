using System;
using System.Collections.Generic;

namespace elibrary.data.Entities
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; }

        public ICollection<BookOnLoan> BooksOnLoan { get; set; }
        public ICollection<UserFavoriteBook> FavoriteBooks { get; set; }
    }
}
