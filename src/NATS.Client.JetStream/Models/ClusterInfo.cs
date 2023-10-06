#region

using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record ClusterInfo
{
    /// <summary>
    ///     The cluster name
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Name { get; set; } = default!;

    /// <summary>
    ///     The server name of the RAFT leader
    /// </summary>
    [JsonPropertyName("leader")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Leader { get; set; } = default!;

    /// <summary>
    ///     The members of the RAFT cluster
    /// </summary>
    [JsonPropertyName("replicas")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<PeerInfo> Replicas { get; set; } = default!;
}
