namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class UInt32Data : NumberData<UInt32Data, uint>
{
    protected override uint GenerateRandom(uint min, uint max) =>
        Faker.Random.UInt(min, max);
}