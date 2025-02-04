#region

using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

#endregion

namespace NATS.Client.Core.Internal;

internal sealed class ThreadPoolWorkItem<T> : IThreadPoolWorkItem
{
    private static readonly ConcurrentQueue<ThreadPoolWorkItem<T>> Pool = new();

    private Action<T?>? _continuation;

    private ILoggerFactory? _loggerFactory;

    private ThreadPoolWorkItem<T>? _nextNode;
    private T? _value;

    private ThreadPoolWorkItem() { }

    public ref ThreadPoolWorkItem<T>? NextNode => ref _nextNode;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Execute()
    {
        var call = _continuation;
        var v = _value;
        var factory = _loggerFactory;
        _continuation = null;
        _value = default;
        _loggerFactory = null;
        if (call != null)
        {
            Pool.Enqueue(this);

            try
            {
                call.Invoke(v);
            }
            catch (Exception ex)
            {
                if (_loggerFactory != null)
                {
                    _loggerFactory
                        .CreateLogger<ThreadPoolWorkItem<T>>()
                        .LogError(ex, "Error occured during execute callback on ThreadPool.");
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ThreadPoolWorkItem<T> Create(
        Action<T?> continuation,
        T? value,
        ILoggerFactory loggerFactory
    )
    {
        if (!Pool.TryDequeue(out var item))
        {
            item = new ThreadPoolWorkItem<T>();
        }

        item._continuation = continuation;
        item._value = value;
        item._loggerFactory = loggerFactory;

        return item;
    }
}
