namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal static partial class JsonBuilderFactory
{
    private sealed class JsonResultBuilder : JsonBaseBuilder<IJsonResult>, IJsonBuilder, IJsonResult
    {
        public JsonResultBuilder(Utf8JsonWriter writer)
            : base(default!, writer)
        {
        }

        public IJsonResult Self => this;

        public IArrayBuilder<IJsonResult> ArrayStart() =>
            new JsonArrayBuilder<IJsonResult>(this, JsonWriter);

        public IObjectBuilder<IJsonResult> ObjectStart() =>
            new JsonObjectBuilder<IJsonResult>(this, JsonWriter);
    }
}