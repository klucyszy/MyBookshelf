using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Elibrary.Application.BooksApi
{
    public interface IGoogleBookApi
    {
        Task<Volumes> GetVolumes(string query);
    }

    public class GoogleBookApi : IGoogleBookApi
    {
        private readonly BooksService _booksService;

        public GoogleBookApi()
        {
            _booksService = new BooksService(new BaseClientService.Initializer 
            {
                ApplicationName = "920200399874-ph38c06nsdv3sskcjjsiinna3uh5ojo7.apps.googleusercontent.com",
                ApiKey = "AIzaSyC3s9cIKWGHEYMgclRO07GfvvmBpSoZ4ug"
            });
        }

        public async Task<Volumes> GetVolumes(string query)
        {
            Volumes search = await _booksService.Volumes.List(query).ExecuteAsync();

            //Volumes volumes = await _booksService.Volumes.Recommended.List().ExecuteAsync();

            return search;
        }
    }

    public class GoogleApiInitializer : BaseClientService.Initializer
    {

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
