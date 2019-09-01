using Newtonsoft.Json;

namespace SV.CQRS.Domain.Base
{
    public abstract class DocumentBase : EntityBase
    {
        /// <summary>
        /// Gets or sets Attachments.
        /// </summary>
        [JsonProperty(PropertyName = "_attachments")]
        public string Attachments { get; protected internal set; }

        /// <summary>
        /// Gets or sets Etag.
        /// </summary>
        [JsonProperty(PropertyName = "_etag")]
        public string Etag { get; protected internal set; }

        /// <summary>
        /// Gets or sets Resource Id.
        /// </summary>
        [JsonProperty(PropertyName = "_rid")]
        public string ResourceId { get; protected internal set; }

        /// <summary>
        /// Gets or sets Self.
        /// </summary>
        [JsonProperty(PropertyName = "_self")]
        public string Self { get; protected internal set; }

        /// <summary>
        /// Gets or sets Time Stamp.
        /// </summary>
        [JsonProperty(PropertyName = "_ts")]
        public int TimeStamp { get; protected internal set; }
    }
}
