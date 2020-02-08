using System;
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

        public TEntity GetFirstOrDefualt(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public TEntity GetFirstOrDefaultBy(Func<TEntity, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach(var item in _dbSet)
            {
                if (predicate(item)) return item;
            }

            return default;
        }
    }
}
