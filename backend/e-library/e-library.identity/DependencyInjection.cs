using Elibrary.Data.Context;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace elibrary.identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGoogleIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ELibraryContext>();
            services
                //.AddAuthentication(options =>
                //{
                //    options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                //    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                //})
                .AddAuthentication()
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = false;

                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ePiQ6aj0idkdHhIXQgHh7n2Z")),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }
    }
}
