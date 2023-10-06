#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     Records messages that were damaged and unrecoverable
/// </summary>
public record LostStreamData
{
    /// <summary>
    ///     The messages that were lost
    /// </summary>
    [JsonPropertyName("msgs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<long>? Msgs { get; set; } = default!;

    /// <summary>
    ///     The number of bytes that were lost
    /// </summary>
    [JsonPropertyName("bytes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0D, 18446744073709552000D)]
    public long Bytes { get; set; } = default!;
}
