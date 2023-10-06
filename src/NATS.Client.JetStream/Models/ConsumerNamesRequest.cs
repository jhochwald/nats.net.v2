#region

using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.CONSUMER.NAMES API
/// </summary>
public record ConsumerNamesRequest : IterableRequest
{
    /// <summary>
    ///     Filter the names to those consuming messages matching this subject or wildcard
    /// </summary>
    [JsonPropertyName("subject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Subject { get; set; } = default!;
}
