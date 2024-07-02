using NUnit.Framework.Interfaces;

namespace Jsondyno.Tests.Misc;

public sealed class Args : NUnit.Framework.Internal.TestParameters, ITestFixtureData
{
    private Args(params object?[] args)
        : base(args)
    {
    }

    public Type[]? TypeArgs { get; init; }

    public Args WithName(string testName)
    {
        TestName = testName;

        return this;
    }

    public static Args Create<T>(T? arg) =>
        new(arg) { TypeArgs = [typeof(T)] };

    public static Args Random<T>(Func<Faker, T> factory)
    {
        Faker faker = new();

        return Create(factory(faker));
    }
}