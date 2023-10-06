#region

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.CONSUMER.LIST API
/// </summary>
public record ConsumerListResponse : IterableResponse
{
    /// <summary>
    ///     Full Consumer information for each known Consumer
    /// </summary>
    [JsonPropertyName("consumers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public ICollection<ConsumerInfo> Consumers { get; set; } = new Collection<ConsumerInfo>();
}
