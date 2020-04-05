using elibrary.identity.Configuration;
using Elibrary.Application.Common.Models;
using Elibrary.Application.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace elibrary.identity.Services
{
    public class GoogleTokenManager : ITokenManager
    {
        private readonly IdentityOptions _identityOptions;

        public GoogleTokenManager(IOptions<IdentityOptions> identityOptions)
        {
            _identityOptions = identityOptions.Value;
        }

        public ApplicationToken GenerateBearerTokenAsync(GooglePayload payload)
        {
            var privateKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_identityOptions.ApplicationSecret));
            var creds = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddSeconds(60 * 60 * 8);

            var token = new JwtSecurityToken(
                issuer: _identityOptions.ApplicationIssuer,
                audience: _identityOptions.ApplicationAudience,
                claims: GenerateClaims(payload),
                expires: expires,
                signingCredentials: creds
                );

            return new ApplicationToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = expires
            };
        }

        public async Task<GooglePayload> ValidateBearerTokenAsync(string token)
        {
            Payload payload = await ValidateAsync(token, GetValidationSettings());

            GooglePayload googlePayload = new GooglePayload
            {
                UserIdentifier = payload.Subject,
                Scope = payload.Scope,
                Prn = payload.Prn,
                HostedDomain = payload.HostedDomain,
                Email = payload.Email,
                DisplayName = payload.Name,
                FirstName = payload.GivenName,
                LastName = payload.FamilyName,
                Picture = payload.Picture,
                Locale = payload.Locale
            };

            return googlePayload;
        }

        private ValidationSettings GetValidationSettings()
        {
            return new ValidationSettings
            {
                Audience = new[] { _identityOptions.GoogleClientId },
            };
        }

        private IEnumerable<Claim> GenerateClaims(GooglePayload payload)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Iss, _identityOptions.ApplicationIssuer),
                new Claim("name", payload.DisplayName),
                new Claim("locale", payload.Locale),
                new Claim("picture", payload.Picture),
                new Claim(JwtRegisteredClaimNames.Azp, _identityOptions.ApplicationAudience),
                new Claim(JwtRegisteredClaimNames.Aud, _identityOptions.ApplicationAudience),
                new Claim(JwtRegisteredClaimNames.GivenName, payload.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, payload.LastName),
                new Claim(JwtRegisteredClaimNames.Email, payload.Email),
                new Claim(JwtRegisteredClaimNames.Sub, payload.UserIdentifier),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
        }
    }
}
