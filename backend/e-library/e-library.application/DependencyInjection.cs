using AutoMapper;
using Elibrary.Application.GoogleBooks;
using Elibrary.Application.Common.Mappings;
using Elibrary.Application.GoogleBooks.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Elibrary.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            serviceCollection.AddScoped<IGoogleBooksServiceFactory, GoogleBooksServiceFactory>();

            return serviceCollection;
        }
    }
}
