#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.STREAM.INFO API
/// </summary>
public record StreamInfoRequest
{
    /// <summary>
    ///     When true will result in a full list of deleted message IDs being returned in the info response
    /// </summary>
    [JsonPropertyName("deleted_details")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool DeletedDetails { get; set; } = default!;

    /// <summary>
    ///     When set will return a list of subjects and how many messages they hold for all matching subjects. Filter is a standard NATS subject wildcard pattern.
    /// </summary>
    [JsonPropertyName("subjects_filter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string SubjectsFilter { get; set; } = default!;

    /// <summary>
    ///     Paging offset when retrieving pages of subjet details
    /// </summary>
    [JsonPropertyName("offset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0, int.MaxValue)]
    public int Offset { get; set; } = default!;
}
