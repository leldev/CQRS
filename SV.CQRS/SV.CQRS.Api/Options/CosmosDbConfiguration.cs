namespace SV.CQRS.Api.Options
{
    public class CosmosDbConfiguration : ICosmosDbConfiguration
    {
        /// <inheritdoc/>
        public string AuthKey { get; set; }

        /// <inheritdoc/>
        public string Collection { get; set; }

        /// <inheritdoc/>
        public string Database { get; set; }

        /// <inheritdoc/>
        public string Endpoint { get; set; }
    }
}