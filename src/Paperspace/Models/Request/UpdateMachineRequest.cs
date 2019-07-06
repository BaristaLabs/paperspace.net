namespace Paperspace
{
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateMachineRequest
    {
        /// <summary>
        /// New name for the machine
        /// </summary>
        [JsonProperty("machineName")]
        public string MachineName
        {
            get;
            set;
        }

        /// <summary>
        /// Number of hours before machine is shutdown if no one is logged in via the Paperspace client
        /// </summary>
        [JsonProperty("shutdownTimeoutInHours")]
        public string ShutdownTimeoutInHours
        {
            get;
            set;
        }

        /// <summary>
        /// Force shutdown at shutdown timeout, even if there is a Paperspace client connection
        /// </summary>
        [JsonProperty("shutdownTimeoutForces")]
        public string ShutdownTimeoutForces
        {
            get;
            set;
        }

        /// <summary>
        /// One of 'hour', 'day', 'week', or null
        /// </summary>
        [JsonProperty("autoSnapshotFrequency")]
        public AutoSnapshotFrequency? AutoSnapshotFrequency
        {
            get;
            set;
        }

        /// <summary>
        /// Number of snapshots to save
        /// </summary>
        [JsonProperty("autoSnapshotSaveCount")]
        public int? AutoSnapshotSaveCount
        {
            get;
            set;
        }

        /// <summary>
        /// Perform auto snapshots
        /// </summary>
        [JsonProperty("performAutoSnapshot")]
        public bool? PerformAutoSnapshot
        {
            get;
            set;
        }

        [JsonProperty("dynamicPublicIp")]
        public bool? DynamicPublicIp
        {
            get;
            set;
        }
    }
}
