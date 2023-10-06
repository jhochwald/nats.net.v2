#region

using NATS.Client.Core.Commands;

#endregion

namespace NATS.Client.Core;

public partial class NatsConnection
{
    /// <inheritdoc />
    public ValueTask<TimeSpan> PingAsync(CancellationToken cancellationToken = default)
    {
        if (ConnectionState == NatsConnectionState.Open)
        {
            var command = AsyncPingCommand.Create(this, ObjectPool, GetCancellationTimer(cancellationToken));
            if (TryEnqueueCommand(command))
            {
                return command.AsValueTask();
            }

            return EnqueueAndAwaitCommandAsync(command);
        }

        return WithConnectAsync(cancellationToken, static (self, token) =>
        {
            var command = AsyncPingCommand.Create(self, self.ObjectPool, self.GetCancellationTimer(token));
            return self.EnqueueAndAwaitCommandAsync(command);
        });
    }

    /// <summary>
    ///     Send PING command to writers channel waiting on the chanel if necessary.
    ///     This is to make sure the PING time window is not missed in case the writer
    ///     channel is full with other commands and we will wait to enqueue rather than
    ///     just trying which might not happen in time on a busy channel.
    /// </summary>
    /// <param name="cancellationToken">Cancels the Ping command</param>
    /// <returns><see cref="ValueTask" /> representing the asynchronous operation</returns>
    private ValueTask PingOnlyAsync(CancellationToken cancellationToken = default)
    {
        if (ConnectionState == NatsConnectionState.Open)
        {
            return EnqueueCommandAsync(PingCommand.Create(ObjectPool, GetCancellationTimer(cancellationToken)));
        }

        return ValueTask.CompletedTask;
    }
}
