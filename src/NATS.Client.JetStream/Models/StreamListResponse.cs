#region

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.STREAM.LIST API
/// </summary>
public record StreamListResponse : IterableResponse
{
    /// <summary>
    ///     Full Stream information for each known Stream
    /// </summary>
    [JsonPropertyName("streams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public ICollection<StreamInfo> Streams { get; set; } = new Collection<StreamInfo>();

    /// <summary>
    ///     In clustered environments gathering Stream info might time out, this list would be a list of Streams for which information was not obtainable
    /// </summary>
    [JsonPropertyName("missing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<string> Missing { get; set; } = default!;
}
