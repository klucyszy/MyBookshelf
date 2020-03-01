using Elibrary.Domain.Common;
using System;

namespace Elibrary.Domain.Entities
{
    public class BookOnLoan : BaseEntity
    {
        public DateTime IssueDate { get; set; }
        public DateTime? DueReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal? FineAmount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
