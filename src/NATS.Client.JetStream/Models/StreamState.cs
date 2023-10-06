#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record StreamState
{
    /// <summary>
    ///     Number of messages stored in the Stream
    /// </summary>
    [JsonPropertyName("messages")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0D, 18446744073709552000D)]
    public long Messages { get; set; } = default!;

    /// <summary>
    ///     Combined size of all messages in the Stream
    /// </summary>
    [JsonPropertyName("bytes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0D, 18446744073709552000D)]
    public long Bytes { get; set; } = default!;

    /// <summary>
    ///     Sequence number of the first message in the Stream
    /// </summary>
    [JsonPropertyName("first_seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0D, 18446744073709552000D)]
    public long FirstSeq { get; set; } = default!;

    /// <summary>
    ///     The timestamp of the first message in the Stream
    /// </summary>
    [JsonPropertyName("first_ts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string FirstTs { get; set; } = default!;

    /// <summary>
    ///     Sequence number of the last message in the Stream
    /// </summary>
    [JsonPropertyName("last_seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0D, 18446744073709552000D)]
    public long LastSeq { get; set; } = default!;

    /// <summary>
    ///     The timestamp of the last message in the Stream
    /// </summary>
    [JsonPropertyName("last_ts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string LastTs { get; set; } = default!;

    /// <summary>
    ///     IDs of messages that were deleted using the Message Delete API or Interest based streams removing messages out of order
    /// </summary>
    [JsonPropertyName("deleted")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<long> Deleted { get; set; } = default!;

    /// <summary>
    ///     Subjects and their message counts when a subjects_filter was set
    /// </summary>
    [JsonPropertyName("subjects")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IDictionary<string, long> Subjects { get; set; } = default!;

    /// <summary>
    ///     The number of unique subjects held in the stream
    /// </summary>
    [JsonPropertyName("num_subjects")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long NumSubjects { get; set; } = default!;

    /// <summary>
    ///     The number of deleted messages
    /// </summary>
    [JsonPropertyName("num_deleted")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long NumDeleted { get; set; } = default!;

    [JsonPropertyName("lost")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public LostStreamData Lost { get; set; } = default!;

    /// <summary>
    ///     Number of Consumers attached to the Stream
    /// </summary>
    [JsonPropertyName("consumer_count")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long ConsumerCount { get; set; } = default!;
}
