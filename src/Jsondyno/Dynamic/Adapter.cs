using Jsondyno.Internal;

namespace Jsondyno.Dynamic;

/// <summary>
///   Contains shared functionality for types conversion.
/// </summary>
public abstract partial class Adapter : DynamicObject
{
    private protected abstract IJsonValue JsonValue { get; }

    /// <inheritdoc />
    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = GetValue(binder.ReturnType);

        return true;
    }

    private protected virtual object? GetValue(Type targetType) =>
        JsonValue.Deserialize(targetType);

    private T? GetValue<T>() => (T?)GetValue(typeof(T));

    /// <inheritdoc />
    public override string ToString() => JsonValue.ToString();
}