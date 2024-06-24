namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class DecimalData : NumberData<DecimalData, decimal>
{
    protected override decimal GenerateRandom(decimal min, decimal max) =>
        Faker.Random.Decimal(min, max);
}