using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Continental.Producao.Domain.Produtos;
using Continental.Producao.Infra.Data;
using Continental.Producao.Infra.Data.Produtos;
using Continental.Producao.Infra.Data.UoW;
using System;

namespace Continental.Producao.API
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

            var assembly = AppDomain.CurrentDomain.Load("Continental.Producao.Application");
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProducaoReadContext, ProducaoReadContext>();

            services.AddDbContext<ProducaoContext>(option=> option
                                .UseSqlite(Configuration
                                            .GetConnectionString("DefaultConnection"), 
                                            o=> o.MigrationsAssembly("Continental.Producao.API")));
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
                    await context.Response.WriteAsync("Api da 'Continental.Producao' funcionando!");
                });
            });
        }
    }
}
