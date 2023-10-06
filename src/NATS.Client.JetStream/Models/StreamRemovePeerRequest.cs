#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.STREAM.PEER.REMOVE API
/// </summary>
public record StreamRemovePeerRequest
{
    /// <summary>
    ///     Server name of the peer to remove
    /// </summary>
    [JsonPropertyName("peer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string Peer { get; set; } = default!;
}
