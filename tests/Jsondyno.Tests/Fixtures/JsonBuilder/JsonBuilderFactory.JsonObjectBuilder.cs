namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal static partial class JsonBuilderFactory
{
    private sealed class JsonObjectBuilder<TParent> :
        JsonBaseBuilder<TParent>,
        IObjectBuilder<TParent>,
        IPrimitiveBuilder<IObjectBuilder<TParent>>
        where TParent : class
    {
        public JsonObjectBuilder(TParent parent, Utf8JsonWriter writer)
            : base(parent, writer)
        {
            JsonWriter.WriteStartObject();
        }

        public TParent ObjectEnd()
        {
            JsonWriter.WriteEndObject();

            return Parent;
        }

        private TSelf Property<TSelf>(TSelf self, string propertyName)
            where TSelf : IObjectBuilder<TParent>, IPrimitiveBuilder<IObjectBuilder<TParent>>
        {
            JsonWriter.WritePropertyName(propertyName);

            return self;
        }

        public IPrimitiveBuilder<IObjectBuilder<TParent>> Property(string propertyName) =>
            Property(this, propertyName);

        public IArrayBuilder<IObjectBuilder<TParent>> ArrayStart(string propertyName) =>
            new JsonArrayBuilder<IObjectBuilder<TParent>>(Property(this, propertyName), JsonWriter);

        public IObjectBuilder<IObjectBuilder<TParent>> ObjectStart(string propertyName) =>
            new JsonObjectBuilder<IObjectBuilder<TParent>>(Property(this, propertyName), JsonWriter);
    }
}