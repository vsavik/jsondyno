namespace Jsondyno.Tests.Misc.Customizations;

public sealed class RandomPrimitives : ICustomization
{
    public void Customize(IFixture fixture)
    {
        Register<char>(fixture, faker => faker.Random.Char);
        Register<sbyte>(fixture, faker => faker.Random.SByte);
        Register<short>(fixture, faker => faker.Random.Short);
        Register<int>(fixture, faker => faker.Random.Int);
        Register<long>(fixture, faker => faker.Random.Long);
        Register<byte>(fixture, faker => faker.Random.Byte);
        Register<ushort>(fixture, faker => faker.Random.UShort);
        Register<uint>(fixture, faker => faker.Random.UInt);
        Register<ulong>(fixture, faker => faker.Random.ULong);
        Register<float>(fixture, faker => faker.Random.Float);
        Register<double>(fixture, faker => faker.Random.Double);
        Register<decimal>(fixture, faker => faker.Random.Decimal);
        Register<DateTime>(fixture, faker => faker.Date.Between);
        Register<DateTimeOffset>(fixture, faker => faker.Date.BetweenOffset);
    }

    private static void Register<T>(
        IFixture fixture,
        Func<Faker, GenerateRandomBetweenDelegate<T>> registration)
    {
        fixture.Register(registration);
    }
}