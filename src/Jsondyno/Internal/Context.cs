using Jsondyno.Internal.Dynamic;

namespace Jsondyno.Internal;

internal sealed class Context
{
    private readonly JsonNamingPolicy _propertyPolicy;

    public Context(JsonSerializerOptions options)
    {
        Options = options;
        _propertyPolicy = options.PropertyNamingPolicy ?? NoopJsonNamingPolicy.Instance;
        ObjectKeyComparer = options.PropertyNameCaseInsensitive
            ? StringComparer.OrdinalIgnoreCase
            : StringComparer.Ordinal;
    }

    public JsonSerializerOptions Options { get; }

    public StringComparer ObjectKeyComparer { get; }

    public PrimitiveAdapter CreatePrimitiveAdapter(IJsonValue primitive) =>
        new(primitive, Options);

    public ArrayAdapter CreateArrayAdapter(IJsonArray jsonArray) =>
        new(jsonArray, this);

    public ObjectAdapter CreateObjectAdapter(IJsonObject jsonObject) =>
        new(jsonObject, this);

    public string ConvertPropertyNameToKey(string propertyName) =>
        _propertyPolicy.ConvertName(propertyName);

    private sealed class NoopJsonNamingPolicy : JsonNamingPolicy
    {
        private NoopJsonNamingPolicy()
        {
        }

        public static JsonNamingPolicy Instance { get; } = new NoopJsonNamingPolicy();

        public override string ConvertName(string name) => name;
    }
}