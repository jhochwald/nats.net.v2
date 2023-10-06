#region

using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.META.LEADER.STEPDOWN API
/// </summary>
public record MetaLeaderStepdownRequest
{
    [JsonPropertyName("placement")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Placement Placement { get; set; } = default!;
}
