#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record StreamInfo
{
    /// <summary>
    ///     The active configuration for the Stream
    /// </summary>
    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public StreamConfiguration Config { get; set; } = new();

    /// <summary>
    ///     Detail about the current State of the Stream
    /// </summary>
    [JsonPropertyName("state")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public StreamState State { get; set; } = new();

    /// <summary>
    ///     Timestamp when the stream was created
    /// </summary>
    [JsonPropertyName("created")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public DateTimeOffset Created { get; set; } = default!;

    /// <summary>
    ///     The server time the stream info was created
    /// </summary>
    [JsonPropertyName("ts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DateTimeOffset Ts { get; set; } = default!;

    [JsonPropertyName("cluster")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ClusterInfo Cluster { get; set; } = default!;

    [JsonPropertyName("mirror")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public StreamSourceInfo Mirror { get; set; } = default!;

    /// <summary>
    ///     Streams being sourced into this Stream
    /// </summary>
    [JsonPropertyName("sources")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<StreamSourceInfo> Sources { get; set; } = default!;

    /// <summary>
    ///     List of mirrors sorted by priority
    /// </summary>
    [JsonPropertyName("alternates")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<StreamAlternate> Alternates { get; set; } = default!;
}
