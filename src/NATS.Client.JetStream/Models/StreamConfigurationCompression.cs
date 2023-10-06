#region

using System.Runtime.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

// TODO: enum member naming with JSON serialization isn't working for some reason
#pragma warning disable SA1300
public enum StreamConfigurationCompression
{
    [EnumMember(Value = @"none")] none = 0,

    [EnumMember(Value = @"s2")] s2 = 1
}
