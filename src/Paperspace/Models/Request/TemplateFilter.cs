namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    public class TemplateFilter
    {
        /// <summary>
        /// Template Id to match on
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Name to match on
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Label to match on
        /// </summary>
        [JsonProperty("label")]
        public string Label
        {
            get;
            set;
        }

        /// <summary>
        /// OS to match on
        /// </summary>
        [JsonProperty("os")]
        public string OS
        {
            get;
            set;
        }

        /// <summary>
        /// DateTime created value to match on
        /// </summary>
        [JsonProperty("dtCreated")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DTCreated
        {
            get;
            set;
        }

        /// <summary>
        /// Team to match on
        /// </summary>
        [JsonProperty("teamId")]
        public string TeamId
        {
            get;
            set;
        }

        /// <summary>
        /// UserId to match on
        /// </summary>
        [JsonProperty("userId")]
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Region to match on
        /// </summary>
        [JsonProperty("region")]
        public string Region
        {
            get;
            set;
        }
    }
}
