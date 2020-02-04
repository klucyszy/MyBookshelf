using System.Collections.Generic;
using System.Linq;
using elibrary.data.Context;
using elibrary.data.Entities;
using Microsoft.EntityFrameworkCore;

namespace elibrary.data.Repository
{
    public class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly ELibraryContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public DataRepository(ELibraryContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
    }
}
