#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record ConsumerInfo
{
    /// <summary>
    ///     The Stream the consumer belongs to
    /// </summary>
    [JsonPropertyName("stream_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string StreamName { get; set; } = default!;

    /// <summary>
    ///     A unique name for the consumer, either machine generated or the durable name
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string Name { get; set; } = default!;

    /// <summary>
    ///     The server time the consumer info was created
    /// </summary>
    [JsonPropertyName("ts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DateTimeOffset Ts { get; set; } = default!;

    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public ConsumerConfiguration Config { get; set; } = default!;

    /// <summary>
    ///     The time the Consumer was created
    /// </summary>
    [JsonPropertyName("created")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public DateTimeOffset Created { get; set; } = default!;

    /// <summary>
    ///     The last message delivered from this Consumer
    /// </summary>
    [JsonPropertyName("delivered")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public SequenceInfo Delivered { get; set; } = new();

    /// <summary>
    ///     The highest contiguous acknowledged message
    /// </summary>
    [JsonPropertyName("ack_floor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public SequenceInfo AckFloor { get; set; } = new();

    /// <summary>
    ///     The number of messages pending acknowledgement
    /// </summary>
    [JsonPropertyName("num_ack_pending")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long NumAckPending { get; set; } = default!;

    /// <summary>
    ///     The number of redeliveries that have been performed
    /// </summary>
    [JsonPropertyName("num_redelivered")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long NumRedelivered { get; set; } = default!;

    /// <summary>
    ///     The number of pull consumers waiting for messages
    /// </summary>
    [JsonPropertyName("num_waiting")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long NumWaiting { get; set; } = default!;

    /// <summary>
    ///     The number of messages left unconsumed in this Consumer
    /// </summary>
    [JsonPropertyName("num_pending")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0D, 18446744073709552000D)]
    public long NumPending { get; set; } = default!;

    [JsonPropertyName("cluster")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ClusterInfo Cluster { get; set; } = default!;

    /// <summary>
    ///     Indicates if any client is connected and receiving messages from a push consumer
    /// </summary>
    [JsonPropertyName("push_bound")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool PushBound { get; set; } = default!;
}
