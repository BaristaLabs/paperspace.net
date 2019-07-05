namespace Paperspace
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class User
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        [JsonProperty("firstname")]
        public string FirstName
        {
            get;
            set;
        }

        [JsonProperty("lastname")]
        public string LastName
        {
            get;
            set;
        }

        [JsonProperty("isAdmin")]
        public bool IsAdmin
        {
            get;
            set;
        }

        [JsonProperty("isOwner")]
        public bool IsOwner
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

        [JsonProperty("teamId")]
        public string TeamId
        {
            get;
            set;
        }
    }
}
