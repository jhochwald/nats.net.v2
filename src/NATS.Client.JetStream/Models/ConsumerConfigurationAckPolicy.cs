#region

using System.Runtime.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

// TODO: enum member naming with JSON serialization isn't working for some reason
#pragma warning disable SA1300
public enum ConsumerConfigurationAckPolicy
{
    [EnumMember(Value = @"none")] none = 0,

    [EnumMember(Value = @"all")] all = 1,

    [EnumMember(Value = @"explicit")] @explicit = 2
}
