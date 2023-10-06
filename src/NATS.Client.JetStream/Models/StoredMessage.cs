#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record StoredMessage
{
    /// <summary>
    ///     The subject the message was originally received on
    /// </summary>
    [JsonPropertyName("subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string Subject { get; set; } = default!;

    /// <summary>
    ///     The sequence number of the message in the Stream
    /// </summary>
    [JsonPropertyName("seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0D, 18446744073709552000D)]
    public long Seq { get; set; } = default!;

    /// <summary>
    ///     The base64 encoded payload of the message body
    /// </summary>
    [JsonPropertyName("data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [StringLength(int.MaxValue)]
    public string Data { get; set; } = default!;

    /// <summary>
    ///     The time the message was received
    /// </summary>
    [JsonPropertyName("time")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string Time { get; set; } = default!;

    /// <summary>
    ///     Base64 encoded headers for the message
    /// </summary>
    [JsonPropertyName("hdrs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Hdrs { get; set; } = default!;
}
