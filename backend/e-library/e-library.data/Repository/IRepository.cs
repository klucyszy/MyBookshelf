using elibrary.data.Entities;
using System;
using System.Collections.Generic;

namespace elibrary.data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int pageNumber = 1, int pageSize = 100);
        TEntity GetFirstOrDefualt(int id);
        TEntity GetFirstOrDefaultBy(Func<TEntity, bool> predicate);
        int Count();
    }
}
