namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class DictionaryData : TheoryData<Dictionary<int, string>>, ICustomization
{
    public void Customize(IFixture fixture)
    {
        var faker = fixture.Create<Faker>();

        Dictionary<int, string> result = new();
        int size = faker.Random.Int(2, 6);
        foreach (int key in faker.Random.Shuffle(Enumerable.Range(0, 100)).Take(size))
        {
            int length = faker.Random.Int(1, 4);
            string value = faker.Random.String2(length);

            result.Add(key, value);
        }

        Add(result);
        fixture.InjectTheoryData(this);
    }
}