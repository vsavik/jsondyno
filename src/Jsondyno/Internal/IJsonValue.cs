namespace Jsondyno.Internal;

internal interface IJsonValue
{
    object? Deserialize(Type targetType);

    DynamicObject ToDynamic();

    JsonElement ToJsonElement();

    JsonNode ToJsonNode();
}