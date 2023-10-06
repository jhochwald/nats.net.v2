#region

using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.CONSUMER.LEADER.STEPDOWN API
/// </summary>
public record ConsumerLeaderStepdownResponse
{
    /// <summary>
    ///     If the leader successfully stood down
    /// </summary>
    [JsonPropertyName("success")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public bool Success { get; set; } = false;
}
