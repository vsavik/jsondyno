namespace Jsondyno.Internal.Dynamic;

partial class ArrayAdapter
{
    public static implicit operator JsonElement(ArrayAdapter adapter) =>
        adapter._value.ToJsonElement();

    public static implicit operator JsonNode(ArrayAdapter adapter) =>
        adapter._value.ToJsonNode();

    public static implicit operator JsonArray(ArrayAdapter adapter) =>
        adapter._value.ToJsonNode().AsArray();
}