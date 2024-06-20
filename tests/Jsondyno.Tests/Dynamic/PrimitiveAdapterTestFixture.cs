namespace Jsondyno.Tests.Dynamic;

public sealed partial class PrimitiveAdapterTestFixture : IClassFixture<SeedFixture>
{
    private readonly ITestOutputHelper _output;

    private readonly Faker _faker;

    public PrimitiveAdapterTestFixture(
        SeedFixture seedFixture,
        ITestOutputHelper output)
    {
        _output = output;
        _faker = seedFixture.CreateFaker(output);
    }

    public static TheoryData<IValue> CreateStaticData() => TheoryDataBuilder.New
        .AddBooleanSource()
        .AddStaticNumberSource()
        .AddStaticDateTimeSource()
        .AddStaticDateTimeOffsetSource();

    public static TheoryData<IValue> CreateRandomData() => TheoryDataBuilder.New
        .AddRandomNumberSource()
        .AddRandomDateTimeSource()
        .AddRandomDateTimeOffsetSource()
        .AddGuidSource()
        .AddStringSource()
        .AddByteArraySource()
        .AddSampleEnumSource()
        .AddSampleValueTypeSource()
        .AddSampleRefTypeSource();

    [Theory]
    [MemberData(nameof(CreateStaticData))]
    [MemberData(nameof(CreateRandomData), DisableDiscoveryEnumeration = true)]
    public void AssertTypecastWithCaching(IValue value)
    {
        // Arrange
        ITypecastTestFixture fixture = value.CreateTestFixture(_faker);

        // Act & Assert
        fixture.AssertAdapterIsConvertedToType(_output);

        // Repeat test to to verify caching logic
        fixture.AssertAdapterIsConvertedToType(_output);
    }

    public interface IValue
    {
        ITypecastTestFixture CreateTestFixture(Faker faker);
    }

    public interface ITypecastTestFixture
    {
        void AssertAdapterIsConvertedToType(ITestOutputHelper output);
    }
}