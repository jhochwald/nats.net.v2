#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.STREAM.LIST API
/// </summary>
public record StreamListRequest
{
    /// <summary>
    ///     Limit the list to streams matching this subject filter
    /// </summary>
    [JsonPropertyName("subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Subject { get; set; } = default!;

    [JsonPropertyName("offset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0, int.MaxValue)]
    public int Offset { get; set; } = default!;
}
