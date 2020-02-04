using elibrary.data.Entities;
using System.Collections.Generic;

namespace elibrary.data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
    }
}
