#region

using System.Runtime.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

// TODO: enum member naming with JSON serialization isn't working for some reason
#pragma warning disable SA1300
public enum StreamConfigurationDiscard
{
    [EnumMember(Value = @"old")]
    old = 0,

    [EnumMember(Value = @"new")]
    @new = 1
}
