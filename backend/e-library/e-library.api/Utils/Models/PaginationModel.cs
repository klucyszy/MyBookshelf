
using Elibrary.Domain.Common;
using System;
using System.Collections.Generic;

namespace Elibrary.Api.Utils.Models
{
    public class PaginationModel<TEntity> where TEntity : BaseEntity
    {
        public PaginationModel(int pageNumber, int pageSize, int allItems, List<TEntity> Data)
        {
            Data = Data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            AllItems = allItems;
            LastPage = CountLastPage();
        }

        public List<TEntity> Data { get; set; }
        public int PageNumber { get; set; }
        public int LastPage { get; set; }
        public int AllItems { get; set; }
        public int PageSize { get; set; }
        public Uri NextPageUrl { get; set; }

        private int CountLastPage()
        {
            return (AllItems / PageSize) % PageSize == 0
                ? (AllItems / PageSize)
                : (AllItems / PageSize) + 1;

        }
    }
}
