namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class FloatData : NumberData<FloatData, float>
{
    protected override float GenerateRandom(float min, float max) =>
        Faker.Random.Float(min, max);
}