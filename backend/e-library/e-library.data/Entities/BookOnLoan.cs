using System;

namespace elibrary.data.Entities
{
    public class BookOnLoan : BaseEntity
    {
        public DateTime IssueDate { get; set; }
        public DateTime? DueReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal? FineAmount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string BookISBN { get; set; }
        public Book Book { get; set; }

    }
}
