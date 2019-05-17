namespace Paperspace
{ 
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BillingType
    {
        [EnumMember(Value = "hourly")]
        Hourly,

        [EnumMember(Value = "monthly")]
        Monthly,
    }
}
