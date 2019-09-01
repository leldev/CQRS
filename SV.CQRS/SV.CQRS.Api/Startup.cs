using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SV.CQRS.Api.Options;
using SV.CQRS.Api.Persistence.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace SV.CQRS.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.CosmosDbConfiguration = new CosmosDbConfiguration();
            configuration
                .GetSection(nameof(this.CosmosDbConfiguration))
                .Bind(this.CosmosDbConfiguration);
        }

        public ICosmosDbConfiguration CosmosDbConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddFluentValidation(c => { c.RegisterValidatorsFromAssemblyContaining<Startup>(); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMediatR(typeof(Startup).Assembly);
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Todo API V1", Version = "v1" });
                c.CustomSchemaIds((type) => type.FullName);
                c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();
            });

            services.AddCosmosDb(this.CosmosDbConfiguration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
            });
        }
    }
}
