namespace Jsondyno.Tests.Utils;

internal static class Factory
{
    public static Faker CreateFaker(ITestOutputHelper? output = null)
    {
        int seed = Random.Shared.Next();
        var faker = new Faker { Random = new Randomizer(seed) };
        output?.WriteLine($"Using seed: {seed}");

        return faker;
    }
}