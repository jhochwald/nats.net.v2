﻿namespace AlterNats.Commands;

internal sealed class UnsubscribeCommand : CommandBase<UnsubscribeCommand>
{
    int subscriptionId;

    UnsubscribeCommand()
    {
    }

    public static UnsubscribeCommand Create(int subscriptionId)
    {
        if (!pool.TryPop(out var result))
        {
            result = new UnsubscribeCommand();
        }

        result.subscriptionId = subscriptionId;

        return result;
    }

    public override string WriteTraceMessage => "Write UNSUB Command to buffer.";

    public override void Write(ProtocolWriter writer)
    {
        writer.WriteUnsubscribe(subscriptionId, null);
    }

    public override void Return()
    {
        subscriptionId = 0;
        base.Return();
    }
}