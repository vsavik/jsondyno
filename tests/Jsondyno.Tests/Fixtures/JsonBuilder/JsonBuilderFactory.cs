namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal static partial class JsonBuilderFactory
{
    public static IJsonBuilder Create<T>(T owner)
        where T : class, IJsonResult, IJsonWriterOwner
    {
        return new JsonResultBuilder<T>(owner);
    }
}