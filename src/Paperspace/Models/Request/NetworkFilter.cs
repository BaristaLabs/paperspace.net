namespace Paperspace
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class NetworkFilter
    {
        /// <summary>
        /// Optional network id to match on
        /// </summary>
        [JsonProperty("id")]
        public string Id
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
        /// Optional region to match on
        /// </summary>
        [JsonProperty("region")]
        public Region? Region
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
        /// Optional network to match on
        /// </summary>
        [JsonProperty("network")]
        public string IP
        {
            get;
            set;
        }

        /// <summary>
        /// Optional netmask to match on
        /// </summary>
        [JsonProperty("netmask")]
        public string Netmask
        {
            get;
            set;
        }

        /// <summary>
        /// Optional teamId to match on
        /// </summary>
        [JsonProperty("teamId")]
        public string TeamId
        {
            get;
            set;
        }
    }
}
