namespace Jsondyno.Internal;

internal interface IJsonValue
{
    object? Deserialize(Type targetType);

    DynamicObject ToDynamic();

    string ToString();

    JsonElement ToJsonElement() => (JsonElement)Deserialize(typeof(JsonElement))!;

    JsonNode ToJsonNode() => (JsonNode)Deserialize(typeof(JsonNode))!;
}