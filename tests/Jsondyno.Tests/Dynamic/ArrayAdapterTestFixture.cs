using Jsondyno.Tests.Dynamic.Auxiliary;

namespace Jsondyno.Tests.Dynamic;

public abstract class ArrayAdapterTestFixture
{
    private readonly Mock<IJsonArray> _mock = new(MockBehavior.Strict);

    private readonly dynamic _adapter;

    protected ArrayAdapterTestFixture()
        : this(new Fixture())
    {
    }

    protected ArrayAdapterTestFixture(IFixture fixture)
    {
        fixture.Inject(_mock.Object);
        _adapter = fixture
            .Customize(new AdapterCustomization())
            .Create<ArrayAdapter>();
    }

    [TestFixtureSource(nameof(FixtureArgs))]
    public sealed class SizeTestFixture : ArrayAdapterTestFixture
    {
        private readonly int _size;

        public static Args[] FixtureArgs =>
        [
            Args.Create(0).WithName("Empty array"),
            Args.Random(faker => faker.Random.Int(1)).WithName("Random size")
        ];

        public SizeTestFixture(int size)
            : base(new Fixture())
        {
            TestContext.WriteLine($"Expected array size is {size}");
            _size = size;
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
    public sealed class ArrayItemTestFixture : ArrayAdapterTestFixture, ICustomization
    {
        private readonly ArrayItem _item1;

        private readonly ArrayItem _item2;

        public ArrayItemTestFixture()
            : this(new Fixture())
        {
        }

        private ArrayItemTestFixture(IFixture fixture)
            : base(fixture)
        {
            fixture.Customize(this);
            _item1 = fixture.Create<ArrayItem>();
            _item2 = fixture.Create<ArrayItem>();
            TestContext.WriteLine(
                $"Expected items: [{_item1.Index}]=\'{_item1.Value}\', [{_item2.Index}]=\'{_item2.Value}\'");

            ConfigureMocks();
        }

        private void ConfigureMocks()
        {
            var itemMock = new Mock<IJsonValue>(MockBehavior.Strict);
            itemMock
                .SetupSequence(jsonValue => jsonValue.ToDynamic())
                .Returns(new DynamicStub(_item1.Value))
                .Returns(new DynamicStub(_item2.Value))
                .Returns(new DynamicStub(_item1.Value));

            _mock.Setup(jsonArray => jsonArray.GetElement(_item1.Index))
                .Returns(itemMock.Object)
                .Verifiable(Times.Exactly(2));

            _mock.Setup(jsonArray => jsonArray.GetElement(_item2.Index))
                .Returns(itemMock.Object)
                .Verifiable(Times.Once);
        }

        [Test, Order(1)]
        public void VerifyGetItem1IsLoadedByIndex() =>
            VerifyItem(_item1);

        [Test, Order(2)]
        public void VerifItem1IsCached() =>
            VerifyItem(_item1);

        [Test, Order(3)]
        public void VerifyGetItem2IsLoadedByIndex() =>
            VerifyItem(_item2);

        [Test, Order(4)]
        public void VerifyGetItem1IsReloaded() =>
            VerifyItem(_item1);

        [Test, Order(5)]
        public void VerifyNumberOfGetElementCalls() =>
            _mock.VerifyAll();

        private void VerifyItem(ArrayItem item)
        {
            // Act
            string actualItem = _adapter[item.Index];

            // Assert
            actualItem.ShouldBe(item.Value);
        }

        public void Customize(IFixture fixture)
        {
            Faker faker = fixture.Create<Faker>();
            Queue<int> queue = new(faker.Random.Shuffle(Enumerable.Range(0, 100)).Take(2));
            fixture.Register(() => new ArrayItem(queue.Dequeue(), faker.Random.String2(2, 8)));
        }

        private record ArrayItem(int Index, string Value);
    }

    [TestFixtureSource(typeof(TypeConversionDataSource))]
    public sealed class TypeConversionTestFixture<T> : ArrayAdapterTestFixture
    {
        private readonly T _expectedValue;

        public TypeConversionTestFixture(T expectedValue)
        {
            _expectedValue = expectedValue;
            _mock.Setup(jsonArray => jsonArray.Deserialize(typeof(T)))
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