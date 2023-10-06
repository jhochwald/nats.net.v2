#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     Configuration referencing a stream source in another account or JetStream domain
/// </summary>
public record ExternalStreamSource
{
    /// <summary>
    ///     The subject prefix that imports the other account/domain $JS.API.CONSUMER.&gt; subjects
    /// </summary>
    [JsonPropertyName("api")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required(AllowEmptyStrings = true)]
    public string Api { get; set; } = default!;

    /// <summary>
    ///     The delivery subject to use for the push consumer
    /// </summary>
    [JsonPropertyName("deliver")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Deliver { get; set; } = default!;
}
