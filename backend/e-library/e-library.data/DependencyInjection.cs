using Elibrary.Application.Common.Interfaces;
using Elibrary.Data.Context;
using Elibrary.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elibrary.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ELibraryContext>(opts => opts.UseSqlServer(
                    configuration.GetConnectionString("ELibraryDB"),
                    sqlOpts => sqlOpts.MigrationsAssembly(typeof(ELibraryContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ELibraryContext>());
            services.AddScoped(typeof(IRepository<>), typeof(DataRepository<>));

            return services;
        }
    }
}
