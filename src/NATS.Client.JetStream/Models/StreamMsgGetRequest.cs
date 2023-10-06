#region

using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.STREAM.MSG.GET API
/// </summary>
public record StreamMsgGetRequest
{
    /// <summary>
    ///     Stream sequence number of the message to retrieve, cannot be combined with last_by_subj
    /// </summary>
    [JsonPropertyName("seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Seq { get; set; } = default!;

    /// <summary>
    ///     Retrieves the last message for a given subject, cannot be combined with seq
    /// </summary>
    [JsonPropertyName("last_by_subj")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string LastBySubj { get; set; } = default!;

    /// <summary>
    ///     Combined with sequence gets the next message for a subject with the given sequence or higher
    /// </summary>
    [JsonPropertyName("next_by_subj")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string NextBySubj { get; set; } = default!;
}
