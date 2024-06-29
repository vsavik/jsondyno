namespace Jsondyno.Tests.Dynamic.Auxiliary;

internal static class AdapterFixtureExtensions
{
    public static void RegisterPrimitiveAdapter(this IFixture fixture, Mock<IJsonValue> mock)
    {
        fixture.RegisterAdapterDependencies(mock);
        fixture.Register((Context context, IJsonValue jsonValue) =>
            context.CreatePrimitiveAdapter(jsonValue));
    }

    public static void RegisterArrayAdapter(this IFixture fixture, Mock<IJsonArray> mock)
    {
        fixture.RegisterAdapterDependencies(mock);
        fixture.Register((Context context, IJsonArray jsonArray) =>
            context.CreateArrayAdapter(jsonArray));
    }

    public static void RegisterObjectAdapter(this IFixture fixture, Mock<IJsonObject> mock)
    {
        fixture.RegisterAdapterDependencies(mock);
        fixture.Register((Context context, IJsonObject jsonObject) =>
            context.CreateObjectAdapter(jsonObject));
    }

    public static void RegisterAdapterDependencies<T>(this IFixture fixture, Mock<T> mock)
        where T : class, IJsonValue
    {
        fixture.Inject(JsonSerializerOptions.Default);
        fixture.Register((JsonSerializerOptions opts) => new Context(opts));
        fixture.Freeze<Context>();
        fixture.Inject(mock.Object);
    }

    public static void InjectTheoryData(this IFixture fixture, TheoryData data)
    {
        fixture.Inject(data);
    }
}