namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    public class Job
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

        [JsonProperty("state")]
        public JobState State
        {
            get;
            set;
        }

        [JsonProperty("workspaceUrl")]
        public string WorkspaceUrl
        {
            get;
            set;
        }

        [JsonProperty("workingDirectory")]
        public string WorkingDirectory
        {
            get;
            set;
        }

        [JsonProperty("artifactsDirectory")]
        public string ArtifactsDirectory
        {
            get;
            set;
        }

        [JsonProperty("entrypoint")]
        public string Entrypoint
        {
            get;
            set;
        }

        [JsonProperty("projectId")]
        public string ProjectId
        {
            get;
            set;
        }

        [JsonProperty("project")]
        public string Project
        {
            get;
            set;
        }

        [JsonProperty("container")]
        public string Container
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

        [JsonProperty("cluster")]
        public string Cluster
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

        [JsonProperty("startedByUserId")]
        public string StartedByUserId
        {
            get;
            set;
        }

        [JsonProperty("parentJobId")]
        public string ParentJobId
        {
            get;
            set;
        }

        [JsonProperty("jobError")]
        public string JobError
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

        [JsonProperty("dtModified")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTModified
        {
            get;
            set;
        }

        [JsonProperty("dtProvisioningStarted")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTProvisioningStarted
        {
            get;
            set;
        }

        [JsonProperty("dtProvisioningFinished")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTProvisioningFinished
        {
            get;
            set;
        }

        [JsonProperty("dtStarted")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTStarted
        {
            get;
            set;
        }

        [JsonProperty("dtFinished")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTFinished
        {
            get;
            set;
        }

        [JsonProperty("dtTeardownStarted")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTTeardownStarted
        {
            get;
            set;
        }

        [JsonProperty("dtTeardownFinished")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTTeardownFinished
        {
            get;
            set;
        }

        [JsonProperty("dtDeleted")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DTDeleted
        {
            get;
            set;
        }

        [JsonProperty("exitCode")]
        public int? ExitCode
        {
            get;
            set;
        }
    }
}
