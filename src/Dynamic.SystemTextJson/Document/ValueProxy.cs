namespace Dynamic.SystemTextJson.Document;

internal sealed partial class ValueProxy : DocumentProxy
{
    private delegate T LoadValueDelegate<out T>(in JsonElement element);

    private object? _cachedValue;

    public ValueProxy(in JsonElement element, JsonSerializerOptions options)
        : base(in element, options)
    {
    }

    private T GetValue<T>(LoadValueDelegate<T> loadFunc)
    {
        if (_cachedValue is not null && _cachedValue is T value)
        {
            return value;
        }

        value = loadFunc(in Element);
        _cachedValue = value;

        return value;
    }
}