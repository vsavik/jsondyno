namespace Jsondyno.Internal.Dynamic;

partial class DynamicAdapter<TJsonValue>
{
    public static implicit operator JsonElement(DynamicAdapter<TJsonValue> adapter) =>
        adapter._value.ToJsonElement(adapter._context.Options);

    public static implicit operator JsonNode(DynamicAdapter<TJsonValue> adapter) =>
        adapter._value.ToJsonNode(adapter._context.Options);

    public static implicit operator JsonValue(DynamicAdapter<TJsonValue> adapter) =>
        adapter._value.ToJsonNode(adapter._context.Options).AsValue();

    public static implicit operator JsonArray(DynamicAdapter<TJsonValue> adapter) =>
        adapter._value.ToJsonNode(adapter._context.Options).AsArray();

    public static implicit operator JsonObject(DynamicAdapter<TJsonValue> adapter) =>
        adapter._value.ToJsonNode(adapter._context.Options).AsObject();
}