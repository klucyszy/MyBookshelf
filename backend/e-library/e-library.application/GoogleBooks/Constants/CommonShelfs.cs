using Elibrary.Application.GoogleBooks.Models;
using System.Collections.Generic;
using System.Linq;

namespace Elibrary.Application.GoogleBooks.Constants
{
    public static class CommonGoogleBookshelfs
    {
        public static List<BookshelfBase> BaseGoogleBookshelfs => GoogleBookshelfs.Where(x => x.Id < 5).ToList();
        public static List<int> BaseGoogleBookshelfIds => BaseGoogleBookshelfs.Select(x => x.Id.Value).ToList();
        public static List<int> GoogleBookshelfIds => GoogleBookshelfs.Select(x => x.Id.Value).ToList();
        public static List<BookshelfBase> GoogleBookshelfs => new List<BookshelfBase>
        {
            new BookshelfBase(0, "Favorites"),
            new BookshelfBase(1, "Purchased"),
            new BookshelfBase(2, "To read"),
            new BookshelfBase(3, "Reading now"),
            new BookshelfBase(4, "Have read"),
            new BookshelfBase(5, "Reviewed"),
            new BookshelfBase(6, "Recently viewed"),
            new BookshelfBase(7, "My Google eBooks"),
            new BookshelfBase(8, "Books for you"),
            new BookshelfBase(9, "Browsing history"),
        };        
    }
}