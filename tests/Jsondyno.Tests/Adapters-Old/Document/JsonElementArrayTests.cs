using Jsondyno.Adapters.Document;
using Jsondyno.Adapters.Dynamic;
using Jsondyno.Tests.Fixtures.JsonBuilder;

namespace Jsondyno.Tests.Adapters.Document;

public sealed class JsonElementArrayTests :
    IClassFixture<FakerFixture>,
    IDisposable
{
    private readonly JsonFixture _json = new();

    private readonly Faker _faker;

    private readonly string[] _data;

    private readonly JsonElementArray _sut;

    public JsonElementArrayTests(
        FakerFixture faker,
        ITestOutputHelper output)
    {
        _faker = faker;
        (_data, _sut) = CreateSut();

        output.WriteLine($"Initializing Faker with seed: {faker.Seed}");
    }

    private (string[], JsonElementArray) CreateSut()
    {
        string[] data = _faker.Lorem.Words(10);
        JsonElementArray array = data.Aggregate(
            _json.Builder.ArrayStart(),
            (builder, str) => builder.String(str),
            builder => builder.ArrayEnd().CreateJsonElementArray());

        return (data, array);
    }

    [Fact]
    public void IsArrayLengthCorrect()
    {
        // Assert
        _sut.Length.ShouldBe(_data.Length);
    }

    [Fact]
    public void CanApplyForeach()
    {
        // Act
        string[] actual = _sut
            .Cast<PrimitiveAdapter?>()
            .Select(x => (string)x!)
            .ToArray();

        // Assert
        actual.ShouldBe(_data);
    }

    [Fact]
    public void CanAccessByIndex()
    {
        // Act
        int index = _faker.Random.Int(0, _data.Length - 1);
        string actual = ((PrimitiveAdapter?)_sut[index])!;

        // Assert
        actual.ShouldBe(_data[index]);
    }

    [Fact]
    public void CanConvertToArray()
    {
        // Act
        string[] actual = _sut.GetArray()
            .Cast<PrimitiveAdapter?>()
            .Select(x => (string)x!)
            .ToArray();

        actual.ShouldBe(_data);
    }

    [Fact]
    public void CanConvertToList()
    {
        // Act
        string[] actual = _sut.GetList()
            .Cast<PrimitiveAdapter?>()
            .Select(x => (string)x!)
            .ToArray();

        actual.ShouldBe(_data);
    }

    [Fact]
    public void CanConvertToCollection()
    {
        // Act
        string[] actual = _sut.GetCollection()
            .Cast<PrimitiveAdapter?>()
            .Select(x => (string)x!)
            .ToArray();

        actual.ShouldBe(_data);
    }

    [Fact]
    public void CanConvertToArrayList()
    {
        // Act
        string[] actual = _sut.GetArrayList()
            .Cast<PrimitiveAdapter?>()
            .Select(x => (string)x!)
            .ToArray();

        actual.ShouldBe(_data);
    }

    [Fact]
    public void CanConvertToLinkedList()
    {
        // Act
        string[] actual = _sut.GetLinkedList()
            .Cast<PrimitiveAdapter?>()
            .Select(x => (string)x!)
            .ToArray();

        actual.ShouldBe(_data);
    }

    [Fact]
    public void CanConvertToHasSet()
    {
        // Act
        string[] actual = _sut.GetHashSet()
            .Cast<PrimitiveAdapter?>()
            .Select(x => (string)x!)
            .ToArray();

        actual.ShouldBe(_data);
    }

    public void Dispose() => _json.Dispose();
}