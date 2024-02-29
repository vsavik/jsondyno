using System.Text;

namespace Jsondyno.Internal.Serialization;

internal sealed class JsonElementValue : IJsonArray, IJsonObject
{
    private readonly JsonElement _element;

    public JsonElementValue(in JsonElement element)
    {
        _element = element;
    }

    public object? Deserialize(Type targetType, JsonSerializerOptions options) =>
        _element.Deserialize(targetType, options);

    public object ToDynamic(Context context)
    {
        switch (_element.ValueKind)
        {
            case JsonValueKind.Array:
                return context.CreateArrayAdapter(this);

            case JsonValueKind.Object:
                return context.CreateObjectAdapter(this);

            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.String:
            case JsonValueKind.Number:
                return context.CreatePrimitiveAdapter(this);
        }

        throw new NotSupportedException(SR.UnknownValueKind(_element.ValueKind));
    }

    public int GetLength() => _element.GetArrayLength();

    public IJsonValue? GetArrayElement(int index) => Convert(_element[index]);

    public IJsonValue? GetObjectProperty(string key) =>
        _element.TryGetProperty(key, out JsonElement propertyValue)
            ? Convert(propertyValue)
            : null;

    public IJsonValue? GetObjectProperty(string key, StringComparer comparer)
    {
        foreach (JsonProperty property in _element.EnumerateObject())
        {
            if (comparer.Equals(key, property.Name))
            {
                return Convert(property.Value);
            }
        }

        return null;
    }

    private static JsonElementValue? Convert(in JsonElement element) =>
        element.ValueKind is JsonValueKind.Undefined or JsonValueKind.Null
            ? null
            : new(element);

    public override string ToString() => _element.ToIntendedJsonString();
}