namespace Jsondyno.Tests.Dynamic;

[TestFixtureSource(typeof(TypeConversionDataSource))]
public sealed class PrimitiveAdapterTestFixture<T>
{
    private readonly Mock<IJsonValue> _mock = new(MockBehavior.Strict);

    private readonly Stub _expectedReloadValue = new();

    private readonly T _expectedValue;

    private readonly dynamic _adapter;

    public PrimitiveAdapterTestFixture(T expectedValue)
    {
        _expectedValue = expectedValue;
        _adapter = new Fixture()
            .WithPrimitiveAdapter()
            .WithInstance(_mock.Object)
            .Create<PrimitiveAdapter>();

        ConfigureMock(_expectedValue);
        ConfigureMock(_expectedReloadValue);
    }

    private void ConfigureMock<TValue>(TValue item)
    {
        _mock.Setup(jsonValue => jsonValue.Deserialize(typeof(TValue)))
            .Returns(item)
            .Verifiable(Times.Once);
    }

    [Test, Order(1), Repeat(2)]
    public void VerifyTypeConversionWithCaching()
    {
        // Act
        T actual = _adapter;

        // Assert
        actual.ShouldBe(_expectedValue);
    }

    [Test, Order(2)]
    public void VerifyTypeConversionCacheReset()
    {
        // Act
        Stub actual = _adapter;

        // Assert
        actual.ShouldBe(_expectedReloadValue);
    }

    [Test, Order(3)]
    public void VerifyDeserialzieCallsCount()
    {
        // Assert
        _mock.VerifyAll();
    }

    private sealed class Stub
    {
    }
}

file static class Extensions
{
    public static IFixture WithPrimitiveAdapter(this IFixture fixture)
    {
        fixture.Register((IJsonValue jsonValue) => new PrimitiveAdapter(jsonValue));

        return fixture;
    }
}