#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.STREAM.MSG.GET API
/// </summary>
public record StreamMsgGetResponse
{
    [JsonPropertyName("message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public StoredMessage Message { get; set; } = new();
}
