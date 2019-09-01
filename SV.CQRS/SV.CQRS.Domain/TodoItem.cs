using Newtonsoft.Json;
using SV.CQRS.Domain.Base;

namespace SV.CQRS.Domain
{
    public class TodoItem : DocumentBase
    {
        /// <summary>
        /// Gets Max Name Length.
        /// </summary>
        public static int MaxDescriptionLength => 255;

        /// <summary>
        /// Gets Max Name Length.
        /// </summary>
        public static int MaxNameLength => 50;

        /// <summary>
        /// Gets or Sets Description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets a value indicating whether todo item is complete.
        /// </summary>
        [JsonProperty(PropertyName = "isCompleted")]
        public bool IsCompleted { get; private set; }

        /// <summary>
        /// Gets a value indicating whether todo item is deleted.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted")]
        public bool IsDeleted { get; private set; }

        /// <summary>
        /// Gets Name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Set item to complete.
        /// </summary>
        public void SetComplete()
        {
            this.IsCompleted = true;
        }

        /// <summary>
        /// Set item to delete.
        /// </summary>
        public void SetDelete()
        {
            this.IsDeleted = true;
        }
    }
}