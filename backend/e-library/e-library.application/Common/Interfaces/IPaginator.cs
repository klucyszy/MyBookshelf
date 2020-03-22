using System;

namespace Elibrary.Application.Common.Interfaces
{
    public abstract class Paginator
    {
        public int PageNumber { get; set; }
        public int LastPage { get; set; }
        public int AllItems { get; set; }
        public int PageSize { get; set; }
        public Uri NextPageUrl { get; set; }

        public void ApplyPagination(int pageNumber, int pageSize, int allItems)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            AllItems = allItems;
            LastPage = (AllItems / PageSize) % PageSize == 0
                ? (AllItems / PageSize)
                : (AllItems / PageSize) + 1;
        }
    }
}
