using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elibrary.Application.BooksApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBooksApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Configuration.AppSettings>(configuration.GetSection("BooksApi"));

            services.AddScoped<IGoogleBookApi, GoogleBookApi>();

            return services;
        }
    }
}
