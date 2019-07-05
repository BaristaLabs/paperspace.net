namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ScriptOwnerType
    {
        [EnumMember(Value = "owner")]
        Owner,

        [EnumMember(Value = "team")]
        Team
    }
}
