using elibrary.data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace elibrary.data.Entities
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
