#region

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.CONSUMER.NAMES API
/// </summary>
public record ConsumerNamesResponse : IterableResponse
{
    [JsonPropertyName("consumers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public ICollection<string> Consumers { get; set; } = new Collection<string>();
}
