using Elibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Elibrary.Application.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int pageNumber = 1, int pageSize = 100);
        TEntity GetFirstOrDefualt(int id);
        TEntity GetFirstOrDefaultBy(Func<TEntity, bool> predicate);
        int Count();
        Task<TEntity> AddAsync(TEntity entity, bool autoSave = true);
    }
}
