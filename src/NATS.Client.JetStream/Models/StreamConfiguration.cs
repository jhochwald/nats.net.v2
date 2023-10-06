#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record StreamConfiguration
{
    /// <summary>
    ///     A unique name for the Stream, empty for Stream Templates.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [StringLength(int.MaxValue)]
    [RegularExpression(@"^[^.*>]*$")]
    public string Name { get; set; } = default!;

    /// <summary>
    ///     A short description of the purpose of this stream
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [StringLength(4096)]
    public string Description { get; set; } = default!;

    /// <summary>
    ///     A list of subjects to consume, supports wildcards. Must be empty when a mirror is configured. May be empty when sources are configured.
    /// </summary>
    [JsonPropertyName("subjects")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<string> Subjects { get; set; } = default!;

    /// <summary>
    ///     Subject transform to apply to matching messages
    /// </summary>
    [JsonPropertyName("subject_transform")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public SubjectTransform SubjectTransform { get; set; } = default!;

    /// <summary>
    ///     How messages are retained in the Stream, once this is exceeded old messages are removed.
    /// </summary>
    [JsonPropertyName("retention")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StreamConfigurationRetention Retention { get; set; } =
        StreamConfigurationRetention.limits;

    /// <summary>
    ///     How many Consumers can be defined for a given Stream. -1 for unlimited.
    /// </summary>
    [JsonPropertyName("max_consumers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxConsumers { get; set; } = default!;

    /// <summary>
    ///     How many messages may be in a Stream, oldest messages will be removed if the Stream exceeds this size. -1 for unlimited.
    /// </summary>
    [JsonPropertyName("max_msgs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxMsgs { get; set; } = default!;

    /// <summary>
    ///     For wildcard streams ensure that for every unique subject this many messages are kept - a per subject retention limit
    /// </summary>
    [JsonPropertyName("max_msgs_per_subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxMsgsPerSubject { get; set; } = default!;

    /// <summary>
    ///     How big the Stream may be, when the combined stream size exceeds this old messages are removed. -1 for unlimited.
    /// </summary>
    [JsonPropertyName("max_bytes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxBytes { get; set; } = default!;

    /// <summary>
    ///     Maximum age of any message in the stream, expressed in nanoseconds. 0 for unlimited.
    /// </summary>
    [JsonPropertyName("max_age")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxAge { get; set; } = default!;

    /// <summary>
    ///     The largest message that will be accepted by the Stream. -1 for unlimited.
    /// </summary>
    [JsonPropertyName("max_msg_size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-2147483648, 2147483647)]
    public int MaxMsgSize { get; set; } = default!;

    /// <summary>
    ///     The storage backend to use for the Stream.
    /// </summary>
    [JsonPropertyName("storage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StreamConfigurationStorage Storage { get; set; } = StreamConfigurationStorage.file;

    /// <summary>
    ///     Optional compression algorithm used for the Stream.
    /// </summary>
    [JsonPropertyName("compression")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StreamConfigurationCompression Compression { get; set; } =
        StreamConfigurationCompression.none;

    /// <summary>
    ///     How many replicas to keep for each message.
    /// </summary>
    [JsonPropertyName("num_replicas")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long NumReplicas { get; set; } = default!;

    /// <summary>
    ///     Disables acknowledging messages that are received by the Stream.
    /// </summary>
    [JsonPropertyName("no_ack")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool NoAck { get; set; } = false;

    /// <summary>
    ///     When the Stream is managed by a Stream Template this identifies the template that manages the Stream.
    /// </summary>
    [JsonPropertyName("template_owner")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string TemplateOwner { get; set; } = default!;

    /// <summary>
    ///     When a Stream reach it's limits either old messages are deleted or new ones are denied
    /// </summary>
    [JsonPropertyName("discard")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StreamConfigurationDiscard Discard { get; set; } = StreamConfigurationDiscard.old;

    /// <summary>
    ///     The time window to track duplicate messages for, expressed in nanoseconds. 0 for default
    /// </summary>
    [JsonPropertyName("duplicate_window")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long DuplicateWindow { get; set; } = default!;

    /// <summary>
    ///     Placement directives to consider when placing replicas of this stream, random placement when unset
    /// </summary>
    [JsonPropertyName("placement")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Placement Placement { get; set; } = default!;

    /// <summary>
    ///     Maintains a 1:1 mirror of another stream with name matching this property.  When a mirror is configured subjects and sources must be empty.
    /// </summary>
    [JsonPropertyName("mirror")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public StreamSource Mirror { get; set; } = default!;

    /// <summary>
    ///     List of Stream names to replicate into this Stream
    /// </summary>
    [JsonPropertyName("sources")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<StreamSource> Sources { get; set; } = default!;

    /// <summary>
    ///     Sealed streams do not allow messages to be deleted via limits or API, sealed streams can not be unsealed via configuration update. Can only be set on already created streams via the Update API
    /// </summary>
    [JsonPropertyName("sealed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Sealed { get; set; } = false;

    /// <summary>
    ///     Restricts the ability to delete messages from a stream via the API. Cannot be changed once set to true
    /// </summary>
    [JsonPropertyName("deny_delete")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool DenyDelete { get; set; } = false;

    /// <summary>
    ///     Restricts the ability to purge messages from a stream via the API. Cannot be change once set to true
    /// </summary>
    [JsonPropertyName("deny_purge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool DenyPurge { get; set; } = false;

    /// <summary>
    ///     Allows the use of the Nats-Rollup header to replace all contents of a stream, or subject in a stream, with a single new message
    /// </summary>
    [JsonPropertyName("allow_rollup_hdrs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool AllowRollupHdrs { get; set; } = false;

    /// <summary>
    ///     Allow higher performance, direct access to get individual messages
    /// </summary>
    [JsonPropertyName("allow_direct")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool AllowDirect { get; set; } = false;

    /// <summary>
    ///     Allow higher performance, direct access for mirrors as well
    /// </summary>
    [JsonPropertyName("mirror_direct")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool MirrorDirect { get; set; } = false;

    [JsonPropertyName("republish")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Republish Republish { get; set; } = default!;

    /// <summary>
    ///     When discard policy is new and the stream is one with max messages per subject set, this will apply the new behavior to every subject. Essentially turning discard new from maximum number of subjects into maximum number of messages in a subject.
    /// </summary>
    [JsonPropertyName("discard_new_per_subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool DiscardNewPerSubject { get; set; } = false;

    /// <summary>
    ///     Additional metadata for the Stream
    /// </summary>
    [JsonPropertyName("metadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IDictionary<string, string> Metadata { get; set; } = default!;
}
