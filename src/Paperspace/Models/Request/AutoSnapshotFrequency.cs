namespace Paperspace
{
    using System.Runtime.Serialization;

    public enum AutoSnapshotFrequency
    {
        [EnumMember(Value = "hour")]
        Hour,

        [EnumMember(Value = "day")]
        Day,

        [EnumMember(Value = "week")]
        Week
    }
}
