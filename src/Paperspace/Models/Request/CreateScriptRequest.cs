namespace Paperspace
{
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateScriptRequest
    {
        /// <summary>
        /// A unique name for the script
        /// </summary>
        [JsonProperty("scriptName")]
        public string ScriptName
        {
            get;
            set;
        }

        /// <summary>
        /// File path to a file containing the script data; either scriptFile or scriptText must be provided. (Optional)
        /// </summary>
        [JsonProperty("scriptFile")]
        public string ScriptFile
        {
            get;
            set;
        }

        /// <summary>
        /// A string containing the script text; either scriptFile or scriptText must be provided. (Optional)
        /// </summary>
        [JsonProperty("scriptText")]
        public string ScriptText
        {
            get;
            set;
        }

        /// <summary>
        /// Description of the script
        /// </summary>
        [JsonProperty("scriptDescription")]
        public string ScriptDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Determines if the script is enabled or not. Defaults to true
        /// </summary>
        [JsonProperty("isEnabled")]
        public bool? IsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Determines if the script is run on first boot or every boot. Defaults to false
        /// </summary>
        [JsonProperty("runOnce")]
        public bool? RunOnce
        {
            get;
            set;
        }

        /// <summary>
        /// Machine id of a machine that should execute this script at startup
        /// </summary>
        [JsonProperty("machineId")]
        public string MachineId
        {
            get;
            set;
        }
    }
}
