#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.CONSUMER.CREATE and $JS.API.CONSUMER.DURABLE.CREATE APIs
/// </summary>
public record ConsumerCreateRequest
{
    /// <summary>
    ///     The name of the stream to create the consumer in
    /// </summary>
    [JsonPropertyName("stream_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string StreamName { get; set; } = default!;

    /// <summary>
    ///     The consumer configuration
    /// </summary>
    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public ConsumerConfiguration Config { get; set; } = default!;
}
