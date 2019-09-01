using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.CQRS.Domain.Base
{
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; protected internal set; }
    }
}
