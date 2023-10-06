#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     The data structure that describe the configuration of a NATS JetStream Stream Template
/// </summary>
public record StreamTemplateConfiguration
{
    /// <summary>
    ///     A unique name for the Stream Template.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    [RegularExpression(@"^[^.*>]+$")]
    public string Name { get; set; } = default!;

    /// <summary>
    ///     The maximum number of Streams this Template can create, -1 for unlimited.
    /// </summary>
    [JsonPropertyName("max_streams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-2147483648, 2147483647)]
    public int MaxStreams { get; set; } = default!;

    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public StreamConfiguration Config { get; set; } = new();
}
