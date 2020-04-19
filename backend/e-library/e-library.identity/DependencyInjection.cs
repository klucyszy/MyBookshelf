using elibrary.identity.Google.OAuth2;
using elibrary.identity.Services;
using Elibrary.Application.GoogleBooksService.Interfaces;
using Elibrary.Application.Identity;
using Elibrary.Data.Context;
using Google.Apis.Http;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace elibrary.identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGoogleIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            IdentityModelEventSource.ShowPII = true;
            var privateKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Identity:ApplicationSecret")?.Value));
            var creds = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            services
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ELibraryContext>();
            services
                .AddAuthentication(cfg =>
                {
                    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = creds.Key,

                        ValidateAudience = true,
                        ValidAudience = configuration.GetSection("Identity:ApplicationAudience")?.Value,

                        ValidateIssuer = true,
                        ValidIssuer = configuration.GetSection("Identity:ApplicationIssuer")?.Value
                    };

                    cfg.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            return Task.FromResult(context);
                        },
                        OnTokenValidated = context =>
                        {
                            return Task.FromResult(context);
                        },
                        OnAuthenticationFailed = context =>
                        {
                            return Task.FromResult(context);
                        }
                    };
                });

            services.Configure<Configuration.IdentityOptions>(configuration.GetSection("Identity"));
            services.AddScoped<IConfigurableHttpClientInitializer, GoogleHttpInitializer>();
            services.AddScoped<IGoogleClientInitializer, GoogleClientInitializer>();
            services.AddScoped<ITokenManager, GoogleTokenManager>();

            return services;
        }
    }
}
