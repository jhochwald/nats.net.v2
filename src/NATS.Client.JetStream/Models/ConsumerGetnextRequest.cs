#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A request to the JetStream $JS.API.CONSUMER.MSG.NEXT API
/// </summary>
public record ConsumerGetnextRequest
{
    /// <summary>
    ///     A duration from now when the pull should expire, stated in nanoseconds, 0 for no expiry
    /// </summary>
    [JsonPropertyName("expires")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long Expires { get; set; } = default!;

    /// <summary>
    ///     How many messages the server should deliver to the requestor
    /// </summary>
    [JsonPropertyName("batch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long Batch { get; set; } = default!;

    /// <summary>
    ///     Sends at most this many bytes to the requestor, limited by consumer configuration max_bytes
    /// </summary>
    [JsonPropertyName("max_bytes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long MaxBytes { get; set; } = default!;

    /// <summary>
    ///     When true a response with a 404 status header will be returned when no messages are available
    /// </summary>
    [JsonPropertyName("no_wait")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool NoWait { get; set; } = default!;

    /// <summary>
    ///     When not 0 idle heartbeats will be sent on this interval
    /// </summary>
    [JsonPropertyName("idle_heartbeat")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(-9223372036854776000D, 9223372036854776000D)]
    public long IdleHeartbeat { get; set; } = default!;
}
