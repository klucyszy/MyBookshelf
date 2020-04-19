using elibrary.identity.Configuration;
using Elibrary.Application.GoogleBooksService.Interfaces;
using Google.Apis.Http;
using Google.Apis.Services;
using Microsoft.Extensions.Options;

namespace elibrary.identity.Google.OAuth2
{
    public class GoogleClientInitializer : BaseClientService.Initializer, IGoogleClientInitializer
    {
        public GoogleClientInitializer(
            IConfigurableHttpClientInitializer configurableHttpClientInitializer,
            IOptions<IdentityOptions> options)
        {
            ApplicationName = options?.Value.GoogleClientId;
            ApiKey = options?.Value.GoogleApiKey;
            HttpClientInitializer = configurableHttpClientInitializer;
        }

        public BaseClientService.Initializer Initialize()
        {
            return this;
        }
    }
}
