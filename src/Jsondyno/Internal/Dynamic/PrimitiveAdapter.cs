namespace Jsondyno.Internal.Dynamic;

public sealed partial class PrimitiveAdapter : DynamicObject
{
    private readonly IJsonValue _value;

    private readonly Context _context;

    private object? _deserializedValue;

    private Type? _deserializedValueType;

    internal PrimitiveAdapter(IJsonValue value, Context context)
    {
        _value = value;
        _context = context;
    }

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = GetValue(binder.ReturnType);

        return true;
    }

    private object? GetValue(Type targetType)
    {
        if (_deserializedValueType is not null &&
            _deserializedValueType == targetType)
        {
            return _deserializedValue;
        }

        _deserializedValue = _value.Deserialize(targetType, _context.Options);
        _deserializedValueType = targetType;

        return _deserializedValue;
    }

    private T? GetValue<T>()
    {
        Type targetType = typeof(T);

        return (T?)GetValue(targetType);
    }

    public override string ToString() => _value.ToString()!;
}