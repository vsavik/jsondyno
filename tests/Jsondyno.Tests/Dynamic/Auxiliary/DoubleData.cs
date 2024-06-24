namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class DoubleData : NumberData<DoubleData, double>
{
    protected override double GenerateRandom(double min, double max) =>
        Faker.Random.Double(min, max);
}