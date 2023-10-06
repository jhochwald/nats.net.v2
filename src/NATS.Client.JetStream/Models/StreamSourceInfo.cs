#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     Information about an upstream stream source in a mirror
/// </summary>
public record StreamSourceInfo
{
    /// <summary>
    ///     The name of the Stream being replicated
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string Name { get; set; } = default!;

    /// <summary>
    ///     The subject filter to apply to the messages
    /// </summary>
    [JsonPropertyName("filter_subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string FilterSubject { get; set; } = default!;

    /// <summary>
    ///     The subject transform destination to apply to the messages
    /// </summary>
    [JsonPropertyName("subject_transform_dest")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string SubjectTransformDest { get; set; } = default!;

    /// <summary>
    ///     How many messages behind the mirror operation is
    /// </summary>
    [JsonPropertyName("lag")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0D, 18446744073709552000D)]
    public long Lag { get; set; } = default!;

    /// <summary>
    ///     When last the mirror had activity, in nanoseconds. Value will be -1 when there has been no activity.
    /// </summary>
    [JsonPropertyName("active")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long Active { get; set; } = default!;

    [JsonPropertyName("external")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ExternalStreamSource External { get; set; } = default!;

    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ApiError Error { get; set; } = default!;
}
