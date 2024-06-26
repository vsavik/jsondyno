using AutoFixture.Xunit2;

namespace Jsondyno.Tests.Misc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class RandomFixtureDataAttribute<T> : AutoDataAttribute
    where T : ICustomization, new()
{
    public RandomFixtureDataAttribute()
        : base(CreateFixture)
    {
    }

    private static IFixture CreateFixture()
    {
        var fixture = new Fixture();
        fixture.Inject(new Faker());
        fixture.Customize(new T());

        return fixture;
    }
}