using Jsondyno.Dynamic;

namespace Jsondyno.Internal;

internal abstract class JsonNodeValue<TNode> : IJsonValue
    where TNode : JsonNode
{
    private readonly JsonSerializerOptions _options;

    private readonly TNode _node;

    protected JsonNodeValue(
        TNode node,
        JsonSerializerOptions options)
    {
        _node = node;
        _options = options;
    }

    [return: NotNullIfNotNull(nameof(node))]
    public static IJsonValue? Convert(JsonNode? node, JsonSerializerOptions options)
    {
        if (node is null)
        {
            return null;
        }

        switch (node.GetValueKind())
        {
            case JsonValueKind.Array:
                return new Array(node, options);

            case JsonValueKind.Object:
                return new Object(node, options);

            default:
                return new Primitive(node, options);
        }
    }

    public JsonNode ToJsonNode() => _node;

    public object? Deserialize(Type targetType) =>
        _node.Deserialize(targetType, _options);

    public abstract DynamicObject ToDynamic();

    public override string ToString() => _node.ToIntendedJsonString();

    private sealed class Primitive : JsonNodeValue<JsonValue>
    {
        public Primitive(JsonNode node, JsonSerializerOptions options)
            : base(node.AsValue(), options)
        {
        }

        public override DynamicObject ToDynamic() =>
            new PrimitiveAdapter(this);
    }

    private sealed class Array : JsonNodeValue<JsonArray>, IJsonArray
    {
        public Array(JsonNode node, JsonSerializerOptions options)
            : base(node.AsArray(), options)
        {
        }

        public int GetLength() => _node.Count;

        public IJsonValue? GetElement(int index) => Convert(_node[index], _options);

        public override DynamicObject ToDynamic() =>
            new ArrayAdapter(this);
    }

    private sealed class Object : JsonNodeValue<JsonObject>, IJsonObject
    {
        public Object(JsonNode node, JsonSerializerOptions options)
            : base(node.AsObject(), options)
        {
        }

        public IJsonValue? GetProperty(string key) => Convert(_node[key], _options);

        public override DynamicObject ToDynamic() =>
            new ObjectAdapter(this, _options.PropertyNamingPolicy);
    }
}