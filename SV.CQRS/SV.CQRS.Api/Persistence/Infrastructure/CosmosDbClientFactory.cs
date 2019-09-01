using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using SV.CQRS.Api.Options;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SV.CQRS.Api.Persistence.Infrastructure
{
    public class CosmosDbClientFactory
    {
        private readonly IDocumentClient client;
        private readonly ICosmosDbConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="CosmosDbClientFactory"/> class.
        /// </summary>
        /// <param name="config">Configuration type of <see cref="ICosmosDbConfiguration"/>.</param>
        /// <param name="client">DocumentClient type of <see cref="IDocumentClient"/>.</param>
        public CosmosDbClientFactory(ICosmosDbConfiguration config, IDocumentClient client = null)
        {
            this.config = config;
            this.client = client ?? new DocumentClient(new Uri(config.Endpoint), config.AuthKey);
        }

        /// <summary>
        /// Creates collection if it does not exist.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task CreateCollectionAsync()
        {
            try
            {
                await this.client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(this.config.Database, this.config.Collection)).ConfigureAwait(false);
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    var options = new RequestOptions() { OfferThroughput = 1000 };
                    await this.client
                        .CreateDocumentCollectionAsync(UriFactory.CreateDatabaseUri(this.config.Database), new DocumentCollection { Id = this.config.Collection }, options)
                        .ConfigureAwait(false);
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Creates database if it does not exist.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task CreateDatabaseAsync()
        {
            try
            {
                await this.client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(this.config.Database)).ConfigureAwait(false);
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client
                        .CreateDatabaseAsync(new Database { Id = this.config.Database })
                        .ConfigureAwait(false);
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// This verifies database and collections existence. Creates database and collections if it does not exist.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task EnsureDbSetupAsync()
        {
            await this.CreateDatabaseAsync().ConfigureAwait(false);
            await this.CreateCollectionAsync().ConfigureAwait(false);
        }
    }
}