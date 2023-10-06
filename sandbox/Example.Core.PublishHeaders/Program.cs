#region

using Microsoft.Extensions.Logging;
using NATS.Client.Core;

#endregion

var subject = "bar.xyz";
var options = NatsOpts.Default with { LoggerFactory = new MinimumConsoleLoggerFactory(LogLevel.Error) };

Print("[CON] Connecting...\n");

await using var connection = new NatsConnection(options);

for (var i = 0; i < 10; i++)
{
    Print($"[PUB] Publishing to subject ({i}) '{subject}'...\n");
    await connection.PublishAsync(
        subject,
        new Bar { Id = i, Name = "Baz" },
        new NatsHeaders { ["XFoo"] = $"bar{i}" });
}

void Print(string message)
{
    Console.Write($"{DateTime.Now:HH:mm:ss} {message}");
}

public record Bar
{
    public int Id { get; set; }

    public string? Name { get; set; }
}
