#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     Defines a source where streams should be replicated from
/// </summary>
public record StreamSource
{
    /// <summary>
    ///     Stream name
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    [RegularExpression(@"^[^.*>]+$")]
    public string Name { get; set; } = default!;

    /// <summary>
    ///     Sequence to start replicating from
    /// </summary>
    [JsonPropertyName("opt_start_seq")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0D, 18446744073709552000D)]
    public long OptStartSeq { get; set; } = default!;

    /// <summary>
    ///     Time stamp to start replicating from
    /// </summary>
    [JsonPropertyName("opt_start_time")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DateTimeOffset OptStartTime { get; set; } = default!;

    /// <summary>
    ///     Replicate only a subset of messages based on filter
    /// </summary>
    [JsonPropertyName("filter_subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string FilterSubject { get; set; } = default!;

    /// <summary>
    ///     Subject transforms to apply to matching messages
    /// </summary>
    [JsonPropertyName("subject_transforms")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<SubjectTransform> SubjectTransforms { get; set; } = default!;

    [JsonPropertyName("external")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ExternalStreamSource External { get; set; } = default!;
}
