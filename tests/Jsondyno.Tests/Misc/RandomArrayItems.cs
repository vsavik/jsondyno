namespace Jsondyno.Tests.Misc;

public sealed class RandomArrayItems
{
    public RandomArrayItems(Faker faker)
    {
        int[] indexes = faker.Random
            .Shuffle(Enumerable.Range(0, 100))
            .Take(2)
            .ToArray();

        Item1 = new Item(indexes[0], faker.Random.String2(5));
        Item2 = new Item(indexes[1], faker.Random.String2(5));
    }

    public Item Item1 { get; }

    public Item Item2 { get; }

    public override string ToString() => $"""([{Item1.Index}]="{Item1.Value}", [{Item2.Index}]="{Item2.Value}")""";

    public record Item(int Index, string Value);
}