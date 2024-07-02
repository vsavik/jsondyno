namespace Jsondyno.Internal.Dynamic;

public sealed partial class ArrayAdapter : DynamicObject
{
    private readonly IJsonArray _value;

    private int? _length;

    private int _lastItemUsedIndex = -1;

    private object? _lastItemUsed;

    internal ArrayAdapter(IJsonArray value)
    {
        _value = value;
    }

    public int Length => GetLength();

    public int Count => GetLength();

    private int GetLength()
    {
        _length ??= _value.GetLength();

        return _length.Value;
    }

    public object? this[int index] => GetElementByIndex(index);

    private object? GetElementByIndex(int index)
    {
        if (_lastItemUsedIndex != index)
        {
            _lastItemUsed = _value.GetElement(index)?.ToDynamic();
            _lastItemUsedIndex = index;
        }

        return _lastItemUsed;
    }

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = _value.Deserialize(binder.ReturnType);

        return true;
    }

    public override string ToString() => _value.ToString()!;
}