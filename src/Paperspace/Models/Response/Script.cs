namespace Paperspace
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Script
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("ownerType")]
        public ScriptOwnerType OwnerType
        {
            get;
            set;
        }

        [JsonProperty("ownerId")]
        public string OwnerId
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

        [JsonProperty("description")]
        public string Description
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

        [JsonProperty("isEnabled")]
        public bool IsEnabled
        {
            get;
            set;
        }

        [JsonProperty("machines")]
        public IList<ScriptMachine> Machines
        {
            get;
            set;
        }
    }
}
