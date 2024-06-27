namespace Jsondyno.Tests.Misc.Customizations;

public sealed class RandomWords : CustomizationBase<string[]>
{
    protected override string[] Generate(Faker faker)
    {
        int count = faker.Random.Int(2, 8);
        string[] words = faker.Random.WordsArray(count);

        return words;
    }
}