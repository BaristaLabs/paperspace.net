namespace Paperspace
{
    using Newtonsoft.Json;

    /// <summary>
    /// Artifacts list parameters
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ListArtifactsParameters
    {
        /// <summary>
        /// Optional; wildcard expression of file(s) to list, e.g., "myfiles*".
        /// </summary>
        [JsonProperty("files")]
        public string Files
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; include file size in bytes.
        /// </summary>
        [JsonProperty("size")]
        public bool Size
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; include https links to artifacts.
        /// </summary>
        [JsonProperty("links")]
        public bool Links
        {
            get;
            set;
        }
    }
}
