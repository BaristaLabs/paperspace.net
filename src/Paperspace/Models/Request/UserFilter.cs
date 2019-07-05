namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UserFilter
    {
        /// <summary>
        /// Optional user id to match on
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Optional email to match on
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Optional firstname to match on
        /// </summary>
        [JsonProperty("firstname")]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Optional lastname to match on
        /// </summary>
        [JsonProperty("lastname")]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Optional datetime created value to match on
        /// </summary>
        [JsonProperty("dtCreated")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTCreated
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
