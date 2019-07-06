namespace Paperspace
{
    using Newtonsoft.Json;

    public class MachineAvailability
    {
        [JsonProperty("available")]
        public bool Available
        {
            get;
            set;
        }
    }
}
