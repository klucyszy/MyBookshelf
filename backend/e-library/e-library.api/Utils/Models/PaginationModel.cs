
using elibrary.data.Entities;
using System;
using System.Collections.Generic;

namespace elibrary.api.Utils.Models
{
    public class PaginationModel<TEntity> where TEntity : BaseEntity
    {
        public List<TEntity> Data { get; set; }
        public int PageNumber { get; set; }
        public int LastPage { get; set; }
        public int PageSize { get; set; }
        public Uri NextPageUrl { get; set; }
    }
}
