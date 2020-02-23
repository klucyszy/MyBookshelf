
using elibrary.api.Utils.Models;
using elibrary.data.Entities;
using System.Threading.Tasks;

namespace elibrary.api.Services.Interfaces
{
    public interface IFavoritesService
    {
        Task<PaginationModel<Book>> GetPageAsync(int pageNumber, int pageSize);
    }
}
