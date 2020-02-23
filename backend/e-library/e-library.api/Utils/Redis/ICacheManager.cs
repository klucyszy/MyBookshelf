using elibrary.data.Entities;
using System.Threading.Tasks;

namespace elibrary.api.Utils.Redis
{
    public interface ICacheManager
    {
        Task<bool> IsCachedAsync(string key);
        Task<TObject> GetObjectAsync<TObject>(string key);
        Task SetObjectAsync<TObject>(string key, TObject value);
    }
}
