#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record Tier
{
    /// <summary>
    ///     Memory Storage being used for Stream Message storage
    /// </summary>
    [JsonPropertyName("memory")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0, int.MaxValue)]
    public int Memory { get; set; } = default!;

    /// <summary>
    ///     File Storage being used for Stream Message storage
    /// </summary>
    [JsonPropertyName("storage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0, int.MaxValue)]
    public int Storage { get; set; } = default!;

    /// <summary>
    ///     Number of active Streams
    /// </summary>
    [JsonPropertyName("streams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0, int.MaxValue)]
    public int Streams { get; set; } = default!;

    /// <summary>
    ///     Number of active Consumers
    /// </summary>
    [JsonPropertyName("consumers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(0, int.MaxValue)]
    public int Consumers { get; set; } = default!;

    [JsonPropertyName("limits")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public AccountLimits Limits { get; set; } = new();
}
