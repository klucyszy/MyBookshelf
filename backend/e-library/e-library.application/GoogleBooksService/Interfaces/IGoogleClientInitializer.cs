using Google.Apis.Services;

namespace Elibrary.Application.GoogleBooksService.Interfaces
{
    public interface IGoogleClientInitializer
    {
        BaseClientService.Initializer Initialize();
    }
}
