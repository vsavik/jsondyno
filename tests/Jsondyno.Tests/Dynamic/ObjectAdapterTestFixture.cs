using System.Reflection;
using System.Text;
using AutoFixture.Kernel;
using Jsondyno.Tests.Dynamic.Auxiliary;
using Xunit.Sdk;

namespace Jsondyno.Tests.Dynamic;

public sealed class ObjectAdapterTestFixture : IDisposable
{
    private readonly Mock<IJsonObject> _mock = new(MockBehavior.Strict);

    private readonly ObjectAdapter _adapter;

    private readonly Fixture _fixture = new();

    private readonly ITestOutputHelper _output;

    public ObjectAdapterTestFixture(ITestOutputHelper output)
    {
        _output = output;


        _adapter = new ObjectAdapter(_mock.Object, new Context(JsonSerializerOptions.Default));

        MyCtx.Builder.AppendLine("Start test fixture");
        _fixture.RegisterObjectAdapter(_mock); // TODO: factory based on json naming policy


        _mock.Setup(x => x.Deserialize(typeof(string), JsonSerializerOptions.Default))
            .Returns(() => String.Empty)
            .Verifiable(() => Times.Exactly(1));


        //_mock.When(() => true).Setup()


        // in this case problem in parameters: multiple setup call require all parameters, so Register call is quite weird with all parameters for all methods
        _fixture.Register((string expected) =>
        {
            var opts = JsonSerializerOptions.Default;
            var ctx = new Context(opts);

            _mock
                .Setup(x => x.Deserialize(typeof(string), opts))
                .Returns(expected)
                .Verifiable(() => Times.Exactly(1)

            return new ObjectAdapter(_mock.Object, ctx);
        });


        // prefer Do approach or When approach
        _fixture.Do((string expected, JsonSerializerOptions opts) => _mock
            .Setup(x => x.Deserialize(typeof(string), opts))
            .Returns(expected)
            .Verifiable(() => Times.Exactly(1)));
    }

    private sealed class JsonObjectMock : Mock<IJsonObject>
    {
        public JsonObjectMock()
            : base(MockBehavior.Strict)
        {
        }

        public void SetupDeserialize(JsonSerializerOptions opts, string expected)
        {
            Setup(x => x.Deserialize(typeof(string), opts))
                .Returns(expected)
                .Verifiable(() => Times.Exactly(1));
        }
    }

    // Test cases
    // input: property key (string), property value (string)
    // valid access - name - name
    // property not matched by name
    // property not matched by case

    // data - object (real key + real value), key, actual value
    // object (some key, some value) - key (one test to null, other to some value)


    //[Theory]
    public void VerifyIndexerAccess(
        string propertyKey,
        string propertyValue,
        string requestedKey,
        string requestedValue,
        string key, string expectedPropValue)
    {
        // Arrange
        dynamic adapter = _fixture.Create<ObjectAdapter>();

        // Act
        string? actualPropValue = adapter[key];

        // Assert
        actualPropValue.ShouldBe(expectedPropValue);
        _mock.VerifyAll();
    }

    /*
    // TODO + policy - 6 tests for each policy * 2 foe case sensitive or not
    // + some negative cases when i receive null
    [Theory]
    [FixtureData<Auto>]
    public void VerifyAccessByPropertyName(Sample.Class obj)
    {
        // Arrange
        _fixture.Do<JsonSerializerOptions>(opts => _mock.InjectConvertTarget(opts, obj));
        dynamic adapter = _fixture.Create<ObjectAdapter>();

        // Act
        string[] actualArray = adapter;

        // Assert
        actualArray.ShouldBe(expectedArray);
        _mock.VerifyAll();
    }*/

    /*[Theory]
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
    }*/

    [Theory]
    [InlineData("")]
    [FixtureData<StringData>]
    [FixtureData<StringArrayData>]
    [FixtureData<ByteArrayData>]
    [FixtureData<DictionaryData>]
    [FixtureData<Sample.ClassData>]
    public void VerifyConversionToType<T>(T expectedValue)
    {
        MyCtx.Builder.AppendLine("Start test method");
        // Arrange
        _output.WriteLine($"Validating '{typeof(T).Description()}' type conversion.");
        _fixture.Do<JsonSerializerOptions>(opts => _mock.InjectDeserializeResult(opts, expectedValue));
        dynamic adapter = _fixture.Create<ObjectAdapter>();

        // Act
        T actual = adapter;

        // Assert
        actual.ShouldBe(expectedValue);
        _mock.VerifyAll();
        MyCtx.Builder.AppendLine("Stop test method");
    }

    public void Dispose()
    {
        MyCtx.Builder.AppendLine("Finish test fixture");
        _output.WriteLine(MyCtx.Builder.ToString());
        MyCtx.Builder.Clear();
    }
}

public sealed class MyCtx
{
    public static StringBuilder Builder { get; } = new();
}