namespace Jsondyno.Tests.Misc;

public static class FixtureExtensions
{
    public static IFixture WithAdapterCustomization(this IFixture fixture) =>
        fixture.Customize(new AdapterCustomization());

    public static IFixture WithInstance<T>(this IFixture fixture, T item)
    {
        fixture.Inject(item);

        return fixture;
    }
}