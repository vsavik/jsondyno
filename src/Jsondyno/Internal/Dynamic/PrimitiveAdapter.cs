using System.Diagnostics.CodeAnalysis;

namespace Jsondyno.Internal.Dynamic;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
internal sealed partial class PrimitiveAdapter : DynamicAdapter<IJsonValue>
{
    private object? _deserializedValue;

    private Type? _deserializedValueType;

    public PrimitiveAdapter(IJsonValue value, Context context)
        : base(value, context)
    {
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

    private T? GetValue<T>() where T : notnull
    {
        Type targetType = typeof(T);

        return (T?)GetValue(targetType);
    }
}