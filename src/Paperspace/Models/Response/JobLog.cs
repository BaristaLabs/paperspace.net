namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    public class JobLog
    {
        [JsonProperty("jobId")]
        public string JobId
        {
            get;
            set;
        }

        [JsonProperty("line")]
        public long Line
        {
            get;
            set;
        }

        [JsonProperty("timestamp")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Timestamp
        {
            get;
            set;
        }

        [JsonProperty("message")]
        public string Message
        {
            get;
            set;
        }
    }
}
