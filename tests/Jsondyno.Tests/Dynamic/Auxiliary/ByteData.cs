namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class ByteData : NumberData<ByteData, byte>
{
    protected override byte GenerateRandom(byte min, byte max) =>
        Faker.Random.Byte(min, max);
}