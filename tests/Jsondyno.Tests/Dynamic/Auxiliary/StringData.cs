namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class StringData : TheoryData<string>, ICustomization
{
    public void Customize(IFixture fixture)
    {
        var faker = fixture.Create<Faker>();
        int count = faker.Random.Int(2, 8);
        string str = faker.Random.String2(count);
        Add(str);
        fixture.InjectTheoryData(this);
    }
}