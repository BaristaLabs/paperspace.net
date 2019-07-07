namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MachineType
    {
        [EnumMember(Value = "Air")]
        Air,
        [EnumMember(Value = "Standard")]
        Standard,
        [EnumMember(Value = "Pro")]
        Pro,
        [EnumMember(Value = "Advanced")]
        Advanced,
        [EnumMember(Value = "GPU+")]
        GPUPlus,
        [EnumMember(Value = "P4000")]
        P4000,
        [EnumMember(Value = "P5000")]
        P5000,
        [EnumMember(Value = "P6000")]
        P6000,
        [EnumMember(Value = "V100")]
        V100,
        [EnumMember(Value = "C1")]
        C1,
        [EnumMember(Value = "C2")]
        C2,
        [EnumMember(Value = "C3")]
        C3,
        [EnumMember(Value = "C4")]
        C4,
        [EnumMember(Value = "C5")]
        C5,
        [EnumMember(Value = "C6")]
        C6,
        [EnumMember(Value = "C7")]
        C7,
        [EnumMember(Value = "C8")]
        C8,
        [EnumMember(Value = "C9")]
        C9,
        [EnumMember(Value = "C10")]
        C10,
        [EnumMember(Value = "K80")]
        K80,
        [EnumMember(Value = "P100")]
        P100,
        [EnumMember(Value = "TPU")]
        TPU,
        [EnumMember(Value = "GradientNode")]
        GradientNode,
    }
}
