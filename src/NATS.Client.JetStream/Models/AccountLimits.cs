#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record AccountLimits
{
    /// <summary>
    ///     The maximum amount of Memory storage Stream Messages may consume
    /// </summary>
    [JsonPropertyName("max_memory")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-1, int.MaxValue)]
    public int MaxMemory { get; set; } = default!;

    /// <summary>
    ///     The maximum amount of File storage Stream Messages may consume
    /// </summary>
    [JsonPropertyName("max_storage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-1, int.MaxValue)]
    public int MaxStorage { get; set; } = default!;

    /// <summary>
    ///     The maximum number of Streams an account can create
    /// </summary>
    [JsonPropertyName("max_streams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-1, int.MaxValue)]
    public int MaxStreams { get; set; } = default!;

    /// <summary>
    ///     The maximum number of Consumer an account can create
    /// </summary>
    [JsonPropertyName("max_consumers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-1, int.MaxValue)]
    public int MaxConsumers { get; set; } = default!;

    /// <summary>
    ///     Indicates if Streams created in this account requires the max_bytes property set
    /// </summary>
    [JsonPropertyName("max_bytes_required")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool MaxBytesRequired { get; set; } = false;

    /// <summary>
    ///     The maximum number of outstanding ACKs any consumer may configure
    /// </summary>
    [JsonPropertyName("max_ack_pending")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int MaxAckPending { get; set; } = default!;

    /// <summary>
    ///     The maximum size any single memory stream may be
    /// </summary>
    [JsonPropertyName("memory_max_stream_bytes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-1, int.MaxValue)]
    public int MemoryMaxStreamBytes { get; set; } = -1;

    /// <summary>
    ///     The maximum size any single storage based stream may be
    /// </summary>
    [JsonPropertyName("storage_max_stream_bytes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-1, int.MaxValue)]
    public int StorageMaxStreamBytes { get; set; } = -1;
}
