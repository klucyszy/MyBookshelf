using Elibrary.Application.GoogleBooksService.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elibrary.Application.BooksApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBooksApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGoogleBooksService, GoogleBooksService>();
            return services;
        }
    }
}
