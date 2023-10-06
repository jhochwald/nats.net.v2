#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.STREAM.PURGE API
/// </summary>
public record StreamPurgeRequest
{
    /// <summary>
    ///     Restrict purging to messages that match this subject
    /// </summary>
    [JsonPropertyName("filter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Filter { get; set; } = default!;

    /// <summary>
    ///     Purge all messages up to but not including the message with this sequence. Can be combined with subject filter but not the keep option
    /// </summary>
    [JsonPropertyName("seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0D, 18446744073709552000D)]
    public long Seq { get; set; } = default!;

    /// <summary>
    ///     Ensures this many messages are present after the purge. Can be combined with the subject filter but not the sequence
    /// </summary>
    [JsonPropertyName("keep")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0D, 18446744073709552000D)]
    public long Keep { get; set; } = default!;
}
