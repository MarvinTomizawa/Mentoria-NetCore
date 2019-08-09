using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integracao.Data;
using Integracao.Data.Interfaces;
using Integracao.Data.Repositories;
using Integracao.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Integracao
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<IntegracaoContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<ICargoService, CargoService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
                x.AllowCredentials();
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
