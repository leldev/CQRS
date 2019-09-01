using Newtonsoft.Json;

namespace SV.CQRS.Api.Features.TodoItems
{
    public class TodoItemModel
    {
        /// <summary>
        /// Gets or Sets Description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether todo item is complete.
        /// </summary>
        [JsonProperty(PropertyName = "isCompleted")]
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether todo item is deleted.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}