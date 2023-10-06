#region

using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

/// <summary>
///     A response from the JetStream $JS.API.ACCOUNT.PURGE API
/// </summary>
public record AccountPurgeResponse
{
    /// <summary>
    ///     If the purge operation was succesfully started
    /// </summary>
    [JsonPropertyName("initiated")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Initiated { get; set; } = false;
}
