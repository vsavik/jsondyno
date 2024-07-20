using Jsondyno.Internal;

namespace Jsondyno.Dynamic;

/// <summary>
///   Represents a caching dynamic adapter to wrap primitive types.
/// </summary>
public sealed class PrimitiveAdapter : Adapter
{
    private object? _deserializedValue;

    private Type? _deserializedValueType;

    internal PrimitiveAdapter(IJsonValue value)
    {
        JsonValue = value;
    }

    private protected override IJsonValue JsonValue { get; }

    private protected override object? GetValue(Type targetType)
    {
        if (_deserializedValueType is not null &&
            _deserializedValueType == targetType)
        {
            return _deserializedValue;
        }

        _deserializedValue = base.GetValue(targetType);
        _deserializedValueType = targetType;

        return _deserializedValue;
    }
}