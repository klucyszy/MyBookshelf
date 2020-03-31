using Newtonsoft.Json;

namespace Elibrary.Application.AccountArea.Queries
{
    public class AuthenticateGoogleTokenRequest
    {
        [JsonProperty("id_token")]
        public string Token { get; set; }
    }
}
