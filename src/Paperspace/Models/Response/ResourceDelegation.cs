namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;

    public class ResourceDelegation
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("delegation")]
        public Delegation Delegation
        {
            get;
            set;
        }

        [JsonProperty("isEnabled")]
        public bool IsEnabled
        {
            get;
            set;
        }

        [JsonProperty("accessTokenId")]
        public string AccessTokenId
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

    public class Delegation
    {
        [JsonProperty("machine")]
        public MachineDelegation Machine
        {
            get;
            set;
        }
    }

    public class MachineDelegation
    {
        [JsonProperty("ids")]
        public IList<string> Ids
        {
            get;
            set;
        }
    }
}
