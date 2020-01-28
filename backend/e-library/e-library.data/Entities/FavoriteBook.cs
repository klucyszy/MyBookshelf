using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace elibrary.data.Entities
{
    public class UserFavoriteBook
    {
        public int Id { get; set; }
        
        public string BookISBN { get; set; }
        
        public string Title { get; set; }
        
        public string Author { get; set; }
        
        [Range(1,10)]
        public int Rate { get; set; }
        
        [MaxLength(512)]
        public string Comment { get; set; }
    }
}
