using Google.Apis.Books.v1.Data;
using System.Threading.Tasks;

namespace Elibrary.Application.GoogleBooksService.Interfaces
{
    public interface IGoogleBooksService
    {
        Task<Volumes> GetVolumes(string query);
    }
}
