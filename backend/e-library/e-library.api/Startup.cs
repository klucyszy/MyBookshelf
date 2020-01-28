using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using elibrary.data.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace elibrary.api
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
            services.AddControllers();

            //Add swagger document generator
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "e-library API", Version = "v1.0" });
            });

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ELibraryContext>(opts =>
                {
                    opts.UseSqlServer(
                        "connectionstring",
                        sqlOpts => sqlOpts.MigrationsAssembly(typeof(ELibraryContext).GetTypeInfo().Assembly.GetName().Name)
                    );
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
