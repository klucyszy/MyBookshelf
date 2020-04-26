using Google.Apis.Services;

namespace Elibrary.Application.GoogleBooks.Interfaces
{
    public interface IGoogleClientInitializer
    {
        BaseClientService.Initializer Initialize();
    }
}
