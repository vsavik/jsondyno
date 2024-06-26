using System.Numerics;
using Jsondyno.Internal;
using Jsondyno.Internal.Dynamic;

namespace Jsondyno.Tests.Dynamic.Auxiliary;

public static class FixtureExtensions
{
    public static IFixture RegisterDynamicAdapters(this IFixture fixture) => fixture
        .RegisterContext()
        .RegisterArrayAdapter()
        .RegisterPrimitiveAdapter();

    public static IFixture RegisterContext(this IFixture fixture)
    {
        fixture.Inject(JsonSerializerOptions.Default);
        fixture.Inject(new Context(JsonSerializerOptions.Default));

        return fixture;
    }

    public static IFixture RegisterPrimitiveAdapter(this IFixture fixture)
    {
        fixture.Register((IJsonValue jsonValue, Context context) =>
            new PrimitiveAdapter(jsonValue, context));

        return fixture;
    }

    public static IFixture RegisterArrayAdapter(this IFixture fixture)
    {
        fixture.Register((IJsonArray jsonArray, Context context) =>
            new ArrayAdapter(jsonArray, context));

        return fixture;
    }

    public static IFixture RegisterRandomNumbers(this IFixture fixture)
    {
        fixture.RegisterRandomUnsignedNubmer<byte>();
        fixture.RegisterRandomUnsignedNubmer<ushort>();
        fixture.RegisterRandomUnsignedNubmer<uint>();
        fixture.RegisterRandomUnsignedNubmer<ulong>();
        fixture.RegisterRandomSignedNubmer<sbyte>();
        fixture.RegisterRandomSignedNubmer<short>();
        fixture.RegisterRandomSignedNubmer<int>();
        fixture.RegisterRandomSignedNubmer<long>();
        fixture.RegisterRandomFloatingNubmer<float>();
        fixture.RegisterRandomFloatingNubmer<double>();
        fixture.RegisterRandomFloatingNubmer<decimal>();

        return fixture;
    }

    private static void RegisterRandomSignedNubmer<TNumber>(this IFixture fixture)
        where TNumber : ISignedNumber<TNumber>, IMinMaxValue<TNumber>
    {
        fixture.Register<RandomGenerator<TNumber>, TheoryData<TNumber>>(generator =>
            new SignedRandomNumberData<TNumber>(generator));
    }

    private static void RegisterRandomUnsignedNubmer<TNumber>(this IFixture fixture)
        where TNumber : IUnsignedNumber<TNumber>, IMinMaxValue<TNumber>
    {
        fixture.Register<RandomGenerator<TNumber>, TheoryData<TNumber>>(generator =>
            new UnsignedRandomNumberData<TNumber>(generator));
    }

    private static void RegisterRandomFloatingNubmer<TNumber>(this IFixture fixture)
        where TNumber : ISignedNumber<TNumber>, IFloatingPoint<TNumber>, IMinMaxValue<TNumber>
    {
        fixture.Register<RandomGenerator<TNumber>, TheoryData<TNumber>>(generator =>
            new FloatingPointRandomData<TNumber>(generator));
    }
}