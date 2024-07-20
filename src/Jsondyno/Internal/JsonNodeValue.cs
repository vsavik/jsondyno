using Jsondyno.Dynamic;

namespace Jsondyno.Internal;

internal abstract class JsonNodeValue<TNode> : IJsonValue
    where TNode : JsonNode
{
    private readonly JsonSerializerOptions _options;

    private readonly TNode _node;

    private JsonNodeValue(
        TNode node,
        JsonSerializerOptions options)
    {
        _node = node;
        _options = options;
    }

    [return: NotNullIfNotNull(nameof(node))]
    public static IJsonValue? Convert(JsonNode? node, JsonSerializerOptions options) => node switch
    {
        JsonValue jsonValue => new Primitive(jsonValue, options),
        JsonArray jsonArray => new Array(jsonArray, options),
        JsonObject jsonObject => new Object(jsonObject, options),
        null => null,
        _ => throw new InvalidOperationException(SR.UnknownNodeType(node))
    };

    public JsonNode ToJsonNode() => _node;

    public object? Deserialize(Type targetType) =>
        _node.Deserialize(targetType, _options);

    public abstract DynamicObject ToDynamic();

    public override string ToString() => _node.ToIntendedJsonString();

    private sealed class Primitive : JsonNodeValue<JsonValue>
    {
        public Primitive(JsonValue node, JsonSerializerOptions options)
            : base(node, options)
        {
        }

        public override DynamicObject ToDynamic() =>
            new PrimitiveAdapter(this);
    }

    private sealed class Array : JsonNodeValue<JsonArray>, IJsonArray
    {
        public Array(JsonArray node, JsonSerializerOptions options)
            : base(node, options)
        {
        }

        public int GetLength() => _node.Count;

        public IJsonValue? GetElement(int index) => Convert(_node[index], _options);

        public override DynamicObject ToDynamic() =>
            new ArrayAdapter(this);
    }

    private sealed class Object : JsonNodeValue<JsonObject>, IJsonObject
    {
        public Object(JsonObject node, JsonSerializerOptions options)
            : base(node, options)
        {
        }

        public IJsonValue? GetProperty(string key) => Convert(_node[key], _options);

        public override DynamicObject ToDynamic() =>
            new ObjectAdapter(this, _options.PropertyNamingPolicy);
    }
}