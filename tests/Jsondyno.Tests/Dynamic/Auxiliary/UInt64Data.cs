namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class UInt64Data : NumberData<UInt64Data, ulong>
{
    protected override ulong GenerateRandom(ulong min, ulong max) =>
        Faker.Random.ULong(min, max);
}