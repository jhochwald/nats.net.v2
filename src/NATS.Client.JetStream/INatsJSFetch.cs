#region

using System.Threading.Channels;

#endregion

namespace NATS.Client.JetStream;

/// <summary>
///     Interface to manage a <c>fetch()</c> operation on a consumer.
/// </summary>
public interface INatsJSFetch : IAsyncDisposable
{
    void Stop();
}

/// <summary>
///     Interface to extract messages from a <c>fetch()</c> operation on a consumer.
/// </summary>
public interface INatsJSFetch<T> : INatsJSFetch
{
    ChannelReader<NatsJSMsg<T?>> Msgs { get; }
}
