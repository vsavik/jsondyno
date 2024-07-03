namespace Jsondyno.Tests.Dynamic;

public abstract class ArrayAdapterTestFixture
{
    private readonly Mock<IJsonArray> _mock = new(MockBehavior.Strict);

    private readonly dynamic _adapter;

    protected ArrayAdapterTestFixture(IFixture fixture)
    {
        _adapter = fixture
            .WithAdapterCustomization()
            .WithInstance(_mock.Object)
            .Create<ArrayAdapter>();
    }

    [TestFixtureSource(nameof(FixtureArgs))]
    public sealed class SizeTestFixture : ArrayAdapterTestFixture
    {
        private readonly int _size;

        public static Args[] FixtureArgs =>
        [
            Args.Create(0).WithName("Empty"),
            Args.Random(faker => faker.Random.Int(1)).WithName("Random")
        ];

        public SizeTestFixture(int size)
            : base(new Fixture())
        {
            _size = size;
            TestContext.WriteLine($"Expected array size is {size}");
            _mock.Setup(jsonArray => jsonArray.GetLength())
                .Returns(_size)
                .Verifiable(Times.Once);
        }

        [Test, Order(1)]
        public void VerifyAccessLengthProperty()
        {
            // Act
            int actualLength = _adapter.Length;

            // Assert
            actualLength.ShouldBe(_size);
        }

        [Test, Order(2)]
        public void VerifyAccessCountProperty()
        {
            // Act
            int actualCount = _adapter.Count;

            // Assert
            actualCount.ShouldBe(_size);
        }

        [Test, Order(3)]
        public void VerifySizeIsRequestedOnceThenCached()
        {
            // Assert
            _mock.VerifyAll();
        }
    }

    [TestFixture]
    public sealed class ArrayItemTestFixture : ArrayAdapterTestFixture
    {
        private readonly RandomArrayItems _items;

        public ArrayItemTestFixture()
            : this(new Fixture())
        {
        }

        private ArrayItemTestFixture(IFixture fixture)
            : base(fixture)
        {
            _items = fixture.Create<RandomArrayItems>();
            TestContext.WriteLine($"Expected items: {_items}");

            ConfigureMock(_items.Item1.Index, _items.Item1.Value, 2);
            ConfigureMock(_items.Item2.Index, _items.Item2.Value, 1);
        }

        private void ConfigureMock(int index, string value, int times)
        {
            _mock.Setup(jsonArray => jsonArray.GetElement(index))
                .Returns(value.ToJsonValue())
                .Verifiable(Times.Exactly(times));
        }

        [Test, Order(1)]
        public void VerifyGetItem1IsLoadedByIndex() =>
            VerifyItem(_items.Item1.Index, _items.Item1.Value);

        [Test, Order(2)]
        public void VerifItem1IsCached() =>
            VerifyItem(_items.Item1.Index, _items.Item1.Value);

        [Test, Order(3)]
        public void VerifyGetItem2IsLoadedByIndex() =>
            VerifyItem(_items.Item2.Index, _items.Item2.Value);

        [Test, Order(4)]
        public void VerifyGetItem1IsReloaded() =>
            VerifyItem(_items.Item1.Index, _items.Item1.Value);

        [Test, Order(5)]
        public void VerifyNumberOfGetElementCalls() =>
            _mock.VerifyAll();

        private void VerifyItem(int index, string expectedValue)
        {
            // Act
            string actualItem = _adapter[index];

            // Assert
            actualItem.ShouldBe(expectedValue);
        }
    }

    [TestFixtureSource(typeof(TypeConversionDataSource))]
    public sealed class TypeConversionTestFixture<T> : ArrayAdapterTestFixture
    {
        private readonly T _expectedValue;

        public TypeConversionTestFixture(T expectedValue)
            : base(new Fixture())
        {
            _expectedValue = expectedValue;
            _mock.Setup(jsonArray => jsonArray.Deserialize(typeof(T)))
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