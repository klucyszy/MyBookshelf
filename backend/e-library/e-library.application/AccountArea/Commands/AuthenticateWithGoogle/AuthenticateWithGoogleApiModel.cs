using Elibrary.Application.Common.Models;
using System;

namespace Elibrary.Application.AccountArea.Commands.AuthenticateWithGoogle
{
    public class AuthenticateWithGoogleApiModel : ApiModel
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }

        public AuthenticateWithGoogleApiModel(string token, DateTime expires)
        {
            Token = token;

            Expires = expires;
        }
    }
}
