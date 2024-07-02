using Jsondyno.Tests.Dynamic.Auxiliary;

namespace Jsondyno.Tests.Dynamic;

[TestFixture]
public abstract class ObjectAdapterTestFixture
{
    private readonly Mock<IJsonObject> _mock = new(MockBehavior.Strict);

    private readonly dynamic _adapter;

    protected ObjectAdapterTestFixture()
        : this(new Fixture())
    {
    }

    protected ObjectAdapterTestFixture(IFixture fixture)
    {
        fixture.Inject(_mock.Object);
        _adapter = fixture
            .Customize(new AdapterCustomization())
            .Create<ObjectAdapter>();
    }

    // indexer
    // - case sensitive
    // - case insensitive
    // property

    [TestFixtureSource(typeof(TypeConversionDataSource))]
    public sealed class TypeConversionTestFixture<T> : ObjectAdapterTestFixture
    {
        private readonly T _expectedValue;

        public TypeConversionTestFixture(T expectedValue)
        {
            _expectedValue = expectedValue;
            _mock.Setup(jsonObject => jsonObject.Deserialize(typeof(T)))
                .Returns(() => _expectedValue)
                .Verifiable(Times.Once);
        }

        [Test]
        public void VerifyTypeConversion()
        {
            // Act
            T actual = _adapter;

            // Assert
            actual.ShouldBe(_expectedValue);
            _mock.VerifyAll();
        }
    }
}