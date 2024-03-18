namespace Jsondyno.Internal.Dynamic;

partial class ObjectAdapter
{
    public static implicit operator JsonElement(ObjectAdapter adapter) =>
        adapter._value.ToJsonElement(adapter._context.Options);

    public static implicit operator JsonNode(ObjectAdapter adapter) =>
        adapter._value.ToJsonNode(adapter._context.Options);    

    public static implicit operator JsonObject(ObjectAdapter adapter) =>
        adapter._value.ToJsonNode(adapter._context.Options).AsObject();
}