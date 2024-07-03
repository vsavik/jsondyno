namespace Jsondyno.Tests.Dynamic;

[TestFixture]
public abstract class ObjectAdapterTestFixture
{
    private readonly Mock<IJsonObject> _mock = new(MockBehavior.Strict);

    private readonly dynamic _adapter;

    protected ObjectAdapterTestFixture(IFixture fixture)
    {
        _adapter = fixture
            .WithObjectAdapter()
            .WithInstance(_mock.Object)
            .Create<ObjectAdapter>();
    }

    [TestFixtureSource(nameof(FixtureArgs))]
    public sealed class IndexerTestFixture : ObjectAdapterTestFixture
    {
        private readonly string _key;

        private readonly string? _value;

        public static Args[] FixtureArgs =>
        [
            //Args.Create<string>(null).WithName("Property is null"),
            //Args.Random(faker => faker.Random.String2(2, 6)).WithName("Property is random string")
        ];

        public IndexerTestFixture(string? value)
            : this(new Fixture(), value)
        {
        }

        private IndexerTestFixture(IFixture fixture, string? value)
            : base(fixture)
        {
            _key = fixture.Create<Faker>().Random.String2(1, 5);
            _value = value;

            ConfigureMock();
        }

        private void ConfigureMock()
        {
            _mock.Setup(jsonObject => jsonObject.GetProperty(_key))
                .Returns(_value.ToJsonValue())
                .Verifiable(Times.Once);
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

    //[TestFixtureSource(nameof(FixtureArgs))]
    public sealed class PropertyTestFixture : ObjectAdapterTestFixture
    {
        public PropertyTestFixture(IFixture fixture)
            : base(fixture)
        {
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
                .Returns(_expectedValue)
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

file static class Extensions
{
    public static IFixture WithObjectAdapter(this IFixture fixture)
    {
        fixture.Inject<JsonNamingPolicy?>(null);
        fixture.Register((IJsonObject jsonObject, JsonNamingPolicy? policy) =>
            new ObjectAdapter(jsonObject, policy));

        return fixture;
    }
}