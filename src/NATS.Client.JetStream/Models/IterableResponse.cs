#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record IterableResponse
{
    [JsonPropertyName("total")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0, int.MaxValue)]
    public int Total { get; set; } = default!;

    [JsonPropertyName("offset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0, int.MaxValue)]
    public int Offset { get; set; } = default!;

    [JsonPropertyName("limit")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0, int.MaxValue)]
    public int Limit { get; set; } = default!;
}
