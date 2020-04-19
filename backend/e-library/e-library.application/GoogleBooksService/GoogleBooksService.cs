using Elibrary.Application.GoogleBooksService.Interfaces;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Elibrary.Application.BooksApi
{
    public class GoogleBooksService : IGoogleBooksService
    {
        private readonly BooksService _booksService;


        public GoogleBooksService(IGoogleClientInitializer clientInitializer)
        {
            _booksService = new BooksService(clientInitializer.Initialize());
        }

        public async Task<Volumes> GetVolumes(string query)
        {
            var search = await _booksService.Mylibrary.Bookshelves.List().ExecuteAsync();

            return default;
        }
    }

    public class GoogleVolume
    {
        //
        // Summary:
        //     Volume title. (In LITE projection.)
        [JsonProperty("title")]
        public string Title { get; set; }
        //
        // Summary:
        //     Volume subtitle. (In LITE projection.)
        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }
    }
}
