using System;
using System.ComponentModel.DataAnnotations;

namespace elibrary.data.Entities
{
    public class UserFavoriteBook : BaseEntity
    {                     
        [Range(1,10)]
        public int Rate { get; set; }        
        public string Comment { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


    }
}
