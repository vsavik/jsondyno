using Jsondyno.Internal;

namespace Jsondyno.Dynamic;

public abstract partial class Adapter : DynamicObject
{
    private protected abstract IJsonValue JsonValue { get; }

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = GetValue(binder.ReturnType);

        return true;
    }

    protected virtual object? GetValue(Type targetType) =>
        JsonValue.Deserialize(targetType);

    private T? GetValue<T>() => (T?)GetValue(typeof(T));

    public override string ToString() => JsonValue.ToString();
}