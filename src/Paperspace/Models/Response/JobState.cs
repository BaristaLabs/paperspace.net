namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// The current Job State
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobState
    {
        /// <summary>
        /// The job has not started setting up on a machine yet
        /// </summary>
        [EnumMember(Value = "Pending")]
        Pending,

        /// <summary>
        /// The job has been provisioned, but is not yet running
        /// </summary>
        [EnumMember(Value = "Provisioned")]
        Provisioned,

        /// <summary>
        /// The job is setting up on a machine, running, or tearing down
        /// </summary>
        [EnumMember(Value = "Running")]
        Running,

        /// <summary>
        /// The job finished with a job command exit code of 0
        /// </summary>
        [EnumMember(Value = "Stopped")]
        Stopped,

        /// <summary>
        /// The job was preempted
        /// </summary>
        [EnumMember(Value = "Preempted")]
        Preempted,

        /// <summary>
        /// The job was unable to setup or run to normal completion
        /// </summary>
        [EnumMember(Value = "Error")]
        Error,

        /// <summary>
        /// the job finished but the job command exit code was non-zero
        /// </summary>
        [EnumMember(Value = "Failed")]
        Failed,

        /// <summary>
        /// The job was manually stopped before completion
        /// </summary>
        [EnumMember(Value = "Cancelled")]
        Cancelled,
    }
}
