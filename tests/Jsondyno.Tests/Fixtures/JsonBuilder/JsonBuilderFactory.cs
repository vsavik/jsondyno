namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal static partial class JsonBuilderFactory
{
    public static IJsonBuilder Create(Utf8JsonWriter writer)
    {
        return new JsonResultBuilder(writer);
    }
}