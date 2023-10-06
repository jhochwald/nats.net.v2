#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     Rules for republishing messages from a stream with subject mapping onto new subjects for partitioning and more
/// </summary>
public record Republish
{
    /// <summary>
    ///     The source subject to republish
    /// </summary>
    [JsonPropertyName("src")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string Src { get; set; } = default!;

    /// <summary>
    ///     The destination to publish to
    /// </summary>
    [JsonPropertyName("dest")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string Dest { get; set; } = default!;

    /// <summary>
    ///     Only send message headers, no bodies
    /// </summary>
    [JsonPropertyName("headers_only")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool HeadersOnly { get; set; } = false;
}
