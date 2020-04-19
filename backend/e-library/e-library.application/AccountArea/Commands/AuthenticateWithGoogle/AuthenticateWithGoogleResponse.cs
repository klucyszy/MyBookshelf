using System;

namespace Elibrary.Application.AccountArea.Commands.AuthenticateWithGoogle
{
    public class AuthenticateWithGoogleResponse
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }

        public AuthenticateWithGoogleResponse(string token, DateTime expires)
        {
            Token = token;

            Expires = expires;
        }
    }
}
