using Elibrary.Application.Common.Constants;
using Elibrary.Application.Extensions;
using Google.Apis.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace elibrary.identity.Google.OAuth2
{
    public class GoogleHttpInitializer : IConfigurableHttpClientInitializer
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GoogleHttpInitializer(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Initialize(ConfigurableHttpClient httpClient)
        {
            var idToken = _httpContextAccessor.HttpContext.User.Claims
                .TryGetClaim(JwtApplicationClaimsNames.GoogleIdToken);

            if (!string.IsNullOrEmpty(idToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, idToken);
            }
        }
    }
}
