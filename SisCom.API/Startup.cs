using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SisCom.Domain.Produtos;
using SisCom.Infra.Data;
using SisCom.Infra.Data.Produtos;
using SisCom.Infra.Data.UoW;
using System;

namespace SisCom.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var assembly = AppDomain.CurrentDomain.Load("SisCom.Application");
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ISisComReadContext, SisComReadContext>();

            services.AddDbContext<SisComContext>(option=> option
                                .UseSqlite(Configuration
                                            .GetConnectionString("DefaultConnection"), 
                                            o=> o.MigrationsAssembly("SisCom.API")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("SisCom API funcionando!");
                });
            });
        }
    }
}
