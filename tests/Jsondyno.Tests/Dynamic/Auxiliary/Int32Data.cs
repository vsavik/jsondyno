namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class Int32Data : NumberData<Int32Data, int>
{
    protected override int GenerateRandom(int min, int max) =>
        Faker.Random.Int(min, max);
}