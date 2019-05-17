namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    /// <summary>
    /// Represents a Machine Event returned as part of Machine Information returned by the show endpoint.
    /// </summary>
    public class MachineEvent
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("state")]
        public string State
        {
            get;
            set;
        }

        [JsonProperty("errorMsg")]
        public string ErrorMessage
        {
            get;
            set;
        }

        [JsonProperty("handle")]
        public string Handle
        {
            get;
            set;
        }

        [JsonProperty("dtModified")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTModified
        {
            get;
            set;
        }

        [JsonProperty("dtFinished")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTFinished
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
