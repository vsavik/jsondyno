namespace Jsondyno.Tests.Dynamic.Auxiliary;

internal static class AdapterFixtureExtensions
{
    public static void RegisterPrimitiveAdapter(this IFixture fixture, Mock<IJsonValue> mock)
    {
        fixture.Inject(JsonSerializerOptions.Default);
        fixture.RegisterContext();
        fixture.Inject(mock.Object);
        fixture.Register((Context context, IJsonValue jsonValue) =>
            context.CreatePrimitiveAdapter(jsonValue));
    }

    public static void RegisterArrayAdapter(this IFixture fixture, Mock<IJsonArray> mock)
    {
        fixture.Inject(JsonSerializerOptions.Default);
        fixture.RegisterContext();
        fixture.Inject(mock.Object);
        fixture.Register((Context context, IJsonArray jsonArray) =>
            context.CreateArrayAdapter(jsonArray));
    }

    public static void RegisterObjectAdapter(this IFixture fixture, Mock<IJsonObject> mock)
    {
        fixture.Inject(JsonSerializerOptions.Default);
        fixture.RegisterContext();
        fixture.Inject(mock.Object);
        fixture.Register((Context context, IJsonObject jsonObject) =>
            context.CreateObjectAdapter(jsonObject));
    }

    private static void RegisterContext(this IFixture fixture)
    {
        fixture.Register((JsonSerializerOptions opts) => new Context(opts));
        fixture.Freeze<Context>();
    }

    public static void InjectTheoryData(this IFixture fixture, TheoryData data)
    {
        fixture.Inject(data);
    }
}