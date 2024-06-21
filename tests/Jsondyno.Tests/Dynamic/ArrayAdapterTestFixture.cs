using Jsondyno.Internal;
using Jsondyno.Internal.Dynamic;

namespace Jsondyno.Tests.Dynamic;

public sealed class ArrayAdapterTestFixture : IClassFixture<SeedFixture>
{
    private readonly Mock<IJsonArray> _jsonArrayMock = new(MockBehavior.Strict);

    private readonly Fixture _fixture = new();

    private readonly Faker _faker;

    public ArrayAdapterTestFixture(
        SeedFixture seedFixture,
        ITestOutputHelper output)
    {
        _faker = seedFixture.CreateFaker(output);
        _fixture.Inject(JsonSerializerOptions.Default);
        _fixture.Register((JsonSerializerOptions opts) => new Context(opts));
        _fixture.Register((Context context) => new ArrayAdapter(_jsonArrayMock.Object, context));
    }

    [Fact]
    public void AssertArraySizeLoading()
    {
        // Arrange
        ExpectedArraySize expected = new(this);
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        int actualLength = adapter.Length;
        int actualCount = adapter.Count;

        // Assert
        actualLength.ShouldBe(expected.Size);
        actualCount.ShouldBe(expected.Size);
        _jsonArrayMock.VerifyAll();
    }

    [Fact]
    public void AssertTypeConversion()
    {
        // Arrange
        ExpectedArrayType expected = new(this);
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        string[] actualWords = adapter;

        // Assert
        actualWords.ShouldBe(expected.Words);
        _jsonArrayMock.VerifyAll();
    }

    [Fact]
    public void AssertArrayItemLoading()
    {
        // Arrange
        ExpectedArrayItems expected = new(this);
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        string actualItem1 = adapter[expected.Index1];
        string actualItem1Cached = adapter[expected.Index1];
        string actualItem2 = adapter[expected.Index2];
        string actualItem1Reloaded = adapter[expected.Index1];

        // Assert
        actualItem1.ShouldBe(expected.ExpectedItem1);
        actualItem1Cached.ShouldBe(expected.ExpectedItem1);
        actualItem2.ShouldBe(expected.ExpectedItem2);
        actualItem1Reloaded.ShouldBe(expected.ExpectedItem1);
        _jsonArrayMock.VerifyAll();
    }

    private sealed class ExpectedArraySize : ICustomization
    {
        private readonly Mock<IJsonArray> _mock;

        public ExpectedArraySize(ArrayAdapterTestFixture testFixture)
        {
            _mock = testFixture._jsonArrayMock;
            Size = testFixture._faker.Random.Int(0);
            testFixture._fixture.Customize(this);
        }

        public int Size { get; }

        public void Customize(IFixture fixture)
        {
            _mock.Setup(jsonArray => jsonArray.GetLength())
                .Returns(Size)
                .Verifiable(Times.Once, "Caching doesn't work.");
        }
    }

    private sealed class ExpectedArrayType : ICustomization
    {
        private readonly Mock<IJsonArray> _mock;

        public ExpectedArrayType(ArrayAdapterTestFixture testFixture)
        {
            _mock = testFixture._jsonArrayMock;
            Words = testFixture._faker.Random.WordsArray(10)!;
            testFixture._fixture.Customize(this);
        }

        public string[] Words { get; }

        public void Customize(IFixture fixture)
        {
            _mock.Setup(jsonArray => jsonArray.Deserialize(typeof(string[]), It.IsAny<JsonSerializerOptions>()))
                .Returns(Words)
                .Verifiable(Times.Once);
        }
    }

    private sealed class ExpectedArrayItems : ICustomization
    {
        private readonly Mock<IJsonArray> _mock;

        public ExpectedArrayItems(ArrayAdapterTestFixture testFixture)
        {
            _mock = testFixture._jsonArrayMock;
            Index1 = testFixture._faker.Random.Int(0, 9);
            Index2 = testFixture._faker.Random.Int(10, 20);
            ExpectedItem1 = testFixture._faker.Random.String2(10);
            ExpectedItem2 = testFixture._faker.Random.String2(10);
            testFixture._fixture.Customize(this);
        }

        public int Index1 { get; }

        public int Index2 { get; }

        public string ExpectedItem1 { get; }

        public string ExpectedItem2 { get; }

        public void Customize(IFixture fixture)
        {
            _mock.Setup(jsonArray => jsonArray.GetArrayElement(Index1))
                .Returns(CreateJsonValueMock(ExpectedItem1))
                .Verifiable(Times.Exactly(2));

            _mock.Setup(jsonArray => jsonArray.GetArrayElement(Index2))
                .Returns(CreateJsonValueMock(ExpectedItem2))
                .Verifiable(Times.Once);
        }

        private IJsonValue CreateJsonValueMock(string expected)
        {
            var mock = new Mock<IJsonValue>(MockBehavior.Strict);
            mock.Setup(jsonValue => jsonValue.ToDynamic(It.IsAny<Context>()))
                .Returns(expected);

            return mock.Object;
        }
    }
}