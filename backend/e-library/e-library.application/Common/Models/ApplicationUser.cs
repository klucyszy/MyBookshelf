using Elibrary.Application.Extensions;
using System.Collections.Generic;
using System.Security.Claims;

namespace Elibrary.Application.Common.Models
{
    public class ApplicationUser
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string DisplayName { get; }
        public string Email { get; }

        public ApplicationUser(IEnumerable<Claim> claims)
        {
            Id = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            FirstName = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
            LastName = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname");
            DisplayName = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
            Email = claims.TryGetClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
        }
    }
}
