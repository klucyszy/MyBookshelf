using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Elibrary.Api.Configuration;
using AutoMapper;
using Elibrary.Api.Utils.Redis;
using Elibrary.Api.Services.Interfaces;
using Elibrary.Api.Services;
using Elibrary.Data.Context;
using Elibrary.Data.Repository;

namespace Elibrary.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(opts =>
            {
                opts.Configuration = Configuration.GetSection(AppSettings.RedisSection)[AppSettings.RedisConfiguration];
                opts.InstanceName = Configuration.GetSection(AppSettings.RedisSection)[AppSettings.RedisInstanceName];
                        
            });
            
            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            //Add swagger document generator
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "e-library API", Version = "v1.0" });
            });

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ELibraryContext>(opts =>
                {
                    opts.UseSqlServer(
                        Configuration.GetConnectionString(AppSettings.ELibraryDBName),
                        sqlOpts => sqlOpts.MigrationsAssembly(typeof(ELibraryContext).GetTypeInfo().Assembly.GetName().Name)
                    );
                });

            //Register dependencies
            services.AddScoped(typeof(IRepository<>), typeof(DataRepository<>));
            services.AddScoped(typeof(ICacheManager), typeof(CacheManager));
            services.AddScoped(typeof(IFavoritesService), typeof(FavoritesService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "e-library v1.0 API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
