using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elibrary.Application.Common.Interfaces;
using Elibrary.Data.Context;
using Elibrary.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Elibrary.Data.Repository
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

        public IEnumerable<TEntity> GetAll(int pageNumber = 1, int pageSize = 100)
        {
            var skipNumber = (pageNumber - 1) * pageSize;

            return _dbSet
                .Skip(skipNumber)
                .Take(pageSize)
                .AsEnumerable();
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

        public int Count()
        {
            return _dbSet.Count();
        }

        public async Task<TEntity> AddAsync(TEntity entity, bool autoSave = true)
        {
            await _dbSet.AddAsync(entity);

            if (autoSave)
                await _context.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }
    }
}
