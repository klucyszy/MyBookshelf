using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Elibrary.Application.Extensions
{
    public static class ClaimsReaderExtension
    {
        public static string TryGetClaim(this IEnumerable<Claim> claims, string type)
        {
            return claims.Where(x => x.Type == type).SingleOrDefault()?.Value;
        }
    }
}
