namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;


    [JsonConverter(typeof(StringEnumConverter))]
    public enum MachineState
    {
        /// <summary>
        /// Machine is off
        /// </summary>
        [JsonProperty("off")]
        Off,

        /// <summary>
        /// Machine is in the process of changing to the ready or serviceready state
        /// </summary>
        [JsonProperty("starting")]
        Starting,

        /// <summary>
        /// Machine is in the process of changing to the off state
        /// </summary>
        [JsonProperty("stopping")]
        Stopping,

        /// <summary>
        /// Combines stopping follow immediately by starting
        /// </summary>
        [JsonProperty("restarting")]
        Restarting,

        /// <summary>
        /// Services are running on the machine but the Paperspace agent is not yet available
        /// </summary>
        [JsonProperty("serviceready")]
        ServiceReady,

        /// <summary>
        /// Services are running on machine and the Paperspace agent is ready to stream or accept logins
        /// </summary>
        [JsonProperty("ready")]
        Ready,

        /// <summary>
        /// The machine specification are being upgraded, which involves a shutdown and startup sequence
        /// </summary>
        [JsonProperty("upgrading")]
        Upgrading,

        /// <summary>
        /// The machine is in the process of being created for the first time
        /// </summary>
        [JsonProperty("provisioning")]
        Provisioning,
    }
}
