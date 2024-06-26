using System.Reflection;
using AutoFixture.Kernel;
using Jsondyno.Internal;
using Jsondyno.Internal.Dynamic;
using Jsondyno.Tests.Dynamic.Auxiliary;

namespace Jsondyno.Tests.Dynamic;

public sealed class PrimitiveAdapterTestFixture : IClassFixture<SeedFixture>
{
    private readonly Mock<IJsonValue> _jsonValueMock = new(MockBehavior.Strict);

    private readonly Fixture _fixture = new();

    private readonly ITestOutputHelper _output;

    public PrimitiveAdapterTestFixture(ITestOutputHelper output)
    {
        _output = output;
        _fixture.Inject(_jsonValueMock.Object);
        _fixture.RegisterDynamicAdapters();
    }

    public static TheoryData<DateTime> MinMaxDateTime =>
        new(DateTime.MinValue, DateTime.MaxValue);

    public static TheoryData<DateTimeOffset> MinMaxDateTimeOffset =>
        new(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);

    public static TheoryData<Guid> StaticGuids =>
        new(Guid.Empty, Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"));

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    [MemberData(nameof(MinMaxDateTime))]
    [MemberData(nameof(MinMaxDateTimeOffset))]
    [MemberData(nameof(StaticGuids))]
    [ClassData(typeof(UnsignedNumberData<byte>))]
    [ClassData(typeof(UnsignedNumberData<ushort>))]
    [ClassData(typeof(UnsignedNumberData<uint>))]
    [ClassData(typeof(UnsignedNumberData<ulong>))]
    [ClassData(typeof(SignedNumberData<sbyte>))]
    [ClassData(typeof(SignedNumberData<short>))]
    [ClassData(typeof(SignedNumberData<int>))]
    [ClassData(typeof(SignedNumberData<long>))]
    [ClassData(typeof(SignedNumberData<float>))]
    [ClassData(typeof(SignedNumberData<double>))]
    [ClassData(typeof(SignedNumberData<decimal>))]
    [RandomFixtureData<Configuration<SampleEnum>>]
    [RandomFixtureData<Configuration<SampleStruct>>]
    [RandomFixtureData<Configuration<DateTime>>]
    [RandomFixtureData<Configuration<DateTimeOffset>>]
    [RandomFixtureData<Configuration<Guid>>]
    [RandomClassDataAttribute<TheoryData<byte>>]
    [RandomClassDataAttribute<TheoryData<ushort>>]
    [RandomClassDataAttribute<TheoryData<uint>>]
    [RandomClassDataAttribute<TheoryData<ulong>>]
    [RandomClassDataAttribute<TheoryData<sbyte>>]
    [RandomClassDataAttribute<TheoryData<short>>]
    [RandomClassDataAttribute<TheoryData<int>>]
    [RandomClassDataAttribute<TheoryData<long>>]
    [RandomClassDataAttribute<TheoryData<float>>]
    [RandomClassDataAttribute<TheoryData<double>>]
    [RandomClassDataAttribute<TheoryData<decimal>>]
    public void VerifyConversionToValueType<T>(T expected)
        where T : struct
    {
        VerifyConversionToType(expected);
        VerifyConversionToType((T?)expected);
    }

    [Theory]
    [InlineData("")]
    [RandomFixtureData<Configuration<string>>]
    [RandomFixtureData<Configuration<byte[]>>]
    [RandomFixtureData<Configuration<SampleClass>>]
    public void VerifyConversionToType<T>(T expected)
    {
        // Arrange
        _output.WriteLine($"Expected type is {typeof(T).Description()}.");
        _jsonValueMock.SetExpectedValue(expected);
        dynamic adapter = _fixture.Create<PrimitiveAdapter>();

        // Act
        T actual = adapter;
        T actualCached = adapter;

        // Assert
        actual.ShouldBe(expected);
        actualCached.ShouldBe(expected);
        _jsonValueMock.VerifyAll();
    }

    public sealed class Configuration<T> : ICustomization, ISpecimenBuilder
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(this);
            fixture.RegisterRandomGenerators()
                .RegisterStringGenerator()
                .RegisterByteArrayGenerator()
                .RegisterDateGenerators()
                .RegisterGuidGenerator();

            fixture.Register((string str) => new SampleClass(str));
            fixture.RegisterFactory(faker => faker.Random.Enum<SampleEnum>());
            fixture.Register((int a) => new SampleStruct(a));
            fixture.Freeze<Guid>();
        }

        public object? Create(object request, ISpecimenContext context)
        {
            if (request is ParameterInfo
                {
                    ParameterType.IsGenericParameter: true
                })
            {
                return context.Create<T>();
            }

            return new NoSpecimen();
        }
    }
}