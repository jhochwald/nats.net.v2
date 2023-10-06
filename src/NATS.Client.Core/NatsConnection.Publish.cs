namespace NATS.Client.Core;

public partial class NatsConnection
{
    /// <inheritdoc />
    public ValueTask PublishAsync(string subject, NatsHeaders? headers = default, string? replyTo = default, NatsPubOpts? opts = default, CancellationToken cancellationToken = default)
    {
        if (opts?.WaitUntilSent ?? false)
        {
            return PubAsync(subject, replyTo, default, headers, cancellationToken);
        }

        return PubPostAsync(subject, replyTo, default, headers, cancellationToken);
    }

    /// <inheritdoc />
    public ValueTask PublishAsync<T>(string subject, T? data, NatsHeaders? headers = default, string? replyTo = default, NatsPubOpts? opts = default, CancellationToken cancellationToken = default)
    {
        var serializer = opts?.Serializer ?? Opts.Serializer;
        if (opts?.WaitUntilSent ?? false)
        {
            return PubModelAsync(subject, data, serializer, replyTo, headers, cancellationToken);
        }

        return PubModelPostAsync(subject, data, serializer, replyTo, headers, opts?.ErrorHandler, cancellationToken);
    }

    /// <inheritdoc />
    public ValueTask PublishAsync<T>(in NatsMsg<T> msg, NatsPubOpts? opts = default, CancellationToken cancellationToken = default) => PublishAsync(msg.Subject, msg.Data, msg.Headers, msg.ReplyTo, opts, cancellationToken);
}
