namespace Jsondyno.Tests.Misc;

public static class FixtureExtensions
{
    private static readonly DateTime s_minDate = new(2023, 12, 28);

    private static readonly DateTime s_maxDate = new(2024, 6, 5);

    public static IFixture RegisterRandomGenerators(this IFixture fixture)
    {
        Faker faker = fixture.Create<Faker>();
        fixture.InjectRandomGenerator<sbyte>(faker.Random.SByte);
        fixture.InjectRandomGenerator<short>(faker.Random.Short);
        fixture.InjectRandomGenerator<int>(faker.Random.Int);
        fixture.InjectRandomGenerator<long>(faker.Random.Long);
        fixture.InjectRandomGenerator<byte>(faker.Random.Byte);
        fixture.InjectRandomGenerator<ushort>(faker.Random.UShort);
        fixture.InjectRandomGenerator<uint>(faker.Random.UInt);
        fixture.InjectRandomGenerator<ulong>(faker.Random.ULong);
        fixture.InjectRandomGenerator<float>(faker.Random.Float);
        fixture.InjectRandomGenerator<double>(faker.Random.Double);
        fixture.InjectRandomGenerator<decimal>(faker.Random.Decimal);
        fixture.InjectRandomGenerator<DateTime>(faker.Date.Between);
        fixture.InjectRandomGenerator<DateTimeOffset>(faker.Date.BetweenOffset);

        return fixture;
    }

    private static void InjectRandomGenerator<T>(
        this IFixture fixture,
        RandomGenerator<T> generator)
    {
        fixture.Inject(generator);
    }

    public static IFixture RegisterStringGenerator(this IFixture fixture) =>
        fixture.RegisterFactory(CreateString);

    public static IFixture RegisterFactory<T>(
        this IFixture fixture,
        Func<Faker, T> function)
    {
        fixture.Register(function);

        return fixture;
    }

    private static string CreateString(Faker faker)
    {
        int length = faker.Random.Int(2, 10);
        string str = faker.Random.String2(length);

        return str;
    }

    public static IFixture RegisterStringArrayGenerator(this IFixture fixture) =>
        fixture.RegisterFactory(CreateWordsArray);

    private static string[] CreateWordsArray(Faker faker)
    {
        int count = faker.Random.Int(2, 6);
        string[] words = faker.Random.WordsArray(count);

        return words;
    }

    public static IFixture RegisterByteArrayGenerator(this IFixture fixture) =>
        fixture.RegisterFactory(CreateByteArray);

    private static string[] CreateByteArray(Faker faker)
    {
        int count = faker.Random.Int(1, 10);
        string[] words = faker.Random.WordsArray(count);

        return words;
    }

    public static IFixture RegisterDateGenerators(this IFixture fixture)
    {
        fixture.Register((RandomGenerator<DateTime> generator) => generator(s_minDate, s_maxDate));
        fixture.Register((RandomGenerator<DateTimeOffset> generator) => generator(s_minDate, s_maxDate));

        return fixture;
    }

    public static IFixture RegisterGuidGenerator(this IFixture fixture) =>
        fixture.RegisterFactory(faker => faker.Random.Guid());
}