#region

using System.Buffers;
using System.Runtime.ExceptionServices;
using System.Threading.Channels;
using NATS.Client.Core.Internal;

#endregion

namespace NATS.Client.Core;

public sealed class NatsSub<T> : NatsSubBase, INatsSub<T>
{
    private readonly Channel<NatsMsg<T?>> _msgs;

    internal NatsSub(
        NatsConnection connection,
        ISubscriptionManager manager,
        string subject,
        string? queueGroup,
        NatsSubOpts? opts,
        INatsSerializer serializer
    )
        : base(connection, manager, subject, queueGroup, opts)
    {
        _msgs = Channel.CreateBounded<NatsMsg<T?>>(NatsSubUtils.GetChannelOpts(opts?.ChannelOpts));

        Serializer = serializer;
    }

    private INatsSerializer Serializer { get; }

    public ChannelReader<NatsMsg<T?>> Msgs => _msgs.Reader;

    protected override async ValueTask ReceiveInternalAsync(
        string subject,
        string? replyTo,
        ReadOnlySequence<byte>? headersBuffer,
        ReadOnlySequence<byte> payloadBuffer
    )
    {
        var natsMsg = NatsMsg<T?>.Build(
            subject,
            replyTo,
            headersBuffer,
            payloadBuffer,
            Connection,
            Connection.HeaderParser,
            Serializer
        );

        await _msgs.Writer.WriteAsync(natsMsg).ConfigureAwait(false);

        DecrementMaxMsgs();
    }

    protected override void TryComplete() => _msgs.Writer.TryComplete();
}

public class NatsSubException : NatsException
{
    public NatsSubException(
        string message,
        ExceptionDispatchInfo exception,
        Memory<byte> payload,
        Memory<byte> headers
    )
        : base(message)
    {
        Exception = exception;
        Payload = payload;
        Headers = headers;
    }

    public ExceptionDispatchInfo Exception { get; }

    public Memory<byte> Payload { get; }

    public Memory<byte> Headers { get; }
}

internal sealed class NatsSubUtils
{
    private static readonly BoundedChannelOptions DefaultChannelOpts =
        new(1_000)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleWriter = true,
            SingleReader = false,
            AllowSynchronousContinuations = false
        };

    internal static BoundedChannelOptions GetChannelOpts(NatsSubChannelOpts? subChannelOpts)
    {
        if (subChannelOpts is { } overrideOpts)
        {
            return new BoundedChannelOptions(overrideOpts.Capacity ?? DefaultChannelOpts.Capacity)
            {
                AllowSynchronousContinuations = DefaultChannelOpts.AllowSynchronousContinuations,
                FullMode = overrideOpts.FullMode ?? DefaultChannelOpts.FullMode,
                SingleWriter = DefaultChannelOpts.SingleWriter,
                SingleReader = DefaultChannelOpts.SingleReader
            };
        }

        return DefaultChannelOpts;
    }
}
