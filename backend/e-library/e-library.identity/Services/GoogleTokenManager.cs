using elibrary.identity.Configuration;
using Elibrary.Application.Common.Constants;
using Elibrary.Application.Common.Models;
using Elibrary.Application.Identity;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
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

        public async Task<GooglePayload> ValidateBearerTokenAsync(string authCode)
        {
            var authorizationCodeFlow = new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets()
                    {
                        ClientId = _identityOptions.GoogleClientId,
                        ClientSecret = _identityOptions.GoogleClientSecret
                    }
                });

            TokenResponse tokenResponse = await authorizationCodeFlow
                .ExchangeCodeForTokenAsync("me", authCode, "http://localhost:8080", CancellationToken.None);

            UserCredential userCredential = new UserCredential(authorizationCodeFlow, "me", tokenResponse);

            BooksService booksService = new BooksService(new BaseClientService.Initializer
            {
                HttpClientInitializer = userCredential
            });

            Bookshelves test = await booksService.Mylibrary.Bookshelves.List().ExecuteAsync();

            Payload payload = await ValidateAsync(tokenResponse.IdToken, GetValidationSettings());

            return new GooglePayload(payload, tokenResponse.AccessToken, tokenResponse.RefreshToken);
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
                new Claim(JwtApplicationClaimsNames.DisplayName, payload.DisplayName),
                new Claim(JwtApplicationClaimsNames.Locale, payload.Locale),
                new Claim(JwtApplicationClaimsNames.Picture, payload.Picture),
                new Claim(JwtRegisteredClaimNames.Azp, _identityOptions.ApplicationAudience),
                new Claim(JwtRegisteredClaimNames.GivenName, payload.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, payload.LastName),
                new Claim(JwtRegisteredClaimNames.Email, payload.Email),
                new Claim(JwtRegisteredClaimNames.Sub, payload.UserIdentifier),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtApplicationClaimsNames.GoogleIdToken, payload.GoogleIdToken)
                //new Claim(JwtApplicationClaimsNames.GoogleRefreshToken, payload?.GoogleRefreshToken)
            };
        }
    }
}
