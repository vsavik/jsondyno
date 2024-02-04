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

        void IPrimitiveBuilder.WriteNull() => JsonWriter.WriteNullValue();

        void IPrimitiveBuilder.WriteBoolean(bool boolean) => JsonWriter.WriteBooleanValue(boolean);

        void IPrimitiveBuilder.WriteNumber(int number) => JsonWriter.WriteNumberValue(number);

        void IPrimitiveBuilder.WriteNumber(double number) => JsonWriter.WriteNumberValue(number);

        void IPrimitiveBuilder.WriteString(string str) => JsonWriter.WriteStringValue(str);
    }
}