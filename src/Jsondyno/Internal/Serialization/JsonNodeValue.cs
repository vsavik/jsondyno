namespace Jsondyno.Internal.Serialization;

internal abstract class JsonNodeValue<TNode> : IJsonValue
    where TNode : JsonNode
{
    private readonly TNode _node;

    protected JsonNodeValue(TNode node)
    {
        _node = node;
    }

    public static IJsonValue? Convert(JsonNode? node)
    {
        if (node is null)
        {
            return null;
        }

        switch (node.GetValueKind())
        {
            case JsonValueKind.Array:
                return new Array(node);

            case JsonValueKind.Object:
                return new Object(node);

            default:
                return new Primitive(node);
        }
    }

    public object? Deserialize(Type targetType, JsonSerializerOptions options) =>
        _node.Deserialize(targetType, options);

    public abstract object ToDynamic(Context context);

    public override string ToString() => _node.ToIntendedJsonString();

    private sealed class Primitive : JsonNodeValue<JsonValue>
    {
        public Primitive(JsonNode node)
            : base(node.AsValue())
        {
        }

        public override object ToDynamic(Context context) =>
            context.CreatePrimitiveAdapter(this);
    }

    private sealed class Array : JsonNodeValue<JsonArray>, IJsonArray
    {
        public Array(JsonNode node)
            : base(node.AsArray())
        {
        }

        public int GetLength() => _node.Count;

        public IJsonValue? GetArrayElement(int index) => Convert(_node[index]);

        public override object ToDynamic(Context context) =>
            context.CreateArrayAdapter(this);
    }

    private sealed class Object : JsonNodeValue<JsonObject>, IJsonObject
    {
        public Object(JsonNode node)
            : base(node.AsObject())
        {
        }

        public IJsonValue? GetObjectProperty(string key) => Convert(_node[key]);

        public override object ToDynamic(Context context) =>
            context.CreateObjectAdapter(this);
    }
}