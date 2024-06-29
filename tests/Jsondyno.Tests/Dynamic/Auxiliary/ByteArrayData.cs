namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class ByteArrayData : TheoryData<byte[]>, ICustomization
{
    public void Customize(IFixture fixture)
    {
        var faker = fixture.Create<Faker>();
        int count = faker.Random.Int(2, 8);
        byte[] bytes = faker.Random.Bytes(count);
        Add(bytes);
        fixture.InjectTheoryData(this);
    }
}