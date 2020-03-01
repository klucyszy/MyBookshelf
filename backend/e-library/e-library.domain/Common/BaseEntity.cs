using System;

namespace Elibrary.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
