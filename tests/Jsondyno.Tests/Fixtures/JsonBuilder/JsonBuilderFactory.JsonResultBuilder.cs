namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal static partial class JsonBuilderFactory
{
    private sealed class JsonResultBuilder<TOwner> : JsonBaseBuilder<IJsonResult>, IJsonBuilder
        where TOwner : class, IJsonResult, IJsonWriterOwner
    {
        public JsonResultBuilder(TOwner owner)
            : base(owner, owner.JsonWriter)
        {
        }

        public IJsonResult Self => Parent;

        public IArrayBuilder<IJsonResult> ArrayStart() =>
            new JsonArrayBuilder<IJsonResult>(Parent, JsonWriter);

        public IObjectBuilder<IJsonResult> ObjectStart() =>
            new JsonObjectBuilder<IJsonResult>(Parent, JsonWriter);
    }
}