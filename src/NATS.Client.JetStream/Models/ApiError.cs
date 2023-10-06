#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace NATS.Client.JetStream.Models;

public record ApiError
{
    /// <summary>
    ///     HTTP like error code in the 300 to 500 range
    /// </summary>
    [JsonPropertyName("code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Range(300, 699)]
    public int Code { get; set; } = default!;

    /// <summary>
    ///     A human friendly description of the error
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Description { get; set; } = default!;

    /// <summary>
    ///     The NATS error code unique to each kind of error
    /// </summary>
    [JsonPropertyName("err_code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [Range(0, 65535)]
    public int ErrCode { get; set; } = default!;
}
