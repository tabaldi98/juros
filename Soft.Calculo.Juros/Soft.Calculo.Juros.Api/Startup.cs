using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Soft.Calculo.Juros.Domain.EntidadeJuros;
using Soft.Calculo.Juros.Domain.EntidadeJuros.CalculaJuros;
using Soft.Calculo.Juros.Infra;
using Soft.Calculo.Juros.Infra.Data.EntidadeJuros;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Soft.Calculo.Juros.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<CalculaJurosCommand>());

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Soft.Calculo.Juros.Api", Version = "v1" });
            });

            services.AddMediatR(typeof(CalculaJurosCommandHandler));

            services.AddScoped<IJuroRepositorio, JuroRepositorio>();

            services.AddHttpClient(Constantes.TAXA_JUROS_HTTP_CLIENT_NOME, config =>
            {
                config.BaseAddress = new System.Uri(_configuration[Constantes.TAXA_JUROS_HTTP_KEY]);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Soft.Calculo.Juros.Api");

                c.DocExpansion(DocExpansion.List);
            });
        }
    }
}
