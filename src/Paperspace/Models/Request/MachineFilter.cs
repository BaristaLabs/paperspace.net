namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    /// <summary>
    /// An optional filter object to limit the returned machine objects
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MachineFilter
    {
        /// <summary>
        /// Optional machine id to match on.
        /// </summary>
        [JsonProperty("machineId")]
        public string MachineId
        {
            get;
            set;
        }

        /// <summary>
        /// Optional name to match on
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Optional os to match on
        /// </summary>
        [JsonProperty("os")]
        public string OS
        {
            get;
            set;
        }

        /// <summary>
        /// Optional ram value to match on
        /// </summary>
        [JsonProperty("ram")]
        public string Ram
        {
            get;
            set;
        }

        /// <summary>
        /// Optional cpu count to match on
        /// </summary>
        [JsonProperty("cpus")]
        public int? Cpus
        {
            get;
            set;
        }

        /// <summary>
        /// Optional gpu to match on
        /// </summary>
        [JsonProperty("gpu")]
        public string Gpu
        {
            get;
            set;
        }

        /// <summary>
        /// Optional storageTotal value to match on
        /// </summary>
        [JsonProperty("storageTotal")]
        public string StorageTotal
        {
            get;
            set;
        }

        /// <summary>
        /// Optional storageUsed value to match on
        /// </summary>
        [JsonProperty("storageUsed")]
        public string StorageUsed
        {
            get;
            set;
        }

        /// <summary>
        /// Optional usageRate value to match on
        /// </summary>
        [JsonProperty("usageRate")]
        public string UsageRate
        {
            get;
            set;
        }

        /// <summary>
        /// Optional shutdownTimeoutInHours value to match on
        /// </summary>
        [JsonProperty("shutdownTimeoutInHours")]
        public int? ShutdownTimeoutInHours
        {
            get;
            set;
        }

        /// <summary>
        /// Optional performAutoSnapshot value to match on, either true or false
        /// </summary>
        [JsonProperty("performAutoSnapshot")]
        public bool? PerformAutoSnapshot
        {
            get;
            set;
        }

        /// <summary>
        /// Optional autoSnapshotFrequency value to match on
        /// </summary>
        [JsonProperty("autoSnapshotFrequency")]
        public string AutoSnapshotFrequency
        {
            get;
            set;
        }

        /// <summary>
        /// Optional autoSnapshotSaveCount value to match on
        /// </summary>
        [JsonProperty("autoSnapshotSaveCount")]
        public int? AutoSnapshotSaveCount
        {
            get;
            set;
        }

        /// <summary>
        /// Optional agentType value to match on
        /// </summary>
        [JsonProperty("agentType")]
        public string AgentType
        {
            get;
            set;
        }

        /// <summary>
        /// Optional datetime created value to match on
        /// </summary>
        [JsonProperty("dtCreated")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTCreated
        {
            get;
            set;
        }

        /// <summary>
        /// Optional state value to match on
        /// </summary>
        [JsonProperty("state")]
        public MachineState? State
        {
            get;
            set;
        }

        /// <summary>
        /// Optional updatesPending value to match on
        /// </summary>
        [JsonProperty("updatesPending")]
        public bool? UpdatesPending
        {
            get;
            set;
        }

        /// <summary>
        /// Optional networkId to match on
        /// </summary>
        [JsonProperty("networkId")]
        public string NetworkId
        {
            get;
            set;
        }

        /// <summary>
        /// Optional privateIpAddress to match on
        /// </summary>
        [JsonProperty("privateIpAddress")]
        public string PrivateIpAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Optional publicIpAddress to match on
        /// </summary>
        [JsonProperty("publicIpAddress")]
        public string PublicIpAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Optional region to match on
        /// </summary>
        [JsonProperty("region")]
        public Region? Region
        {
            get;
            set;
        }

        /// <summary>
        /// Optional userId to match on
        /// </summary>
        [JsonProperty("userId")]
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Optional teamId to match on
        /// </summary>
        [JsonProperty("teamId")]
        public string TeamId
        {
            get;
            set;
        }

        /// <summary>
        /// Optional scriptId to match on
        /// </summary>
        [JsonProperty("scriptId")]
        public string ScriptId
        {
            get;
            set;
        }

        /// <summary>
        /// Optional script datetime last run value to match on
        /// </summary>
        [JsonProperty("dtLastRun")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTLastRun
        {
            get;
            set;
        }
    }
}
