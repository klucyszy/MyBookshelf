
using Elibrary.Api.Utils.Models;
using Elibrary.Domain.Entities;
using System.Threading.Tasks;

namespace Elibrary.Api.Services.Interfaces
{
    public interface IFavoritesService
    {
        Task<PaginationModel<Book>> GetPageAsync(int pageNumber, int pageSize);
    }
}
