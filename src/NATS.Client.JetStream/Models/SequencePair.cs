#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record SequencePair
{
    /// <summary>
    ///     The sequence number of the Consumer
    /// </summary>
    [JsonPropertyName("consumer_seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0D, 18446744073709552000D)]
    public long ConsumerSeq { get; set; } = default!;

    /// <summary>
    ///     The sequence number of the Stream
    /// </summary>
    [JsonPropertyName("stream_seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0D, 18446744073709552000D)]
    public long StreamSeq { get; set; } = default!;
}
