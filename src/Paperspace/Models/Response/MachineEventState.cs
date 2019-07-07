namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// The current Machine Event State.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MachineEventState
    {
        /// <summary>
        /// The Machine Event is new.
        /// </summary>
        [EnumMember(Value = "new")]
        New,

        /// <summary>
        /// The Machine Event is in progress.
        /// </summary>
        [EnumMember(Value = "in progress")]
        InProgress,

        /// <summary>
        /// The Machine Event is done.
        /// </summary>
        [EnumMember(Value = "done")]
        Done,

        /// <summary>
        /// The Machine Event was unable to run to normal completion
        /// </summary>
        [EnumMember(Value = "error")]
        Error,
    }
}
