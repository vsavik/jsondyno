using Jsondyno.Internal;

namespace Jsondyno.Dynamic;

/// <summary>
///   Represents a dynamic adapter to wrap JSON arrays.
/// </summary>
public sealed class ArrayAdapter : Adapter
{
    private readonly IJsonArray _value;

    private int? _length;

    private int _lastItemUsedIndex = -1;

    private object? _lastItemUsed;

    internal ArrayAdapter(IJsonArray value)
    {
        _value = value;
    }

    private protected override IJsonValue JsonValue => _value;

    /// <summary>
    ///   Gets the size of underlying JSON array.
    ///   The <see cref="Count"/> property is an alias of <see cref="Length"/>.
    /// </summary>
    public int Length => GetLength();

    /// <summary>
    ///   Gets the size of underlying JSON array.
    ///   This is an alias of <see cref="Length"/> property.
    /// </summary>
    public int Count => GetLength();

    /// <summary>
    ///   Gets the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get.</param>
    public object? this[int index] => GetElementByIndex(index);

    private int GetLength() => _length ??= _value.GetLength();

    private object? GetElementByIndex(int index)
    {
        if (_lastItemUsedIndex != index)
        {
            _lastItemUsed = _value.GetElement(index)?.ToDynamic();
            _lastItemUsedIndex = index;
        }

        return _lastItemUsed;
    }
}