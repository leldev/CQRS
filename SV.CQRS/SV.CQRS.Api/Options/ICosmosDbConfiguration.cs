namespace SV.CQRS.Api.Options
{
    public interface ICosmosDbConfiguration
    {
        /// <summary>
        /// Gets or sets AuthKey.
        /// </summary>
        string AuthKey { get; set; }

        /// <summary>
        /// Gets or sets Collection.
        /// </summary>
        string Collection { get; set; }

        /// <summary>
        /// Gets or sets Database.
        /// </summary>
        string Database { get; set; }

        /// <summary>
        /// Gets or sets Endpoint.
        /// </summary>
        string Endpoint { get; set; }
    }
}