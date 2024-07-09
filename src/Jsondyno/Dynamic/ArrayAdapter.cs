using Jsondyno.Internal;

namespace Jsondyno.Dynamic;

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

    public int Length => GetLength();

    public int Count => GetLength();

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