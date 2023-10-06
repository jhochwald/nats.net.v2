#region

using System.Runtime.CompilerServices;
using NATS.Client.Core.Commands;
using NATS.Client.Core.Internal;

#endregion

namespace NATS.Client.Core;

public partial class NatsConnection
{
    internal void PostDirectWrite(ICommand command)
    {
        if (ConnectionState == NatsConnectionState.Open)
        {
            EnqueueCommandSync(command);
        }
        else
        {
            WithConnect(command, static (self, command) =>
            {
                self.EnqueueCommandSync(command);
            });
        }
    }

    // DirectWrite is not supporting CancellationTimer
    internal void PostDirectWrite(string protocol, int repeatCount = 1)
    {
        if (ConnectionState == NatsConnectionState.Open)
        {
            EnqueueCommandSync(new DirectWriteCommand(protocol, repeatCount));
        }
        else
        {
            WithConnect(protocol, repeatCount, static (self, protocol, repeatCount) =>
            {
                self.EnqueueCommandSync(new DirectWriteCommand(protocol, repeatCount));
            });
        }
    }

    internal void PostDirectWrite(byte[] protocol)
    {
        if (ConnectionState == NatsConnectionState.Open)
        {
            EnqueueCommandSync(new DirectWriteCommand(protocol));
        }
        else
        {
            WithConnect(protocol, static (self, protocol) =>
            {
                self.EnqueueCommandSync(new DirectWriteCommand(protocol));
            });
        }
    }

    internal void PostDirectWrite(DirectWriteCommand command)
    {
        if (ConnectionState == NatsConnectionState.Open)
        {
            EnqueueCommandSync(command);
        }
        else
        {
            WithConnect(command, static (self, command) =>
            {
                self.EnqueueCommandSync(command);
            });
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal CancellationTimer GetCancellationTimer(CancellationToken cancellationToken, TimeSpan timeout = default)
    {
        if (timeout == default)
            timeout = Opts.CommandTimeout;
        return _cancellationTimerPool.Start(timeout, cancellationToken);
    }

    private async ValueTask EnqueueAndAwaitCommandAsync(IAsyncCommand command)
    {
        await EnqueueCommandAsync(command).ConfigureAwait(false);
        await command.AsValueTask().ConfigureAwait(false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool TryEnqueueCommand(ICommand command)
    {
        if (_commandWriter.TryWrite(command))
        {
            Interlocked.Increment(ref Counter.PendingMessages);
            return true;
        }

        return false;
    }
}
