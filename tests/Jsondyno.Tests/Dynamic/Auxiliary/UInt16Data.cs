namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class UInt16Data : NumberData<UInt16Data, ushort>
{
    protected override ushort GenerateRandom(ushort min, ushort max) =>
        Faker.Random.UShort(min, max);
}