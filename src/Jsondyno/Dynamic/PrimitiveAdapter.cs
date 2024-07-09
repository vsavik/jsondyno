using Jsondyno.Internal;

namespace Jsondyno.Dynamic;

public sealed class PrimitiveAdapter : Adapter
{
    private readonly IJsonValue _value;

    private object? _deserializedValue;

    private Type? _deserializedValueType;

    internal PrimitiveAdapter(IJsonValue value)
    {
        _value = value;
    }

    private protected override IJsonValue JsonValue => _value;

    protected override object? GetValue(Type targetType)
    {
        if (_deserializedValueType is not null &&
            _deserializedValueType == targetType)
        {
            return _deserializedValue;
        }

        _deserializedValue = _value.Deserialize(targetType);
        _deserializedValueType = targetType;

        return _deserializedValue;
    }
}