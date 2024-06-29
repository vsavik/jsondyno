using Jsondyno.Tests.Dynamic.Auxiliary;

namespace Jsondyno.Tests.Dynamic;

public sealed class PrimitiveAdapterTestFixture
{
    private readonly Mock<IJsonValue> _mock = new(MockBehavior.Strict);

    private readonly Fixture _fixture = new();

    private readonly ITestOutputHelper _output;

    public PrimitiveAdapterTestFixture(ITestOutputHelper output)
    {
        _output = output;
        _fixture.RegisterPrimitiveAdapter(_mock);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    [FixtureData<Sample.EnumData>]
    [FixtureData<Sample.StructData>]
    [ClassData(typeof(DateTimeData.MinMax))]
    [FixtureData<DateTimeData.Random>]
    [ClassData(typeof(DateTimeData.MinMaxOffset))]
    [FixtureData<DateTimeData.RandomOffset>]
    [ClassData(typeof(GuidData.Known))]
    [FixtureData<GuidData.Random>]
    [ClassData(typeof(NumberData.Unsigned<byte>.ZeroOneMax))]
    [ClassData(typeof(NumberData.Unsigned<ushort>.ZeroOneMax))]
    [ClassData(typeof(NumberData.Unsigned<uint>.ZeroOneMax))]
    [ClassData(typeof(NumberData.Unsigned<ulong>.ZeroOneMax))]
    [ClassData(typeof(NumberData.Signed<sbyte>.ZeroOneMinMax))]
    [ClassData(typeof(NumberData.Signed<short>.ZeroOneMinMax))]
    [ClassData(typeof(NumberData.Signed<int>.ZeroOneMinMax))]
    [ClassData(typeof(NumberData.Signed<long>.ZeroOneMinMax))]
    [ClassData(typeof(NumberData.Floating<float>.ZeroOneMinMax))]
    [ClassData(typeof(NumberData.Floating<double>.ZeroOneMinMax))]
    [ClassData(typeof(NumberData.Floating<decimal>.ZeroOneMinMax))]
    [FixtureData<NumberData.Unsigned<byte>.Random>]
    [FixtureData<NumberData.Unsigned<ushort>.Random>]
    [FixtureData<NumberData.Unsigned<uint>.Random>]
    [FixtureData<NumberData.Unsigned<ulong>.Random>]
    [FixtureData<NumberData.Signed<sbyte>.Random>]
    [FixtureData<NumberData.Signed<short>.Random>]
    [FixtureData<NumberData.Signed<int>.Random>]
    [FixtureData<NumberData.Signed<long>.Random>]
    [FixtureData<NumberData.Floating<float>.Random>]
    [FixtureData<NumberData.Floating<double>.Random>]
    [FixtureData<NumberData.Floating<decimal>.Random>]
    public void VerifyConversionToValueType<T>(T expected)
        where T : struct
    {
        VerifyConversionToType(expected);
        VerifyConversionToType((T?)expected);
    }

    [Theory]
    [InlineData("")]
    [FixtureData<StringData>]
    [FixtureData<StringArrayData>]
    [FixtureData<ByteArrayData>]
    [FixtureData<DictionaryData>]
    [FixtureData<Sample.ClassData>]
    public void VerifyConversionToType<T>(T expectedValue)
    {
        // Arrange
        _output.WriteLine($"Validating '{typeof(T).Description()}' type conversion.");
        _fixture.Do<JsonSerializerOptions>(opts => _mock.InjectDeserializeResult(opts, expectedValue));
        dynamic adapter = _fixture.Create<PrimitiveAdapter>();

        // Act
        T actual = adapter;
        T actualCached = adapter;

        // Assert
        actual.ShouldBe(expectedValue);
        actualCached.ShouldBe(expectedValue);
        _mock.VerifyAll();
    }
}