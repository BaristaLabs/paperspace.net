namespace Paperspace
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ScriptFilter
    {
        /// <summary>
        /// Optional script id to match on
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Optional ownerType to match on, either 'user' or 'team'
        /// </summary>
        [JsonProperty("ownerType")]
        public ScriptOwnerType? OwnerType
        {
            get;
            set;
        }

        /// <summary>
        /// Optional ownerId to match on, either a userId or teamId
        /// </summary>
        [JsonProperty("ownerId")]
        public string OwnerId
        {
            get;
            set;
        }

        /// <summary>
        /// Optional name to match on
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Optional description to match on
        /// </summary>
        [JsonProperty("description")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Optional datetime created value to match on
        /// </summary>
        [JsonProperty("dtCreated")]
        public DateTime? DTCreated
        {
            get;
            set;
        }

        /// <summary>
        /// Optional isEnabled value to match on, either true or false
        /// </summary>
        [JsonProperty("isEnabled")]
        public bool? IsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Optional runOnce value to match on, either true or false
        /// </summary>
        [JsonProperty("runOnce")]
        public bool? RunOnce
        {
            get;
            set;
        }
    }
}
