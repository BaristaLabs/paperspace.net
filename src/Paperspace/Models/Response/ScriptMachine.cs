namespace Paperspace
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class ScriptMachine
    {
        [JsonProperty("machineId")]
        public string MachineId
        {
            get;
            set;
        }

        [JsonProperty("dtLastRun")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTLastRun
        {
            get;
            set;
        }
    }
}
