namespace Jsondyno.Tests.Fixtures;

public sealed class FakerFixture
{
    public FakerFixture()
        : this(Random.Shared.Next())
    {
    }

    internal FakerFixture(int seed)
    {
        Seed = seed;
    }

    public int Seed { get; }

    public static implicit operator Faker(FakerFixture fixure) =>
        new() { Random = new Randomizer(fixure.Seed) };
}