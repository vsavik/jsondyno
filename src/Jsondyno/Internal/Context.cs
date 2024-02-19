using Jsondyno.Internal.Dynamic;

namespace Jsondyno.Internal;

internal sealed class Context
{
    private readonly JsonNamingPolicy _propertyPolicy;

    public Context(JsonSerializerOptions options)
    {
        Options = options;
        _propertyPolicy = options.PropertyNamingPolicy ?? NoopJsonNamingPolicy.Instance;
        ObjectKeyStrategy = options.PropertyNameCaseInsensitive
            ? CaseInsensitiveKeyStrategy.Instance
            : CaseSensitiveKeyStrategy.Instance;
    }

    public JsonSerializerOptions Options { get; }

    public IJsonObjectKeyStrategy ObjectKeyStrategy { get; }

    public PrimitiveAdapter CreatePrimitiveAdapter(IJsonValue primitive) =>
        new(primitive, Options);

    public ArrayAdapter CreateArrayAdapter(IJsonArray jsonArray) =>
        new(jsonArray, this);

    public ObjectAdapter CreateObjectAdapter(IJsonObject jsonObject) =>
        new(jsonObject, this);

    public string ConvertPropertyNameToKey(string propertyName) =>
        _propertyPolicy.ConvertName(propertyName);

    private sealed class CaseSensitiveKeyStrategy : IJsonObjectKeyStrategy
    {
        public StringComparer Comparer => StringComparer.Ordinal;

        public static IJsonObjectKeyStrategy Instance { get; } =
            new CaseSensitiveKeyStrategy();

        public IJsonValue? LoadJsonValue(IJsonObject jsonObject, string key) =>
            jsonObject.GetObjectPropertyCaseSensitive(key);
    }

    private sealed class CaseInsensitiveKeyStrategy : IJsonObjectKeyStrategy
    {
        public StringComparer Comparer => StringComparer.OrdinalIgnoreCase;

        public static IJsonObjectKeyStrategy Instance { get; } =
            new CaseInsensitiveKeyStrategy();

        public IJsonValue? LoadJsonValue(IJsonObject jsonObject, string key) =>
            jsonObject.GetObjectPropertyCaseInsensitive(key);
    }

    private sealed class NoopJsonNamingPolicy : JsonNamingPolicy
    {
        private NoopJsonNamingPolicy()
        {
        }

        public static JsonNamingPolicy Instance { get; } = new NoopJsonNamingPolicy();

        public override string ConvertName(string name) => name;
    }
}