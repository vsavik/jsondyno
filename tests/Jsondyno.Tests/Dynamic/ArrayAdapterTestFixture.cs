using Jsondyno.Internal;
using Jsondyno.Internal.Dynamic;

namespace Jsondyno.Tests.Dynamic;

public sealed class ArrayAdapterTestFixture : IClassFixture<SeedFixture>
{
    private readonly Mock<IJsonArray> _jsonArrayMock = new(MockBehavior.Strict);

    private readonly Fixture _fixture = new();

    public ArrayAdapterTestFixture(
        SeedFixture seedFixture,
        ITestOutputHelper output)
    {
        _fixture.Inject(output);
        _fixture.Register((ITestOutputHelper o) => seedFixture.CreateFaker(o));
        _fixture.Inject(JsonSerializerOptions.Default);
        _fixture.Register(() => new Context(JsonSerializerOptions.Default));
        _fixture.Register((Context context) => new ArrayAdapter(_jsonArrayMock.Object, context));
        _fixture.Register(AsFunc(ConfigureExpectedArraySize));
        _fixture.Register(AsFunc(ConfigureExpectedConversionArray));
        _fixture.Register(AsFunc(ConfigureExpectedArrayItems));
    }

    private int ConfigureExpectedArraySize(
        ITestOutputHelper output,
        Faker faker)
    {
        int size = faker.Random.Int(0);
        
        output.WriteLine($"Expected array size is {size}.");

        _jsonArrayMock.Setup(jsonArray => jsonArray.GetLength())
            .Returns(size)
            .Verifiable(Times.Once, "Caching doesn't work.");

        return size;
    }

    private string[] ConfigureExpectedConversionArray(
        ITestOutputHelper output,
        Faker faker)
    {
        string[] words = faker.Random.WordsArray(10)!;
        JsonSerializerOptions opts = _fixture.Create<JsonSerializerOptions>();

        output.WriteLine($"Expected array is '{String.Join(", ", words)}'.");

        _jsonArrayMock.Setup(jsonArray => jsonArray.Deserialize(typeof(string[]), opts))
            .Returns(words)
            .Verifiable(Times.Once);

        return words;
    }

    private (int, int, string, string) ConfigureExpectedArrayItems(
        ITestOutputHelper output,
        Faker faker)
    {
        int index1 = faker.Random.Int(0, 99);
        int index2 = faker.Random.Int(0, 99);
        index1 = index1 == index2 ? index2 + 1 : index1;
        string item1 = faker.Random.String2(10);
        string item2 = faker.Random.String2(10);

        output.WriteLine($"Expected array item [{index1}] is {item1}, item [{index2}] is {item2}.");

        _jsonArrayMock.Setup(jsonArray => jsonArray.GetArrayElement(index1))
            .Returns(CreateJsonValueMock(item1))
            .Verifiable(Times.Exactly(2));

        _jsonArrayMock.Setup(jsonArray => jsonArray.GetArrayElement(index2))
            .Returns(CreateJsonValueMock(item2))
            .Verifiable(Times.Once);

        return (index1, index2, item1, item2);
    }

    private IJsonValue CreateJsonValueMock(string expected)
    {
        var mock = new Mock<IJsonValue>(MockBehavior.Strict);
        mock.Setup(jsonValue => jsonValue.ToDynamic(It.IsAny<Context>()))
            .Returns(expected);

        return mock.Object;
    }

    [Fact]
    public void VerifyArraySizeLoadingAndCaching()
    {
        // Arrange
        int expectedSize = _fixture.Create<int>();
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        int actualLength = adapter.Length;
        int actualCount = adapter.Count;

        // Assert
        actualLength.ShouldBe(expectedSize);
        actualCount.ShouldBe(expectedSize);
        _jsonArrayMock.VerifyAll();
    }

    [Fact]
    public void VerifyTypeConversionToArray()
    {
        // Arrange
        string[] expectedArray = _fixture.Create<string[]>();
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        string[] actualArray = adapter;

        // Assert
        actualArray.ShouldBe(expectedArray);
        _jsonArrayMock.VerifyAll();
    }

    [Fact]
    public void VerifyItemsLoadingAndCaching()
    {
        // Arrange
        (int index1, int index2,
            string expectedItem1,
            string expectedItem2) = _fixture.Create<(int, int, string, string)>();
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        string actualItem1 = adapter[index1];
        string actualItem1Cached = adapter[index1];
        string actualItem2 = adapter[index2];
        string actualItem1Reloaded = adapter[index1];

        // Assert
        actualItem1.ShouldBe(expectedItem1);
        actualItem1Cached.ShouldBe(expectedItem1);
        actualItem2.ShouldBe(expectedItem2);
        actualItem1Reloaded.ShouldBe(expectedItem1);
        _jsonArrayMock.VerifyAll();
    }
}