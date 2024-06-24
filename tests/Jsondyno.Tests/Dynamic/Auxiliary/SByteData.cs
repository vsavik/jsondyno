namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class SByteData : NumberData<SByteData, sbyte>
{
    protected override sbyte GenerateRandom(sbyte min, sbyte max) =>
        Faker.Random.SByte(min, max);
}