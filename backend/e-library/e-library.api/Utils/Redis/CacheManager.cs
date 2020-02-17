using elibrary.data.Entities;
using Microsoft.Extensions.Caching.Distributed;

namespace elibrary.api.Utils.Redis
{
    public class CacheManager<TEntity> : ICacheManager<TEntity> where TEntity : BaseEntity
    {
        private readonly IDistributedCache _cache;

        public CacheManager(IDistributedCache cache)
        {
            _cache = cache;
        }



    }
}
