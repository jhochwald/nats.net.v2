#region

using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.STREAM.PEER.REMOVE API
/// </summary>
public record StreamRemovePeerResponse
{
    /// <summary>
    ///     If the peer was successfully removed
    /// </summary>
    [JsonPropertyName("success")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public bool Success { get; set; } = false;
}
