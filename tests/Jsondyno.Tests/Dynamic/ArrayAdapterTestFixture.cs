using Jsondyno.Tests.Dynamic.Auxiliary;

namespace Jsondyno.Tests.Dynamic;

public sealed class ArrayAdapterTestFixture
{
    private readonly Mock<IJsonArray> _mock = new(MockBehavior.Strict);

    private readonly Fixture _fixture = new();

    public ArrayAdapterTestFixture()
    {
        _fixture.RegisterArrayAdapter(_mock);
    }

    [Theory]
    [InlineData(0)]
    [FixtureData<Auto>]
    public void VerifyArraySizeLoadingAndCaching([RandomInt32(Min = 1)] int expectedArraySize)
    {
        // Arrange
        _mock.InjectArraySize(expectedArraySize);
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        int actualLength = adapter.Length;
        int actualCount = adapter.Count;

        // Assert
        actualLength.ShouldBe(expectedArraySize);
        actualCount.ShouldBe(expectedArraySize);
        _mock.VerifyAll();
    }

    [Theory]
    [FixtureData<Auto>]
    public void VerifyTypeConversionToArray([RandomWords] string[] expectedArray)
    {
        // Arrange
        _fixture.Do<JsonSerializerOptions>(opts => _mock.InjectDeserializeResult(opts, expectedArray));
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        string[] actualArray = adapter;

        // Assert
        actualArray.ShouldBe(expectedArray);
        _mock.VerifyAll();
    }

    [Theory]
    [FixtureData<ArrayItemData>]
    public void VerifyItemsLoadingAndCaching(ArrayItem item1, ArrayItem item2)
    {
        // Arrange
        _mock.InjectArrayItems(item1, item2);
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        string actualItem1 = adapter[item1.Index];
        string actualItem1Cached = adapter[item1.Index];
        string actualItem2 = adapter[item2.Index];
        string actualItem1Reloaded = adapter[item1.Index];

        // Assert
        actualItem1.ShouldBe(item1.Value);
        actualItem1Cached.ShouldBe(item1.Value);
        actualItem2.ShouldBe(item2.Value);
        actualItem1Reloaded.ShouldBe(item1.Value);
        _mock.VerifyAll();
    }
}