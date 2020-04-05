namespace elibrary.identity.Configuration
{
    public class IdentityOptions
    {
        public string GoogleClientId { get; set; }
        public string GoogleClientSecret { get; set; }
        public string ApplicationAudience { get; set; }
        public string ApplicationIssuer { get; set; }
        public string ApplicationSecret { get; set; }
    }
}
