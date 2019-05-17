namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Region
    {
        [EnumMember(Value = "East Coast (NY2)")]
        EastCoast_NY2,

        [EnumMember(Value = "West Coast (CA1)")]
        WestCoast_CA1,

        [EnumMember(Value = "Europe (AMS1)")]
        Europe_AMS1,
    }
}
