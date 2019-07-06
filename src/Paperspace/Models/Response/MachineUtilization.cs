namespace Paperspace
{
    using Newtonsoft.Json;

    public class MachineUtilization
    {
        [JsonProperty("machineId")]
        public string MachineId
        {
            get;
            set;
        }

        [JsonProperty("utilization")]
        public UtilizationMetrics Utilization
        {
            get;
            set;
        }

        [JsonProperty("storageUtilization")]
        public UtilizationMetrics StorageUtilization
        {
            get;
            set;
        }
    }

    public class UtilizationMetrics
    {
        [JsonProperty("machineId")]
        public string MachineId
        {
            get;
            set;
        }

        [JsonProperty("secondsUsed")]
        public decimal SecondsUsed
        {
            get;
            set;
        }

        [JsonProperty("monthlyRate")]
        public decimal MonthlyRate
        {
            get;
            set;
        }

        [JsonProperty("billingMonth")]
        public string BillingMonth
        {
            get;
            set;
        }
    }
}
