namespace Dynamic.SystemTextJson.Document;

internal sealed class ValueProxy : DocumentProxy
{
    private delegate T LoadValue<out T>(in JsonElement element);

    private object? _cachedValue;

    public ValueProxy(in JsonElement element, JsonSerializerOptions options)
        : base(in element, options)
    {
    }

    private T GetValue<T>(LoadValue<T> loadFunc)
    {
        if (_cachedValue is not null && _cachedValue is T value)
        {
            return value;
        }

        value = loadFunc(in Element);
        _cachedValue = value;

        return value;
    }

    public static implicit operator string?(ValueProxy proxy) =>
        proxy.GetValue(Functions.LoadString);

    private static class Functions
    {
        public static LoadValue<string?> LoadString { get; } =
            static (in JsonElement element) => element.GetString();
    }
}