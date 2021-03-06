﻿using Elibrary.Application.Common.Interfaces;
using Elibrary.Application.Identity;
using Elibrary.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Elibrary.Application.AccountArea.Commands.AuthenticateWithGoogle
{
    public class AuthenticateWithGoogleCommand : IRequest<AuthenticateWithGoogleApiModel>
    {
        public string AuthCode { get; set; }

        public class AuthenticateWithGoogleCommandHandler : IRequestHandler<AuthenticateWithGoogleCommand, AuthenticateWithGoogleApiModel>
        {
            private readonly IApplicationDbContext _context;
            private readonly ITokenManager _tokenManager;

            public AuthenticateWithGoogleCommandHandler(
                IApplicationDbContext context,
                ITokenManager tokenManager)
            {
                _context = context;
                _tokenManager = tokenManager;
            }

            public async Task<AuthenticateWithGoogleApiModel> Handle(AuthenticateWithGoogleCommand request, CancellationToken cancellationToken)
            {
                Common.Models.GooglePayload payload = await _tokenManager.ValidateBearerTokenAsync(request.AuthCode);
                await CreateUserIfNotExist(payload.UserIdentifier, payload.Email);

                var token = _tokenManager.GenerateBearerTokenAsync(payload);

                return new AuthenticateWithGoogleApiModel(token.Token, token.Expires);
            }

            private async Task CreateUserIfNotExist(string uid, string email)
            {
                var user = _context.Users.FirstOrDefault(u => u.UserIdentifier == uid);
                if (user == null)
                {
                    _context.Users.Add(new User
                    {
                        UserIdentifier = uid,
                        CreateDate = DateTime.UtcNow,
                        CreatedBy = uid,
                        Login = email
                    });

                    await _context.SaveChangesAsync(new CancellationTokenSource().Token);
                }
            }
        }
    }
}
