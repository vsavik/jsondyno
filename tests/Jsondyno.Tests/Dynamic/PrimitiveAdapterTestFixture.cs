using Jsondyno.Tests.Dynamic.Auxiliary;

namespace Jsondyno.Tests.Dynamic;

[TestFixtureSource(typeof(TypeConversionDataSource))]
public sealed class PrimitiveAdapterTestFixture<T>
{
    private readonly Mock<IJsonValue> _mock = new(MockBehavior.Strict);

    private readonly ReloadSample _expectedReloadValue = new();

    private readonly T _expectedValue;

    private readonly dynamic _adapter;

    public PrimitiveAdapterTestFixture(T expectedValue)
    {
        _expectedValue = expectedValue;

        IFixture fixture = new Fixture().Customize(new AdapterCustomization());
        fixture.Inject(_mock.Object);
        _adapter = fixture.Create<PrimitiveAdapter>();

        ConfigureMock();
    }

    private void ConfigureMock()
    {
        _mock.Setup(jsonValue => jsonValue.Deserialize(typeof(T)))
            .Returns(_expectedValue)
            .Verifiable(Times.Once);

        _mock.Setup(jsonValue => jsonValue.Deserialize(typeof(ReloadSample)))
            .Returns(_expectedReloadValue)
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
        ReloadSample actual = _adapter;

        // Assert
        actual.ShouldBe(_expectedReloadValue);
    }

    [Test, Order(3)]
    public void VerifyDeserialzieCallsCount()
    {
        // Assert
        _mock.VerifyAll();
    }

    private sealed class ReloadSample
    {
    }
}