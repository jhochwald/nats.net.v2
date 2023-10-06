#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     Placement requirements for a stream
/// </summary>
public record Placement
{
    /// <summary>
    ///     The desired cluster name to place the stream
    /// </summary>
    [JsonPropertyName("cluster")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string Cluster { get; set; } = default!;

    /// <summary>
    ///     Tags required on servers hosting this stream
    /// </summary>
    [JsonPropertyName("tags")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<string> Tags { get; set; } = default!;
}
