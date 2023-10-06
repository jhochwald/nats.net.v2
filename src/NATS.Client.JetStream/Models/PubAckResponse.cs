#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response received when publishing a message
/// </summary>
public record PubAckResponse
{
    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ApiError Error { get; set; } = default!;

    /// <summary>
    ///     The name of the stream that received the message
    /// </summary>
    [JsonPropertyName("stream")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string Stream { get; set; } = default!;

    /// <summary>
    ///     If successful this will be the sequence the message is stored at
    /// </summary>
    [JsonPropertyName("seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0D, 18446744073709552000D)]
    public long Seq { get; set; } = default!;

    /// <summary>
    ///     Indicates that the message was not stored due to the Nats-Msg-Id header and duplicate tracking
    /// </summary>
    [JsonPropertyName("duplicate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Duplicate { get; set; } = false;

    /// <summary>
    ///     If the Stream accepting the message is in a JetStream server configured for a domain this would be that domain
    /// </summary>
    [JsonPropertyName("domain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Domain { get; set; } = default!;
}
