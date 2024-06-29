namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class StringArrayData : TheoryData<string[]>, ICustomization
{
    public void Customize(IFixture fixture)
    {
        var faker = fixture.Create<Faker>();
        int count = faker.Random.Int(2, 6);
        string[] words = faker.Random.WordsArray(count);
        Add(words);
        fixture.InjectTheoryData(this);
    }
}