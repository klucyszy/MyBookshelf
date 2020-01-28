using elibrary.data.Enums;
using System.ComponentModel.DataAnnotations;

namespace elibrary.data.Entities
{
    public class Book
    {
        public string ISBN { get; set; }
     
        [Required, MaxLength(50)]
        public string Title { get; set; }
        
        [Required, MaxLength(50)]
        public string Author { get; set; }
        
        [Required]
        public Category Category { get; set; }
    }
}
