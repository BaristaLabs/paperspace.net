namespace Paperspace
{
    using Newtonsoft.Json;

    public class JobMachine
    {
        [JsonProperty("region")]
        public Region Region
        {
            get;
            set;
        }

        [JsonProperty("cluster")]
        public string Cluster
        {
            get;
            set;
        }

        [JsonProperty("machineType")]
        public MachineType MachineType
        {
            get;
            set;
        }

        [JsonProperty("isBusy")]
        public bool IsBusy
        {
            get;
            set;
        }
    }
}
