namespace Paperspace
{
    using Newtonsoft.Json;

    /// <summary>
    /// An optional filter object to limit the returned job objects
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class JobFilter
    {
        /// <summary>
        /// Optional project to match on. If neither project nor projectId are provided, this is taken from the .ps_project/config.json file, or the current directory name. Specify 'all' to list jobs for all projects associated with the user or team if the user is on a team.
        /// </summary>
        [JsonProperty("project")]
        public string Project
        {
            get;
            set;
        }

        /// <summary>
        /// Optional projectId to match on
        /// </summary>
        [JsonProperty("projectId")]
        public string ProjectId
        {
            get;
            set;
        }

        /// <summary>
        /// Optional job name to match on
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Optional machineType to match on
        /// </summary>
        [JsonProperty("machineType")]
        public MachineType MachineType
        {
            get;
            set;
        }

        /// <summary>
        /// Optional state value to match on
        /// </summary>
        [JsonProperty("state")]
        public MachineState State
        {
            get;
            set;
        }

        /// <summary>
        /// Optional container to match on
        /// </summary>
        [JsonProperty("container")]
        public string Container
        {
            get;
            set;
        }

        /// <summary>
        /// Optional command to match on
        /// </summary>
        [JsonProperty("command")]
        public string Command
        {
            get;
            set;
        }

        /// <summary>
        /// Optional workspace path to match on. Note: the original workspace path will be modified on upload to point to a temporary location.
        /// </summary>
        [JsonProperty("workspace")]
        public string Workspace
        {
            get;
            set;
        }

        /// <summary>
        /// Optional dataset to match on
        /// </summary>
        [JsonProperty("dataset")]
        public string Dataset
        {
            get;
            set;
        }
    }
}
