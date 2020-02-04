using System;
using System.ComponentModel.DataAnnotations;

namespace elibrary.data.Entities
{
    public class UserFavoriteBook : BaseEntity
    {
        public int Id { get; set; }                       
        [Range(1,10)]
        public int Rate { get; set; }        
        public string Comment { get; set; }

        public string BookISBN { get; set; }
        public Book Book { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }


    }
}
