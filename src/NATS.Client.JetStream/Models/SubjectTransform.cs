#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     Subject transform to apply to matching messages going into the stream
/// </summary>
public record SubjectTransform
{
    /// <summary>
    ///     The subject transform source
    /// </summary>
    [JsonPropertyName("src")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Src { get; set; } = default!;

    /// <summary>
    ///     The subject transform destination
    /// </summary>
    [JsonPropertyName("dest")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string Dest { get; set; } = default!;
}
