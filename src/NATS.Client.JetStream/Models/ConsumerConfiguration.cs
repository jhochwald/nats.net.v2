#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record ConsumerConfiguration
{
    [JsonPropertyName("deliver_policy")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ConsumerConfigurationDeliverPolicy DeliverPolicy { get; set; } = default!;

    [JsonPropertyName("opt_start_seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0D, 18446744073709552000D)]
    public long OptStartSeq { get; set; } = default!;

    [JsonPropertyName("opt_start_time")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DateTimeOffset OptStartTime { get; set; } = default!;

    /// <summary>
    ///     A unique name for a durable consumer
    /// </summary>
    [JsonPropertyName("durable_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    [RegularExpression(@"^[^.*>]+$")]
    public string DurableName { get; set; } = default!;

    /// <summary>
    ///     A unique name for a consumer
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    [RegularExpression(@"^[^.*>]+$")]
    public string Name { get; set; } = default!;

    /// <summary>
    ///     A short description of the purpose of this consumer
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [StringLength(4096)]
    public string Description { get; set; } = default!;

    [JsonPropertyName("deliver_subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string DeliverSubject { get; set; } = default!;

    [JsonPropertyName("ack_policy")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ConsumerConfigurationAckPolicy AckPolicy { get; set; } = ConsumerConfigurationAckPolicy.none;

    /// <summary>
    ///     How long (in nanoseconds) to allow messages to remain un-acknowledged before attempting redelivery
    /// </summary>
    [JsonPropertyName("ack_wait")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long AckWait { get; set; } = default!;

    /// <summary>
    ///     The number of times a message will be redelivered to consumers if not acknowledged in time
    /// </summary>
    [JsonPropertyName("max_deliver")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxDeliver { get; set; } = default!;

    /// <summary>
    ///     Filter the stream by a single subjects
    /// </summary>
    [JsonPropertyName("filter_subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string FilterSubject { get; set; } = default!;

    /// <summary>
    ///     Filter the stream by multiple subjects
    /// </summary>
    [JsonPropertyName("filter_subjects")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<string> FilterSubjects { get; set; } = default!;

    [JsonPropertyName("replay_policy")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ConsumerConfigurationReplayPolicy ReplayPolicy { get; set; } = ConsumerConfigurationReplayPolicy.instant;

    [JsonPropertyName("sample_freq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string SampleFreq { get; set; } = default!;

    /// <summary>
    ///     The rate at which messages will be delivered to clients, expressed in bit per second
    /// </summary>
    [JsonPropertyName("rate_limit_bps")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0D, 18446744073709552000D)]
    public long RateLimitBps { get; set; } = default!;

    /// <summary>
    ///     The maximum number of messages without acknowledgement that can be outstanding, once this limit is reached message delivery will be suspended
    /// </summary>
    [JsonPropertyName("max_ack_pending")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxAckPending { get; set; } = default!;

    /// <summary>
    ///     If the Consumer is idle for more than this many nano seconds a empty message with Status header 100 will be sent indicating the consumer is still alive
    /// </summary>
    [JsonPropertyName("idle_heartbeat")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long IdleHeartbeat { get; set; } = default!;

    /// <summary>
    ///     For push consumers this will regularly send an empty mess with Status header 100 and a reply subject, consumers must reply to these messages to control the rate of message delivery
    /// </summary>
    [JsonPropertyName("flow_control")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool FlowControl { get; set; } = default!;

    /// <summary>
    ///     The number of pulls that can be outstanding on a pull consumer, pulls received after this is reached are ignored
    /// </summary>
    [JsonPropertyName("max_waiting")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxWaiting { get; set; } = default!;

    /// <summary>
    ///     Creates a special consumer that does not touch the Raft layers, not for general use by clients, internal use only
    /// </summary>
    [JsonPropertyName("direct")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Direct { get; set; } = false;

    /// <summary>
    ///     Delivers only the headers of messages in the stream and not the bodies. Additionally adds Nats-Msg-Size header to indicate the size of the removed payload
    /// </summary>
    [JsonPropertyName("headers_only")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool HeadersOnly { get; set; } = false;

    /// <summary>
    ///     The largest batch property that may be specified when doing a pull on a Pull Consumer
    /// </summary>
    [JsonPropertyName("max_batch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int MaxBatch { get; set; } = 0;

    /// <summary>
    ///     The maximum expires value that may be set when doing a pull on a Pull Consumer
    /// </summary>
    [JsonPropertyName("max_expires")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxExpires { get; set; } = default!;

    /// <summary>
    ///     The maximum bytes value that maybe set when dong a pull on a Pull Consumer
    /// </summary>
    [JsonPropertyName("max_bytes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxBytes { get; set; } = default!;

    /// <summary>
    ///     Duration that instructs the server to cleanup ephemeral consumers that are inactive for that long
    /// </summary>
    [JsonPropertyName("inactive_threshold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long InactiveThreshold { get; set; } = default!;

    /// <summary>
    ///     List of durations in Go format that represents a retry time scale for NaK'd messages
    /// </summary>
    [JsonPropertyName("backoff")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<long> Backoff { get; set; } = default!;

    /// <summary>
    ///     When set do not inherit the replica count from the stream but specifically set it to this amount
    /// </summary>
    [JsonPropertyName("num_replicas")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long NumReplicas { get; set; } = default!;

    /// <summary>
    ///     Force the consumer state to be kept in memory rather than inherit the setting from the stream
    /// </summary>
    [JsonPropertyName("mem_storage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool MemStorage { get; set; } = false;

    /// <summary>
    ///     Additional metadata for the Consumer
    /// </summary>
    [JsonPropertyName("metadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IDictionary<string, string> Metadata { get; set; } = default!;
}
