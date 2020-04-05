using Newtonsoft.Json;

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
    }
}
