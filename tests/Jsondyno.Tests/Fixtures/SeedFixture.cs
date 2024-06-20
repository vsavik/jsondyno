namespace Jsondyno.Tests.Fixtures;

public sealed class SeedFixture
{
    private int _seed = Random.Shared.Next(Int32.MinValue, Int32.MaxValue);

    public SeedFixture WithSeed(int seed)
    {
        _seed = seed;

        return this;
    }

    public Faker CreateFaker(ITestOutputHelper output)
    {
        output.WriteLine($"Initializing Faker with seed: {_seed}");

        return new Faker { Random = new Randomizer(_seed) };
    }
}