using System.Diagnostics.CodeAnalysis;

namespace Jsondyno.Internal.Dynamic;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
internal sealed class ArrayAdapter : DynamicObject
{
    private readonly IJsonArray _value;

    private readonly Context _context;

    private readonly int _length;

    private int _lastItemUsedIndex = -1;

    private object? _lastItemUsed;

    public ArrayAdapter(IJsonArray value, Context context)
    {
        _value = value;
        _context = context;
        _length = value.GetLength();
    }

    public int Length => _length;

    public int Count => _length;

    public object? this[int index] => GetElementByIndex(index);

    private object? GetElementByIndex(int index)
    {
        if (_lastItemUsedIndex != index)
        {
            _lastItemUsed = _value.GetArrayElement(index)?.ToDynamic(_context);
            _lastItemUsedIndex = index;
        }

        return _lastItemUsed;
    }

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = _value.Deserialize(binder.ReturnType, _context.Options);

        return true;
    }
}