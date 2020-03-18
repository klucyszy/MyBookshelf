using Elibrary.Data.Context;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

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
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                })
                .AddGoogle(options =>
                {
                    options.ClientId = "920200399874-4qmdqvfdgt4mq5i8jsqfdf8it3j68sjl.apps.googleusercontent.com";
                    options.ClientSecret = "3_h-otETGGfUHt-Gnz7i4Raw";
                });

            return services;
        }
    }
}
