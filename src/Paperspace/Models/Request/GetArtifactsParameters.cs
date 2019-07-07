namespace Paperspace
{
    using Newtonsoft.Json;

    /// <summary>
    /// Artifacts get parameters
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GetArtifactsParameters
    {
        /// <summary>
        /// Optional; if getting only certain files, a wildcard pattern to match against, e.g., "myfiles*".
        /// </summary>
        [JsonProperty("files")]
        public string Files
        {
            get;
            set;
        }
    }
}
