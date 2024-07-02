using Jsondyno.Tests.Dynamic.Auxiliary;

namespace Jsondyno.Tests.Dynamic;

[TestFixture]
public abstract class ObjectAdapterTestFixture
{
    private readonly Mock<IJsonObject> _mock = new(MockBehavior.Strict);

    private readonly dynamic _adapter;

    protected ObjectAdapterTestFixture(IFixture fixture)
    {
        fixture.Inject(_mock.Object);
        _adapter = fixture
            .Customize(new AdapterCustomization())
            .Create<ObjectAdapter>();
    }

    [TestFixtureSource(nameof(FixtureArgs))]
    public sealed class IndexerTestFixture : ObjectAdapterTestFixture
    {
        private readonly string _key;

        private readonly string? _value;

        public static Args[] FixtureArgs =>
        [
            Args.Create<string>(null).WithName("Null argument"),
            Args.Random(faker => faker.Random.String2(2, 6)).WithName("Random string")
        ];

        public IndexerTestFixture(string? value)
            : this(new Fixture(), value)
        {
        }

        public IndexerTestFixture(IFixture fixture, string? value)
            : base(fixture)
        {
            _key = fixture.Create<Faker>().Random.String2(1, 5);
            _value = value;

            ConfigureMock();
        }

        private void ConfigureMock()
        {
            _mock.Setup(jsonObject => jsonObject.GetProperty(_key))
                .Returns(CreateReturnValue)
                .Verifiable(Times.Once);
        }

        private IJsonValue? CreateReturnValue()
        {
            if (_value is null)
            {
                return null;
            }

            var itemMock = new Mock<IJsonValue>(MockBehavior.Strict);
            itemMock.Setup(jsonValue => jsonValue.ToDynamic())
                .Returns(new DynamicStub<string>(_value!));

            return itemMock.Object;
        }

        [Test, Order(1), Repeat(2)]
        public void VerifyItemIsLoadedByKey()
        {
            // Act
            string actualItem = _adapter[_key];

            // Assert
            actualItem.ShouldBe(_value);
        }

        [Test, Order(2)]
        public void VerifyNumberOfGetPropertyCalls()
        {
            // Assert
            _mock.VerifyAll();
        }
    }

    [TestFixtureSource(typeof(TypeConversionDataSource))]
    public sealed class TypeConversionTestFixture<T> : ObjectAdapterTestFixture
    {
        private readonly T _expectedValue;

        public TypeConversionTestFixture(T expectedValue)
            : base(new Fixture())
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