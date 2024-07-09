using Jsondyno.Dynamic;

namespace Jsondyno.Internal;

internal sealed class JsonElementValue : IJsonArray, IJsonObject
{
    private readonly JsonElement _element;

    private readonly JsonSerializerOptions _options;

    private readonly GetPropertyDelegate _propertyDelegate;

    private JsonElementValue(
        in JsonElement element,
        JsonSerializerOptions options,
        GetPropertyDelegate propertyDelegate)
    {
        _element = element;
        _propertyDelegate = propertyDelegate;
        _options = options;
    }

    public JsonElement ToJsonElement() => _element;

    public object? Deserialize(Type targetType) =>
        _element.Deserialize(targetType, _options);

    public DynamicObject ToDynamic()
    {
        switch (_element.ValueKind)
        {
            case JsonValueKind.Array:
                return new ArrayAdapter(this);

            case JsonValueKind.Object:
                return new ObjectAdapter(this, _options.PropertyNamingPolicy);

            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.String:
            case JsonValueKind.Number:
                return new PrimitiveAdapter(this);
        }

        throw new NotSupportedException(SR.UnknownValueKind(_element.ValueKind));
    }

    public int GetLength() => _element.GetArrayLength();

    public IJsonValue? GetElement(int index) => Convert(_element[index]);

    public IJsonValue? GetProperty(string key) => _propertyDelegate(this, key);

    private JsonElementValue? Convert(in JsonElement element) =>
        element.ValueKind is JsonValueKind.Undefined or JsonValueKind.Null
            ? null
            : new(element, _options, _propertyDelegate);

    public override string ToString() => _element.ToIntendedJsonString();

    public static JsonElementValue Create(in JsonElement element, JsonSerializerOptions options) => new(
        in element,
        options,
        options.PropertyNameCaseInsensitive ? GetPropertyCaseInsensitive : GetPropertyCaseSensitive);

    private static IJsonValue? GetPropertyCaseSensitive(JsonElementValue value, string key) =>
        value._element.TryGetProperty(key, out JsonElement propertyValue)
            ? value.Convert(propertyValue)
            : null;

    private static IJsonValue? GetPropertyCaseInsensitive(JsonElementValue value, string key)
    {
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
        foreach (JsonProperty property in value._element.EnumerateObject())
        {
            if (comparer.Equals(key, property.Name))
            {
                return value.Convert(property.Value);
            }
        }

        return null;
    }

    private delegate IJsonValue? GetPropertyDelegate(JsonElementValue value, string key);
}