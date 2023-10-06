#region

using System.Buffers;
using NATS.Client.Core.Internal;

#endregion

namespace NATS.Client.Core.Commands;

internal sealed class PublishCommand<T> : CommandBase<PublishCommand<T>>
{
    private CancellationToken _cancellationToken;
    private Action<Exception>? _errorHandler;
    private NatsHeaders? _headers;
    private string? _replyTo;
    private INatsSerializer? _serializer;
    private string? _subject;
    private T? _value;

    private PublishCommand()
    {
    }

    public override bool IsCanceled => _cancellationToken.IsCancellationRequested;

    public static PublishCommand<T> Create(ObjectPool pool, string subject, string? replyTo, NatsHeaders? headers, T? value, INatsSerializer serializer, Action<Exception>? errorHandler, CancellationToken cancellationToken)
    {
        if (!TryRent(pool, out var result))
        {
            result = new PublishCommand<T>();
        }

        result._subject = subject;
        result._replyTo = replyTo;
        result._headers = headers;
        result._value = value;
        result._serializer = serializer;
        result._errorHandler = errorHandler;
        result._cancellationToken = cancellationToken;

        return result;
    }

    public override void Write(ProtocolWriter writer)
    {
        try
        {
            writer.WritePublish(_subject!, _replyTo, _headers, _value, _serializer!);
        }
        catch (Exception e)
        {
            if (_errorHandler is { } errorHandler)
            {
                ThreadPool.UnsafeQueueUserWorkItem(
                    state =>
                    {
                        try
                        {
                            state.handler(state.exception);
                        }
                        catch
                        {
                            // ignore
                        }
                    },
                    (handler: errorHandler, exception: e),
                    false);
            }

            throw;
        }
    }

    protected override void Reset()
    {
        _subject = default;
        _headers = default;
        _value = default;
        _serializer = null;
        _errorHandler = default;
        _cancellationToken = default;
    }
}

internal sealed class PublishBytesCommand : CommandBase<PublishBytesCommand>
{
    private CancellationToken _cancellationToken;
    private NatsHeaders? _headers;
    private ReadOnlySequence<byte> _payload;
    private string? _replyTo;
    private string? _subject;

    private PublishBytesCommand()
    {
    }

    public override bool IsCanceled => _cancellationToken.IsCancellationRequested;

    public static PublishBytesCommand Create(ObjectPool pool, string subject, string? replyTo, NatsHeaders? headers, ReadOnlySequence<byte> payload, CancellationToken cancellationToken)
    {
        if (!TryRent(pool, out var result))
        {
            result = new PublishBytesCommand();
        }

        result._subject = subject;
        result._replyTo = replyTo;
        result._headers = headers;
        result._payload = payload;
        result._cancellationToken = cancellationToken;

        return result;
    }

    public override void Write(ProtocolWriter writer) => writer.WritePublish(_subject!, _replyTo, _headers, _payload);

    protected override void Reset()
    {
        _subject = default;
        _replyTo = default;
        _headers = default;
        _payload = default;
        _cancellationToken = default;
    }
}

internal sealed class AsyncPublishCommand<T> : AsyncCommandBase<AsyncPublishCommand<T>>
{
    private NatsHeaders? _headers;
    private string? _replyTo;
    private INatsSerializer? _serializer;
    private string? _subject;
    private T? _value;

    private AsyncPublishCommand()
    {
    }

    public static AsyncPublishCommand<T> Create(ObjectPool pool, CancellationTimer timer, string subject, string? replyTo, NatsHeaders? headers, T? value, INatsSerializer serializer)
    {
        if (!TryRent(pool, out var result))
        {
            result = new AsyncPublishCommand<T>();
        }

        result._subject = subject;
        result._replyTo = replyTo;
        result._headers = headers;
        result._value = value;
        result._serializer = serializer;
        result.SetCancellationTimer(timer);

        return result;
    }

    public override void Write(ProtocolWriter writer) => writer.WritePublish(_subject!, _replyTo, _headers, _value, _serializer!);

    protected override void Reset()
    {
        _subject = default;
        _headers = default;
        _value = default;
        _serializer = null;
    }
}

internal sealed class AsyncPublishBytesCommand : AsyncCommandBase<AsyncPublishBytesCommand>
{
    private NatsHeaders? _headers;
    private ReadOnlySequence<byte> _payload;
    private string? _replyTo;
    private string? _subject;

    private AsyncPublishBytesCommand()
    {
    }

    public static AsyncPublishBytesCommand Create(ObjectPool pool, CancellationTimer timer, string subject, string? replyTo, NatsHeaders? headers, ReadOnlySequence<byte> payload)
    {
        if (!TryRent(pool, out var result))
        {
            result = new AsyncPublishBytesCommand();
        }

        result._subject = subject;
        result._replyTo = replyTo;
        result._headers = headers;
        result._payload = payload;
        result.SetCancellationTimer(timer);

        return result;
    }

    public override void Write(ProtocolWriter writer) => writer.WritePublish(_subject!, _replyTo, _headers, _payload);

    protected override void Reset()
    {
        _subject = default;
        _replyTo = default;
        _headers = default;
        _payload = default;
    }
}
