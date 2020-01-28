using System;
using System.ComponentModel.DataAnnotations;

namespace elibrary.data.Entities
{
    public class BookOnLoan
    {
        public int Id { get; set; }
        
        [Required]
        public Guid UserId { get; set; }
        
        [Required]
        public string BookISBN { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime DueReturnDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public decimal FineAmount { get; set; }


    }
}
