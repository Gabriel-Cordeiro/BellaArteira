using System;
using System.Data;

using AutoMapper;

using BellaArteira.Api.Util;
using BellaArteira.Core.Interfaces.Repositories;
using BellaArteira.Repositories;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Npgsql;

namespace BellaArteiraApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(Configuration.GetConnectionString("dbConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.ConfigureSwagger();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/api/docs/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Bella'rteira - API");
                c.RoutePrefix = "api/docs";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
