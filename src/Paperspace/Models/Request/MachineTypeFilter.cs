namespace Paperspace
{
    using Newtonsoft.Json;

    /// <summary>
    /// An optional filter object to limit the returned machine type objects
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MachineTypeFilter
    {
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
        /// Optional cluster to match on
        /// </summary>
        [JsonProperty("cluster")]
        public string Cluster
        {
            get;
            set;
        }

        /// <summary>
        /// Optional machine type to match on
        /// </summary>
        [JsonProperty("machineType")]
        public MachineType? MachineType
        {
            get;
            set;
        }

        /// <summary>
        /// Optional busy status value to match on
        /// </summary>
        [JsonProperty("isBusy")]
        public bool? IsBusy
        {
            get;
            set;
        }
    }
}
