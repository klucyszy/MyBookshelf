using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Elibrary.Api.Utils.Redis
{
    public class CacheManager : ICacheManager
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;

        public CacheManager(IDistributedCache cache)
        {
            _cache = cache;
            _options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.UtcNow.AddMinutes(30)
            };
        }

        public async Task<TObject> GetObjectAsync<TObject>(string key)
        {
            string value = await _cache.GetStringAsync(key);

            return value != null
                ? JsonConvert.DeserializeObject<TObject>(value)
                : default;
        }

        public async Task<bool> IsCachedAsync(string key)
        {
            return await _cache.GetStringAsync(key) != null;
        }

        public async Task SetObjectAsync<TObject>(string key, TObject value)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value), _options);
        }
    }
}
