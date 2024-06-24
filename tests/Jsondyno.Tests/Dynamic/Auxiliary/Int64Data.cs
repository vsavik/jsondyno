namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class Int64Data : NumberData<Int64Data, long>
{
    protected override long GenerateRandom(long min, long max) =>
        Faker.Random.Long(min, max);
}