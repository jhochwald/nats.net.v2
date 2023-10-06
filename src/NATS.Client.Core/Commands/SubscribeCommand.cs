#region

using NATS.Client.Core.Internal;

#endregion

namespace NATS.Client.Core.Commands;

internal sealed class AsyncSubscribeCommand : AsyncCommandBase<AsyncSubscribeCommand>
{
    private int? _maxMsgs;
    private string? _queueGroup;
    private int _sid;
    private string? _subject;

    private AsyncSubscribeCommand() { }

    public static AsyncSubscribeCommand Create(
        ObjectPool pool,
        CancellationTimer timer,
        int sid,
        string subject,
        string? queueGroup,
        int? maxMsgs
    )
    {
        if (!TryRent(pool, out var result))
        {
            result = new AsyncSubscribeCommand();
        }

        result._subject = subject;
        result._sid = sid;
        result._queueGroup = queueGroup;
        result._maxMsgs = maxMsgs;
        result.SetCancellationTimer(timer);

        return result;
    }

    public override void Write(ProtocolWriter writer) =>
        writer.WriteSubscribe(_sid, _subject!, _queueGroup, _maxMsgs);

    protected override void Reset()
    {
        _subject = default;
        _queueGroup = default;
        _sid = 0;
    }
}

internal sealed class AsyncSubscribeBatchCommand
    : AsyncCommandBase<AsyncSubscribeBatchCommand>,
        IBatchCommand
{
    private (int sid, string subject, string? queueGroup, int? maxMsgs)[]? _subscriptions;

    private AsyncSubscribeBatchCommand() { }

    public override void Write(ProtocolWriter writer) => (this as IBatchCommand).Write(writer);

    int IBatchCommand.Write(ProtocolWriter writer)
    {
        var i = 0;
        if (_subscriptions != null)
        {
            foreach (var (id, subject, queue, maxMsgs) in _subscriptions)
            {
                i++;
                writer.WriteSubscribe(id, subject, queue, maxMsgs);
            }
        }

        return i;
    }

    public static AsyncSubscribeBatchCommand Create(
        ObjectPool pool,
        CancellationTimer timer,
        (int sid, string subject, string? queueGroup, int? maxMsgs)[]? subscriptions
    )
    {
        if (!TryRent(pool, out var result))
        {
            result = new AsyncSubscribeBatchCommand();
        }

        result._subscriptions = subscriptions;
        result.SetCancellationTimer(timer);

        return result;
    }

    protected override void Reset() => _subscriptions = default;
}
