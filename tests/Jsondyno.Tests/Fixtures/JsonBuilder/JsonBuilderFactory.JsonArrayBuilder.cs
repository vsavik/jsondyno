namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal static partial class JsonBuilderFactory
{
    private sealed class JsonArrayBuilder<TParent> :
        JsonBaseBuilder<TParent>,
        IArrayBuilder<TParent>
        where TParent : class
    {
        public JsonArrayBuilder(TParent parent, Utf8JsonWriter writer)
            : base(parent, writer)
        {
            JsonWriter.WriteStartArray();
        }

        public TParent ArrayEnd()
        {
            JsonWriter.WriteEndArray();

            return Parent;
        }

        public IArrayBuilder<IArrayBuilder<TParent>> ArrayStart() =>
            new JsonArrayBuilder<IArrayBuilder<TParent>>(this, JsonWriter);

        public IObjectBuilder<IArrayBuilder<TParent>> ObjectStart() =>
            new JsonObjectBuilder<IArrayBuilder<TParent>>(this, JsonWriter);
    }
}