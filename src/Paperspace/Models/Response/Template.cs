namespace Paperspace
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents a Template object returned by Paperspace's Templates API
    /// </summary>
    public class Template
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

        [JsonProperty("label")]
        public string Label
        {
            get;
            set;
        }

        [JsonProperty("os")]
        public string OS
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

        [JsonProperty("userId")]
        public string UserId
        {
            get;
            set;
        }

        [JsonProperty("region")]
        public string Region
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
    }
}
