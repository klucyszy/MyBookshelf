using AutoMapper;
using Elibrary.Application.BooksApi;
using Elibrary.Application.Common.Mappings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Elibrary.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            serviceCollection.AddBooksApi(configuration);

            return serviceCollection;
        }
    }
}
