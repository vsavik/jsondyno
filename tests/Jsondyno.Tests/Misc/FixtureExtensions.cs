namespace Jsondyno.Tests.Misc;

public static class FixtureExtensions
{
    public static IFixture WithInstance<T>(this IFixture fixture, T item)
    {
        fixture.Inject(item);

        return fixture;
    }
}