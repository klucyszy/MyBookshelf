using Newtonsoft.Json;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Elibrary.Application.Common.Models
{
    public class GooglePayload
    {
        public string UserIdentifier { get; set; }
        public string Scope { get; set; }
        public string Prn { get; set; }
        public string HostedDomain { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public string Locale { get; set; }        
        public string GoogleIdToken {get; set;}
        public string GoogleRefreshToken { get; set; }

        public GooglePayload()
        {
        }

        public GooglePayload(Payload payload, string googleToken, string googleRefreshToken)
        {
            UserIdentifier = payload.Subject;
            Scope = payload.Scope;
            Prn = payload.Prn;
            HostedDomain = payload.HostedDomain;
            Email = payload.Email;
            DisplayName = payload.Name;
            FirstName = payload.GivenName;
            LastName = payload.FamilyName;
            Picture = payload.Picture;
            Locale = payload.Locale;
            GoogleIdToken = googleToken;
            GoogleRefreshToken = googleRefreshToken;
        }
    }
}
