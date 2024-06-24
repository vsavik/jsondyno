namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class Int16Data : NumberData<Int16Data, short>
{
    protected override short GenerateRandom(short min, short max) =>
        Faker.Random.Short(min, max);
}