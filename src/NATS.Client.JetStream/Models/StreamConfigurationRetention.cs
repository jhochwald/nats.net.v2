#region

using System.Runtime.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

// TODO: enum member naming with JSON serialization isn't working for some reason
#pragma warning disable SA1300
public enum StreamConfigurationRetention
{
    [EnumMember(Value = @"limits")]
    limits = 0,

    [EnumMember(Value = @"interest")]
    interest = 1,

    [EnumMember(Value = @"workqueue")]
    workqueue = 2
}
