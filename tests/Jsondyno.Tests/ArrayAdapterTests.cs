namespace Jsondyno.Tests;

[TestFixture(TestOf = typeof(ArrayAdapter))]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class ArrayAdapterTests
{
    private readonly AdapterFixture _fixture = new();

    [Test]
    public void Length_ShouldReturnJsonArraySize_WhenRequestedAdapterSize()
    {
        // Arrange
        int expectedSize = _fixture.CreateArraySize();
        dynamic adapter = _fixture.CreateAdapter();

        // Act
        int actualLength = adapter.Length;

        // Assert
        actualLength.ShouldBe(expectedSize);
    }

    [Test]
    public void Count_ShouldReturnJsonArraySize_WhenRequestedAdapterSize()
    {
        // Arrange
        int expectedSize = _fixture.CreateArraySize();
        dynamic adapter = _fixture.CreateAdapter();

        // Act
        int actualCount = adapter.Count;

        // Assert
        actualCount.ShouldBe(expectedSize);
    }

    [Test]
    public void Length_ShouldBeCached_WhenRequestedAdapterSizeMultipleTimes()
    {
        // Arrange
        ArrayAdapter adapter = _fixture.CreateAdapterWithCachedSize();

        // Act
        _ = adapter.Length;

        // Assert
        A.CallTo(() => _fixture.FakeArray.GetLength()).MustNotHaveHappened();
    }

    [Test]
    public void Count_ShouldBeCached_WhenRequestedAdapterSizeMultipleTimes()
    {
        // Arrange
        ArrayAdapter adapter = _fixture.CreateAdapterWithCachedSize();

        // Act
        _ = adapter.Count;

        // Assert
        A.CallTo(() => _fixture.FakeArray.GetLength()).MustNotHaveHappened();
    }

    [Test]
    public void GetItemByIndex_ShouldReturnElement_WhenRequestedElementByndex()
    {
        // Arrange
        int index = _fixture.GetIndex();
        object expectedItem = _fixture.SetupArrayElement();
        dynamic adapter = _fixture.CreateAdapter();

        // Act
        object actualItem = adapter[index];

        // Assert
        actualItem.ShouldBe(expectedItem);
    }

    [Test]
    public void GetItemByIndex_ShouldRequestElementWithIndex_WhenRequestedElementByndex()
    {
        // Arrange
        int index = _fixture.GetIndex();
        ArrayAdapter adapter = _fixture.CreateAdapterWithElement();

        // Act
        _ = adapter[index];

        // Assert
        A.CallTo(() => _fixture.FakeArray.GetElement(index)).MustHaveHappenedOnceExactly();
    }

    [Test]
    public void GetItemByIndex_ShouldReturnCachedElement_WhenSameIndexWasRequestedAgain()
    {
        // Arrange
        int index = _fixture.GetIndex();
        ArrayAdapter adapter = _fixture.CreateAdapterWithCachedElement();

        // Act
        _ = adapter[index];

        // Assert
        A.CallTo(() => _fixture.FakeArray.GetElement(An<int>._)).MustNotHaveHappened();
    }

    [Test]
    public void GetItemByIndex_ShouldRequestElementWithIndex_WhenElementOtherThanCachedWasRequested()
    {
        // Arrange
        int index = _fixture.GetIndex();
        ArrayAdapter adapter = _fixture.CreateAdapterWithAlternativeCachedElement();

        // Act
        _ = adapter[index];

        // Assert
        A.CallTo(() => _fixture.FakeArray.GetElement(index)).MustHaveHappenedOnceExactly();
    }

    private sealed class AdapterFixture
    {
        private const int TestIndex = 17;

        private const int AlternativeIndex = 11;

        public IJsonArray FakeArray { get; } = A.Fake<IJsonArray>(opts => opts.Strict());

        public ArrayAdapter CreateAdapter() => new(FakeArray);

        public int CreateArraySize()
        {
            const int size = 42;
            TestContext.WriteLine($"Array length is set to {size}.");
            A.CallTo(() => FakeArray.GetLength()).Returns(size);

            return size;
        }

        public ArrayAdapter CreateAdapterWithCachedSize()
        {
            CreateArraySize();
            ArrayAdapter adapter = CreateAdapter();
            TestContext.WriteLine("Array length is cached.");
            _ = adapter.Length;
            Fake.ClearRecordedCalls(FakeArray);

            return adapter;
        }

        public int GetIndex()
        {
            TestContext.WriteLine($"Index to test is {TestIndex}.");

            return TestIndex;
        }

        public object SetupArrayElement()
        {
            TestContext.WriteLine("Array element is a not null stub.");
            DynamicStub stub = new();
            IJsonValue jsonValueStub = A.Fake<IJsonValue>();
            A.CallTo(() => jsonValueStub.ToDynamic()).Returns(stub);
            A.CallTo(() => FakeArray.GetElement(An<int>._)).Returns(jsonValueStub);

            return stub;
        }

        public ArrayAdapter CreateAdapterWithElement()
        {
            TestContext.WriteLine("Fake IJsonArray returns null for any element.");
            A.CallTo(() => FakeArray.GetElement(An<int>._)).Returns(null);

            return CreateAdapter();
        }

        public ArrayAdapter CreateAdapterWithCachedElement()
        {
            ArrayAdapter adapter = CreateAdapterWithElement();
            _ = adapter[TestIndex];
            TestContext.WriteLine($"ArrayAdapter item {TestIndex} is cached.");
            Fake.ClearRecordedCalls(FakeArray);

            return adapter;
        }

        public ArrayAdapter CreateAdapterWithAlternativeCachedElement()
        {
            ArrayAdapter adapter = CreateAdapterWithElement();
            _ = adapter[AlternativeIndex];
            TestContext.WriteLine($"ArrayAdapter item {AlternativeIndex} is cached.");
            Fake.ClearRecordedCalls(FakeArray);

            return adapter;
        }
    }
}