#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.STREAM.SNAPSHOT API
/// </summary>
public record StreamSnapshotResponse
{
    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public StreamConfiguration Config { get; set; } = new();

    [JsonPropertyName("state")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public StreamState State { get; set; } = new();
}
