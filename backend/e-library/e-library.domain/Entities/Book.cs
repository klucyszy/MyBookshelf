using Elibrary.Domain.Common;
using Elibrary.Domain.Enums;
using System.Collections.Generic;

namespace Elibrary.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string ISBN { get; set; }    
        public string Title { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }

        public ICollection<BookOnLoan> BooksOnLoan { get; set; }
        public ICollection<UserFavoriteBook> UseFavoriteBooks { get; set; }


    }
}
