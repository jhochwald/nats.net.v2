#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record PeerInfo
{
    /// <summary>
    ///     The server name of the peer
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string Name { get; set; } = default!;

    /// <summary>
    ///     Indicates if the server is up to date and synchronised
    /// </summary>
    [JsonPropertyName("current")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public bool Current { get; set; } = false;

    /// <summary>
    ///     Nanoseconds since this peer was last seen
    /// </summary>
    [JsonPropertyName("active")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public double Active { get; set; } = default!;

    /// <summary>
    ///     Indicates the node is considered offline by the group
    /// </summary>
    [JsonPropertyName("offline")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Offline { get; set; } = false;

    /// <summary>
    ///     How many uncommitted operations this peer is behind the leader
    /// </summary>
    [JsonPropertyName("lag")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0, int.MaxValue)]
    public int Lag { get; set; } = default!;
}
