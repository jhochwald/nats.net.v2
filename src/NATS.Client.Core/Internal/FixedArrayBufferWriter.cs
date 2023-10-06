#region

using System.Runtime.CompilerServices;

#endregion

namespace NATS.Client.Core.Internal;

// similar as ArrayBufferWriter but adds more functional for ProtocolWriter
internal sealed class FixedArrayBufferWriter : ICountableBufferWriter
{
    private byte[] _buffer;

    public FixedArrayBufferWriter(int capacity = 65535)
    {
        _buffer = new byte[capacity];
        WrittenCount = 0;
    }

    public ReadOnlyMemory<byte> WrittenMemory => _buffer.AsMemory(0, WrittenCount);

    public ReadOnlySpan<byte> WrittenSpan => _buffer.AsSpan(0, WrittenCount);

    public int WrittenCount { get; private set; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Advance(int count) => WrittenCount += count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Memory<byte> GetMemory(int sizeHint = 0)
    {
        if (_buffer.Length - WrittenCount < sizeHint)
        {
            Resize(sizeHint);
        }

        return _buffer.AsMemory(WrittenCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> GetSpan(int sizeHint = 0)
    {
        if (_buffer.Length - WrittenCount < sizeHint)
        {
            Resize(sizeHint);
        }

        return _buffer.AsSpan(WrittenCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Range PreAllocate(int size)
    {
        var range = new Range(WrittenCount, WrittenCount + size);
        Advance(size);
        return range;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> GetSpanInPreAllocated(Range range) => _buffer.AsSpan(range);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset() => WrittenCount = 0;

    private void Resize(int sizeHint) => Array.Resize(ref _buffer, Math.Max(sizeHint, _buffer.Length * 2));
}
