using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using SV.CQRS.Api.Options;
using SV.CQRS.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SV.CQRS.Api.Persistence
{
    public class CosmosDbRepository : IRepository
    {
        private readonly IDocumentClient client;
        private readonly ICosmosDbConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="config">Database configuration.</param>
        /// <param name="client">Document Client.</param>
        public CosmosDbRepository(ICosmosDbConfiguration config, IDocumentClient client = null)
        {
            this.config = config;
            this.client = client ?? new DocumentClient(new Uri(config.Endpoint), config.AuthKey);
        }

        /// <inheritdoc/>
        public async Task<T> CreateItemAsync<T>(T item)
            where T : DocumentBase
        {
            Document doc = await this.client
                .CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(this.config.Database, this.config.Collection), item)
                .ConfigureAwait(false);

            return await this.GetItemAsync<T>(doc.Id).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task DeleteItemAsync<T>(string id)
            where T : DocumentBase
        {
            await this.client
                .DeleteDocumentAsync(UriFactory.CreateDocumentUri(this.config.Database, this.config.Collection, id))
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<dynamic>> GetDynamicItemsAsync<T>(Expression<Func<T, bool>> expression)
            where T : DocumentBase
        {
            var results = new List<dynamic>();
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var query = this.client
                .CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(this.config.Database, this.config.Collection), options)
                .Where(expression)
                .AsDocumentQuery();

            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync().ConfigureAwait(false));
            }

            return results;
        }

        /// <inheritdoc/>
        public async Task<T> GetItemAsync<T>(string id)
            where T : DocumentBase
        {
            var document = await this.client
                .ReadDocumentAsync<T>(UriFactory.CreateDocumentUri(this.config.Database, this.config.Collection, id))
                .ConfigureAwait(false);

            return (T)(dynamic)document;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetItemsAsync<T>()
            where T : DocumentBase
        {
            var result = new List<T>();
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var query = this.client
                .CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(this.config.Database, this.config.Collection), options)
                .AsDocumentQuery();

            while (query.HasMoreResults)
            {
                result.AddRange(await query.ExecuteNextAsync<T>().ConfigureAwait(false));
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetItemsAsync<T>(Expression<Func<T, bool>> expression)
            where T : DocumentBase
        {
            var result = new List<T>();
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var query = this.client
                .CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(this.config.Database, this.config.Collection), options)
                .Where(expression)
                .AsDocumentQuery();

            while (query.HasMoreResults)
            {
                result.AddRange(await query.ExecuteNextAsync<T>().ConfigureAwait(false));
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<T> UpdateItemAsync<T>(T item)
            where T : DocumentBase
        {
            Document document = await this.client
                .ReplaceDocumentAsync(UriFactory.CreateDocumentUri(this.config.Database, this.config.Collection, item.Id), item)
                .ConfigureAwait(false);

            return await this.GetItemAsync<T>(document.Id).ConfigureAwait(false);
        }
    }
}