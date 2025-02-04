namespace NATS.Client.Core;

public readonly record struct NatsStats(
    long SentBytes,
    long ReceivedBytes,
    long PendingMessages,
    long SentMessages,
    long ReceivedMessages,
    long SubscriptionCount
);

internal sealed class ConnectionStatsCounter
{
    public NatsStats ToStats() =>
        new(
            SentBytes,
            ReceivedBytes,
            PendingMessages,
            SentMessages,
            ReceivedMessages,
            SubscriptionCount
        );
    // for operate Interlocked.Increment/Decrement/Add, expose field as public
#pragma warning disable SA1401
    public long SentBytes;
    public long SentMessages;
    public long PendingMessages;
    public long ReceivedBytes;
    public long ReceivedMessages;
    public long SubscriptionCount;
#pragma warning restore SA1401
}
