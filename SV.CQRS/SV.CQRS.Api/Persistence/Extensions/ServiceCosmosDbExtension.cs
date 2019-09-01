using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.DependencyInjection;
using SV.CQRS.Api.Options;
using SV.CQRS.Api.Persistence.Infrastructure;
using System;

namespace SV.CQRS.Api.Persistence.Extensions
{
    public static class ServiceCosmosDbExtension
    {
        /// <summary>
        /// Add Cosmos Db Repositories and Services.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <param name="config">Configuration type of <see cref="ICosmosDbConfiguration"/>.</param>
        /// <returns>Service Collection <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddCosmosDb(this IServiceCollection services, ICosmosDbConfiguration config)
        {
            services.AddSingleton(config);
            services.AddScoped<IDocumentClient>(s => new DocumentClient(new Uri(config.Endpoint), config.AuthKey));

            services.AddScoped<IRepository, CosmosDbRepository>();
            
            new CosmosDbClientFactory(config).EnsureDbSetupAsync().Wait();

            return services;
        }
    }
}
