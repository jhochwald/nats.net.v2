#region

using NATS.Client.JetStream.Models;

#endregion

namespace NATS.Client.JetStream.Internal;

/// <summary>
///     JetStream response including an optional error property encapsulating both successful and failed calls.
/// </summary>
/// <typeparam name="T">JetStream response type</typeparam>
internal readonly struct NatsJSResponse<T>
{
    internal NatsJSResponse(T? response, ApiError? error)
    {
        Response = response;
        Error = error;
    }

    public T? Response { get; }

    public ApiError? Error { get; }

    public bool Success => Error == null && Response != null;

    public void EnsureSuccess()
    {
        if (!Success)
        {
            throw new NatsJSApiException(Error ?? new ApiError { Description = "Unknown state" });
        }
    }
}
