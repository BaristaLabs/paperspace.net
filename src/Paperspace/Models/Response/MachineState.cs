namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// The current machine state.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MachineState
    {
        /// <summary>
        /// Machine is off
        /// </summary>
        [EnumMember(Value = "off")]
        Off,

        /// <summary>
        /// Machine is in the process of changing to the ready or serviceready state
        /// </summary>
        [EnumMember(Value = "starting")]
        Starting,

        /// <summary>
        /// Machine is in the process of changing to the off state
        /// </summary>
        [EnumMember(Value = "stopping")]
        Stopping,

        /// <summary>
        /// Combines stopping follow immediately by starting
        /// </summary>
        [EnumMember(Value = "restarting")]
        Restarting,

        /// <summary>
        /// Services are running on the machine but the Paperspace agent is not yet available
        /// </summary>
        [EnumMember(Value = "serviceready")]
        ServiceReady,

        /// <summary>
        /// Services are running on machine and the Paperspace agent is ready to stream or accept logins
        /// </summary>
        [EnumMember(Value = "ready")]
        Ready,

        /// <summary>
        /// The machine specification are being upgraded, which involves a shutdown and startup sequence
        /// </summary>
        [EnumMember(Value = "upgrading")]
        Upgrading,

        /// <summary>
        /// The machine is in the process of being created for the first time
        /// </summary>
        [EnumMember(Value = "provisioning")]
        Provisioning,
    }
}
