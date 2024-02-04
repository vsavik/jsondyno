namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal static partial class JsonBuilderFactory
{
    private abstract class JsonBaseBuilder<TParent> : IPrimitiveBuilder
        where TParent : class
    {
        protected JsonBaseBuilder(TParent parent, Utf8JsonWriter writer)
        {
            Parent = parent;
            JsonWriter = writer;
        }

        protected TParent Parent { get; }

        protected Utf8JsonWriter JsonWriter { get; }

        public void WriteNull() => JsonWriter.WriteNullValue();

        public void WriteNumber(int number) => JsonWriter.WriteNumberValue(number);
    }
}