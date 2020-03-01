using Elibrary.Domain.Common;

namespace Elibrary.Domain.Entities
{
    public class UserFavoriteBook : BaseEntity
    {                     
        public int Rate { get; set; }        
        public string Comment { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


    }
}
