#region

using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.STREAM.DELETE API
/// </summary>
public record StreamDeleteResponse
{
    [JsonPropertyName("success")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public bool Success { get; set; } = default!;
}
