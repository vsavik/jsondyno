namespace Jsondyno.Tests.Dynamic.Auxiliary;

public static class GuidData
{
    public sealed class Known : TheoryData<Guid>
    {
        public Known()
        {
            Add(Guid.Empty);
            Add(Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"));
        }
    }

    public sealed class Random : TheoryData<Guid>, ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var faker = fixture.Create<Faker>();
            Add(faker.Random.Guid());
            fixture.InjectTheoryData(this);
        }
    }
}