#region

using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.STREAM.NAMES API
/// </summary>
public record StreamNamesResponse : IterableResponse
{
    [JsonPropertyName("consumers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<string> Consumers { get; set; } = default!;
}
