namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class ArrayItemData : TheoryData<ArrayItem, ArrayItem>, ICustomization
{
    public void Customize(IFixture fixture)
    {
        Faker faker = fixture.Create<Faker>();

        (int index1, int index2) = faker.Random.Shuffle(Enumerable.Range(0, 100)).Take(2);

        var item1 = new ArrayItem(index1, CreateValue(faker));
        var item2 = new ArrayItem(index2, CreateValue(faker));

        Add(item1, item2);

        fixture.InjectTheoryData(this);
    }

    private string CreateValue(Faker faker)
    {
        int length = faker.Random.Int(2, 8);
        string value = faker.Random.String2(length);

        return value;
    }
}