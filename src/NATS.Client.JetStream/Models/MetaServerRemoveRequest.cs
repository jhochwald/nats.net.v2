#region

using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.SERVER.REMOVE API
/// </summary>
public record MetaServerRemoveRequest
{
    /// <summary>
    ///     The Name of the server to remove from the meta group
    /// </summary>
    [JsonPropertyName("peer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Peer { get; set; } = default!;

    /// <summary>
    ///     Peer ID of the peer to be removed. If specified this is used instead of the server name
    /// </summary>
    [JsonPropertyName("peer_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string PeerId { get; set; } = default!;
}
