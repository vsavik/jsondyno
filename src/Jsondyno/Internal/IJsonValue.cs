namespace Jsondyno.Internal;

internal interface IJsonValue
{
    object? Deserialize(Type targetType, JsonSerializerOptions options);

    object ToDynamic(Context context);

    JsonElement ToJsonElement(JsonSerializerOptions options);

    JsonNode ToJsonNode(JsonSerializerOptions options);
}