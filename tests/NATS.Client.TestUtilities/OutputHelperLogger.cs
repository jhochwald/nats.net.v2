#region

using Microsoft.Extensions.Logging;

#endregion

namespace NATS.Client.Core.Tests;

public class OutputHelperLoggerFactory : ILoggerFactory
{
    private readonly NatsServer _natsServer;
    private readonly ITestOutputHelper _testOutputHelper;

    public OutputHelperLoggerFactory(ITestOutputHelper testOutputHelper, NatsServer natsServer)
    {
        _testOutputHelper = testOutputHelper;
        _natsServer = natsServer;
    }

    public void AddProvider(ILoggerProvider provider) { }

    public ILogger CreateLogger(string categoryName) =>
        new Logger(categoryName, _testOutputHelper, _natsServer);

    public void Dispose() { }

    private class Logger : ILogger
    {
        private readonly string _categoryName;
        private readonly NatsServer _natsServer;
        private readonly ITestOutputHelper _testOutputHelper;

        public Logger(
            string categoryName,
            ITestOutputHelper testOutputHelper,
            NatsServer natsServer
        )
        {
            _categoryName = categoryName;
            _testOutputHelper = testOutputHelper;
            _natsServer = natsServer;
        }

        public IDisposable BeginScope<TState>(TState state) => NullDisposable.Instance;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter
        )
        {
            try
            {
                var text = formatter(state, exception);
                _testOutputHelper.WriteLine(
                    $"[NCLOG] {DateTime.Now:HH:mm:ss.fff} {logLevel}: {text}"
                );
                if (exception != null)
                {
                    _testOutputHelper.WriteLine(
                        $"[NCLOG] {DateTime.Now:HH:mm:ss.fff} Exception: {exception}"
                    );
                }

                _natsServer.LogMessage(_categoryName, logLevel, eventId, exception, text, state);
            }
            catch { }
        }
    }

    private class NullDisposable : IDisposable
    {
        public static readonly IDisposable Instance = new NullDisposable();

        private NullDisposable() { }

        public void Dispose() { }
    }
}
