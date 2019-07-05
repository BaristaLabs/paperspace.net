namespace Paperspace
{
    using Newtonsoft.Json;

    public class Job
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
    }
}
