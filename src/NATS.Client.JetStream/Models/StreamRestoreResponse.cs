#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.STREAM.RESTORE API
/// </summary>
public record StreamRestoreResponse
{
    /// <summary>
    ///     The Subject to send restore chunks to
    /// </summary>
    [JsonPropertyName("deliver_subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string DeliverSubject { get; set; } = default!;
}
