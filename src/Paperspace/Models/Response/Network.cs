namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Network
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("region")]
        public Region Region
        {
            get;
            set;
        }

        [JsonProperty("dtCreated")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DTCreated
        {
            get;
            set;
        }

        [JsonProperty("network")]
        public string IP
        {
            get;
            set;
        }

        [JsonProperty("netmask")]
        public string Netmask
        {
            get;
            set;
        }

        [JsonProperty("teamId")]
        public string TeamId
        {
            get;
            set;
        }
    }
}
