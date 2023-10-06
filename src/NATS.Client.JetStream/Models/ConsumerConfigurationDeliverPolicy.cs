#region

using System.Runtime.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

// TODO: enum member naming with JSON serialization isn't working for some reason
#pragma warning disable SA1300
public enum ConsumerConfigurationDeliverPolicy
{
    [EnumMember(Value = @"all")]
    all = 0,

    [EnumMember(Value = @"last")]
    last = 1,

    [EnumMember(Value = @"new")]
    @new = 2,

    [EnumMember(Value = @"by_start_sequence")]
    by_start_sequence = 3,

    [EnumMember(Value = @"by_start_time")]
    by_start_time = 4,

    [EnumMember(Value = @"last_per_subject")]
    last_per_subject = 5
}
