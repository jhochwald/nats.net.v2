#region

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record StreamTemplateInfo
{
    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public StreamTemplateConfiguration Config { get; set; } = new();

    /// <summary>
    ///     List of Streams managed by this Template
    /// </summary>
    [JsonPropertyName("streams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public ICollection<string> Streams { get; set; } = new Collection<string>();
}
