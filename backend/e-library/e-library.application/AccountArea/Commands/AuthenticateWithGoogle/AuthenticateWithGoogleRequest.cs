using Newtonsoft.Json;
namespace Elibrary.Application.AccountArea.Commands.AuthenticateWithGoogle
{
    public class AuthenticateWithGoogleRequest
    {
        [JsonProperty(PropertyName = "id_token")]
        public string Token { get; set; }
    }
}
