#region

using System.Text;
using Microsoft.Extensions.Logging;
using NATS.Client.Core;

#endregion

var subject = "foo.*";
var options = NatsOpts.Default with
{
    LoggerFactory = new MinimumConsoleLoggerFactory(LogLevel.Error)
};

Print("[CON] Connecting...\n");

await using var connection = new NatsConnection(options);

Print($"[SUB] Subscribing to subject '{subject}'...\n");

var sub = await connection.SubscribeAsync<byte[]>(subject);

await foreach (var msg in sub.Msgs.ReadAllAsync())
{
    var data = Encoding.UTF8.GetString(msg.Data!);
    Print($"[RCV] {msg.Subject}: {data}\n");
}

void Print(string message)
{
    Console.Write($"{DateTime.Now:HH:mm:ss} {message}");
}
