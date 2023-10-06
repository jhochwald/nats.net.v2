#region

using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NATS.Client.Core.Internal;

#endregion

namespace NATS.Client.Core;

/// <summary>
///     Immutable options for NatsConnection, you can configure via `with` operator.
/// </summary>
/// <param name="Url"></param>
/// <param name="Name"></param>
/// <param name="Echo"></param>
/// <param name="Verbose"></param>
/// <param name="Headers"></param>
/// <param name="AuthOpts"></param>
/// <param name="TlsOpts"></param>
/// <param name="Serializer"></param>
/// <param name="LoggerFactory"></param>
/// <param name="WriterBufferSize"></param>
/// <param name="ReaderBufferSize"></param>
/// <param name="UseThreadPoolCallback"></param>
/// <param name="InboxPrefix"></param>
/// <param name="NoRandomize"></param>
/// <param name="PingInterval"></param>
/// <param name="MaxPingOut"></param>
/// <param name="ReconnectWait"></param>
/// <param name="ReconnectJitter"></param>
/// <param name="ConnectTimeout"></param>
/// <param name="ObjectPoolSize"></param>
/// <param name="RequestTimeout"></param>
/// <param name="CommandTimeout"></param>
/// <param name="SubscriptionCleanUpInterval"></param>
/// <param name="WriterCommandBufferLimit"></param>
/// <param name="HeaderEncoding"></param>
/// <param name="WaitUntilSent"></param>
public sealed record NatsOpts
(
    string Url,
    string Name,
    bool Echo,
    bool Verbose,
    bool Headers,
    NatsAuthOpts AuthOpts,
    NatsTlsOpts TlsOpts,
    INatsSerializer Serializer,
    ILoggerFactory LoggerFactory,
    int WriterBufferSize,
    int ReaderBufferSize,
    bool UseThreadPoolCallback,
    string InboxPrefix,
    bool NoRandomize,
    TimeSpan PingInterval,
    int MaxPingOut,
    TimeSpan ReconnectWait,
    TimeSpan ReconnectJitter,
    TimeSpan ConnectTimeout,
    int ObjectPoolSize,
    TimeSpan RequestTimeout,
    TimeSpan CommandTimeout,
    TimeSpan SubscriptionCleanUpInterval,
    int? WriterCommandBufferLimit,
    Encoding HeaderEncoding,
    bool WaitUntilSent)
{
    public static readonly NatsOpts Default = new(
        "nats://localhost:4222",
        "NATS .Net Client",
        true,
        false,
        true,
        NatsAuthOpts.Default,
        NatsTlsOpts.Default,
        NatsDefaultSerializer.Default,
        NullLoggerFactory.Instance,
        65534, // 32767
        1048576,
        false,
        "_INBOX",
        false,
        TimeSpan.FromMinutes(2),
        2,
        TimeSpan.FromSeconds(2),
        TimeSpan.FromMilliseconds(100),
        TimeSpan.FromSeconds(2),
        256,
        TimeSpan.FromSeconds(5),
        TimeSpan.FromMinutes(1),
        TimeSpan.FromMinutes(5),
        1_000,
        Encoding.ASCII,
        false);

    internal NatsUri[] GetSeedUris()
    {
        var urls = Url.Split(',');
        return NoRandomize
            ? urls.Select(x => new NatsUri(x, true)).Distinct().ToArray()
            : urls.Select(x => new NatsUri(x, true)).OrderBy(_ => Guid.NewGuid()).Distinct().ToArray();
    }
}
