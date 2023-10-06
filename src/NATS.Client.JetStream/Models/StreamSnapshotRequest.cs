#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.STREAM.SNAPSHOT API
/// </summary>
public record StreamSnapshotRequest
{
    /// <summary>
    ///     The NATS subject where the snapshot will be delivered
    /// </summary>
    [JsonPropertyName("deliver_subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string DeliverSubject { get; set; } = default!;

    /// <summary>
    ///     When true consumer states and configurations will not be present in the snapshot
    /// </summary>
    [JsonPropertyName("no_consumers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool NoConsumers { get; set; } = default!;

    /// <summary>
    ///     The size of data chunks to send to deliver_subject
    /// </summary>
    [JsonPropertyName("chunk_size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long ChunkSize { get; set; } = default!;

    /// <summary>
    ///     Check all message's checksums prior to snapshot
    /// </summary>
    [JsonPropertyName("jsck")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Jsck { get; set; } = false;
}
