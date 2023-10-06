#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.STREAM.MSG.DELETE API
/// </summary>
public record StreamMsgDeleteRequest
{
    /// <summary>
    ///     Stream sequence number of the message to delete
    /// </summary>
    [JsonPropertyName("seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0D, 18446744073709552000D)]
    public long Seq { get; set; } = default!;

    /// <summary>
    ///     Default will securely remove a message and rewrite the data with random data, set this to true to only remove the message
    /// </summary>
    [JsonPropertyName("no_erase")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool NoErase { get; set; } = default!;
}
