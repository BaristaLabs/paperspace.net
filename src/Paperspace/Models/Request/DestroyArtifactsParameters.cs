namespace Paperspace
{
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DestroyArtifactsParameters
    {
        /// <summary>
        /// Optional; if destroying only certain files, a wildcard pattern to match against, e.g., "myfiles*".
        /// </summary>
        [JsonProperty("files")]
        public string Files
        {
            get;
            set;
        }
    }
}
