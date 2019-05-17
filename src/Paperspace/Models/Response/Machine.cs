namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a Machine object returned by Paperspace's Machines API
    /// </summary>
    public class Machine
    {
        [JsonProperty("id")]
        public string Id
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

        [JsonProperty("os")]
        public string OS
        {
            get;
            set;
        }

        [JsonProperty("ram")]
        public string Ram
        {
            get;
            set;
        }

        [JsonProperty("cpus")]
        public int Cpus
        {
            get;
            set;
        }

        [JsonProperty("gpu")]
        public string Gpu
        {
            get;
            set;
        }

        [JsonProperty("storageTotal")]
        public string StorageTotal
        {
            get;
            set;
        }

        [JsonProperty("storageUsed")]
        public string StorageUsed
        {
            get;
            set;
        }

        [JsonProperty("usageRate")]
        public string UsageRate
        {
            get;
            set;
        }

        [JsonProperty("shutdownTimeoutInHours")]
        public int ShutdownTimeoutInHours
        {
            get;
            set;
        }

        [JsonProperty("shutdownTimeoutForces")]
        public bool ShutdownTimeoutForces
        {
            get;
            set;
        }

        [JsonProperty("performAutoSnapshot")]
        public bool PerformAutoSnapshot
        {
            get;
            set;
        }

        [JsonProperty("autoSnapshotFrequency")]
        public string AutoSnapshotFrequency
        {
            get;
            set;
        }

        [JsonProperty("autoSnapshotSaveCount")]
        public string AutoSnapshotSaveCount
        {
            get;
            set;
        }

        [JsonProperty("agentType")]
        public string AgentType
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

        [JsonProperty("state")]
        public MachineState State
        {
            get;
            set;
        }

        /// <summary>
        /// Reflects whether the operating system has scheduled updates for the next machine state transition, e.g, stopping, starting, restarting or upgrading.
        /// </summary>
        [JsonProperty("updatesPending")]
        public bool UpdatesPending
        {
            get;
            set;
        }

        [JsonProperty("networkId")]
        public string NetworkId
        {
            get;
            set;
        }

        [JsonProperty("privateIpAddress")]
        public string PrivateIpAddress
        {
            get;
            set;
        }

        [JsonProperty("publicIpAddress")]
        public string PublicIpAddress
        {
            get;
            set;
        }

        [JsonProperty("region")]
        public string Region
        {
            get;
            set;
        }

        [JsonProperty("userId")]
        public string UserId
        {
            get;
            set;
        }

        [JsonProperty("teamId")]
        public string TeamId
        {
            get;
            set;
        }

        [JsonProperty("scriptId")]
        public string ScriptId
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

        [JsonProperty("dynamicPublicIp")]
        public string DynamicPublicIp
        {
            get;
            set;
        }

        [JsonProperty("events")]
        public IList<MachineEvent> Events
        {
            get;
            set;
        }
    }
}
