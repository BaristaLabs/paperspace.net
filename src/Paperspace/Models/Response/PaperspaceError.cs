namespace Paperspace
{
    using Newtonsoft.Json;

    public class PaperspaceErrorWrapper
    {
        [JsonProperty("error")]
        public PaperspaceError Error
        {
            get;
            set;
        }
    }

    public class PaperspaceError
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("status")]
        public int Status
        {
            get;
            set;
        }

        [JsonProperty("message")]
        public string Message
        {
            get;
            set;
        }
    }
}
