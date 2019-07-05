namespace Paperspace
{
    using Newtonsoft.Json;

    public class Artifact
    {
        [JsonProperty("file")]
        public string File
        {
            get;
            set;
        }

        [JsonProperty("size")]
        public long Size
        {
            get;
            set;
        }
    }
}
