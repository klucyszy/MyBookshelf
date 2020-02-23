using elibrary.api.Services.Interfaces;
using elibrary.api.Utils.Models;
using elibrary.api.Utils.Redis;
using elibrary.data.Entities;
using elibrary.data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elibrary.api.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly ICacheManager _cacheManager;
        private readonly IRepository<Book> _repository;

        public FavoritesService(ICacheManager cacheManager, IRepository<Book> repository)
        {
            _cacheManager = cacheManager;
            _repository = repository;
        }

        public async Task<PaginationModel<Book>> GetPageAsync(int pageNumber, int pageSize)
        {
            string redisKey = $"favorites_user_guid_{pageNumber}_{pageSize}";

            PaginationModel<Book> result;
            if(await _cacheManager.IsCachedAsync(redisKey))
            {
                result = await _cacheManager.GetObjectAsync<PaginationModel<Book>>(redisKey);
            }
            else
            {
                List<Book> data = _repository.GetAll(pageNumber, pageSize).ToList();
                int allItems = _repository.Count();
                result  = new PaginationModel<Book>(pageNumber, pageSize, allItems, data);
                await _cacheManager.SetObjectAsync(redisKey, result);
            }

            return result;
        }
    }
}
