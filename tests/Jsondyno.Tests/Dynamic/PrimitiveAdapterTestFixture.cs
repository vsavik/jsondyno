using Jsondyno.Internal;
using Jsondyno.Internal.Dynamic;
using Jsondyno.Tests.Dynamic.Auxiliary;
using Jsondyno.Tests.Misc;

namespace Jsondyno.Tests.Dynamic;

public sealed class PrimitiveAdapterTestFixture : IClassFixture<SeedFixture>
{
    private readonly Mock<IJsonValue> _jsonValueMock = new(MockBehavior.Strict);

    private readonly Fixture _fixture = new();

    public PrimitiveAdapterTestFixture(ITestOutputHelper output)
    {
        _fixture.Inject(output);
        _fixture.Inject(JsonSerializerOptions.Default);
        _fixture.Inject(new Context(JsonSerializerOptions.Default));
        _fixture.Register(AsFunc(ConfigureJsonValue));
        _fixture.Register(AsFunc(ConfigurePrimitiveAdapter));
    }

    private IJsonValue ConfigureJsonValue(
        ITestOutputHelper output,
        JsonSerializerOptions opts,
        (object Value, Type Type) expected)
    {
        output.WriteLine(
            $"Expected value is {expected.Value} of type {expected.Type}.");

        _jsonValueMock.Setup(jsonValue => jsonValue.Deserialize(expected.Type, opts))
            .Returns(expected.Value)
            .Verifiable(Times.Once, "Caching doesn't work.");

        return _jsonValueMock.Object;
    }

    private PrimitiveAdapter ConfigurePrimitiveAdapter(IJsonValue jsonValue, Context context) =>
        new(jsonValue, context);

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void VerifyConversionToBoolean(bool expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<SByteData>(nameof(SByteData.SignedIntegralMinMaxZeroOne))]
    [MemberRandomData<SByteData>(nameof(SByteData.SignedIntegralRandomPositive))]
    [MemberRandomData<SByteData>(nameof(SByteData.SignedIntegralRandomNegative))]
    public void VerifyConversionToSByte(sbyte expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<Int16Data>(nameof(Int16Data.SignedIntegralMinMaxZeroOne))]
    [MemberRandomData<Int16Data>(nameof(Int16Data.SignedIntegralRandomPositive))]
    [MemberRandomData<Int16Data>(nameof(Int16Data.SignedIntegralRandomNegative))]
    public void VerifyConversionToShort(short expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<Int32Data>(nameof(Int32Data.SignedIntegralMinMaxZeroOne))]
    [MemberRandomData<Int32Data>(nameof(Int32Data.SignedIntegralRandomPositive))]
    [MemberRandomData<Int32Data>(nameof(Int32Data.SignedIntegralRandomNegative))]
    public void VerifyConversionToInt(int expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<Int64Data>(nameof(Int64Data.SignedIntegralMinMaxZeroOne))]
    [MemberRandomData<Int64Data>(nameof(Int64Data.SignedIntegralRandomPositive))]
    [MemberRandomData<Int64Data>(nameof(Int64Data.SignedIntegralRandomNegative))]
    public void VerifyConversionToLong(long expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<ByteData>(nameof(ByteData.UnsignedIntegralZeroMaxOne))]
    [MemberRandomData<ByteData>(nameof(ByteData.UnsignedIntegralRandom))]
    public void VerifyConversionToByte(byte expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<UInt16Data>(nameof(UInt16Data.UnsignedIntegralZeroMaxOne))]
    [MemberRandomData<UInt16Data>(nameof(UInt16Data.UnsignedIntegralRandom))]
    public void VerifyConversionToUShort(ushort expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<UInt32Data>(nameof(UInt32Data.UnsignedIntegralZeroMaxOne))]
    [MemberRandomData<UInt32Data>(nameof(UInt32Data.UnsignedIntegralRandom))]
    public void VerifyConversionToUInt(uint expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<UInt64Data>(nameof(UInt64Data.UnsignedIntegralZeroMaxOne))]
    [MemberRandomData<UInt64Data>(nameof(UInt64Data.UnsignedIntegralRandom))]
    public void VerifyConversionToULong(ulong expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<FloatData>(nameof(FloatData.FloatingMinMaxZeroOne))]
    [MemberRandomData<FloatData>(nameof(FloatData.FloatingRandomPositiveBelowOne))]
    [MemberRandomData<FloatData>(nameof(FloatData.FloatingRandomPositiveAboveOne))]
    [MemberRandomData<FloatData>(nameof(FloatData.FloatingRandomNegativeAboveOne))]
    [MemberRandomData<FloatData>(nameof(FloatData.FloatingRandomNegativeBelowOne))]
    public void VerifyConversionToFloat(float expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<DoubleData>(nameof(DoubleData.FloatingMinMaxZeroOne))]
    [MemberRandomData<DoubleData>(nameof(DoubleData.FloatingRandomPositiveBelowOne))]
    [MemberRandomData<DoubleData>(nameof(DoubleData.FloatingRandomPositiveAboveOne))]
    [MemberRandomData<DoubleData>(nameof(DoubleData.FloatingRandomNegativeAboveOne))]
    [MemberRandomData<DoubleData>(nameof(DoubleData.FloatingRandomNegativeBelowOne))]
    public void VerifyConversionToDouble(double expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [MemberData<DecimalData>(nameof(DecimalData.FloatingMinMaxZeroOne))]
    [MemberRandomData<DecimalData>(nameof(DecimalData.FloatingRandomPositiveBelowOne))]
    [MemberRandomData<DecimalData>(nameof(DecimalData.FloatingRandomPositiveAboveOne))]
    [MemberRandomData<DecimalData>(nameof(DecimalData.FloatingRandomNegativeAboveOne))]
    [MemberRandomData<DecimalData>(nameof(DecimalData.FloatingRandomNegativeBelowOne))]
    public void VerifyConversionToDecimal(decimal expected) =>
        VerifyConversionToType(expected);

    /*
    [Theory]
    [InlineAutoData]
    public void VerifyConversionToGuid(Guid expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [ClassData(typeof(DateTimeData))]
    public void VerifyConversionToDateTime(DateTime expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [ClassData(typeof(DateTimeOffsetData))]
    public void VerifyConversionToDateTimeOffset(DateTimeOffset expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [InlineData("")]
    [InlineAutoData]
    public void VerifyConversionToString(string expected) =>
        VerifyConversionToType(expected);

    [Theory]
    [InlineAutoData]
    public void VerifyConversionToByteArray(byte[] expected) =>
        VerifyConversionToType(expected);
        */

    private void VerifyConversionToType<T>(T expected)
    {
        // Arrange
        dynamic adapter = _fixture.InjectExpected(expected).Create<PrimitiveAdapter>();

        // Act
        T actual = adapter;
        T actualCached = adapter;

        // Assert
        actual.ShouldBe(expected);
        actualCached.ShouldBe(expected);
        _jsonValueMock.VerifyAll();
    }
}

file static class LocalExtensions
{
    public static IFixture InjectExpected<T>(this IFixture fixture, T expected)
    {
        fixture.Inject(((object?)expected, typeof(T))); // expected maybe nullable, but never null

        return fixture;
    }

    public static T? ToNull<T>(this T value)
        where T : struct =>
        value;
}