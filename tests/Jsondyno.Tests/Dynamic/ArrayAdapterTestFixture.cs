using System.Reflection;
using AutoFixture.Kernel;
using Jsondyno.Internal;
using Jsondyno.Internal.Dynamic;
using Jsondyno.Tests.Dynamic.Auxiliary;

namespace Jsondyno.Tests.Dynamic;

public sealed class ArrayAdapterTestFixture : IClassFixture<SeedFixture>
{
    private readonly Mock<IJsonArray> _jsonArrayMock = new(MockBehavior.Strict);

    private readonly Fixture _fixture = new();

    public ArrayAdapterTestFixture()
    {
        _fixture.Inject(_jsonArrayMock.Object);
        _fixture.RegisterDynamicAdapters();
    }

    [Theory]
    [RandomFixtureData<Configuration>]
    public void VerifyArraySizeLoadingAndCaching(
        [RandomNumber<int>(Min = 22, Max = 23)]
        int expectedArraySize)
    {
        // Arrange
        _jsonArrayMock.SetExpectedArraySize(expectedArraySize);
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        int actualLength = adapter.Length;
        int actualCount = adapter.Count;

        // Assert
        actualLength.ShouldBe(expectedArraySize);
        actualCount.ShouldBe(expectedArraySize);
        _jsonArrayMock.VerifyAll();
    }

    [Theory]
    [RandomFixtureData<Configuration>]
    public void VerifyTypeConversionToArray(
        string[] expectedArray)
    {
        // Arrange
        _jsonArrayMock.SetExpectedArray(expectedArray);
        dynamic adapter = _fixture.Create<ArrayAdapter>();

        // Act
        string[] actualArray = adapter;

        // Assert
        actualArray.ShouldBe(expectedArray);
        _jsonArrayMock.VerifyAll();
    }

    [Theory]
    [RandomFixtureData<Configuration>]
    public void VerifyItemsLoadingAndCaching(
        [Customize<ExpectedIndex>] int index1,
        [Customize<ExpectedIndex>] int index2,
        string expectedItem1,
        string expectedItem2)
    {
        // Arrange
        _jsonArrayMock.SetExpectedArrayItems(index1, index2, expectedItem1, expectedItem2);
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

    public sealed class Configuration : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.RegisterRandomGenerators()
                .RegisterStringGenerator()
                .RegisterStringArrayGenerator();

            fixture.Register((Faker faker) => CreateIndexQueue(faker));
            fixture.Freeze<Queue<int>>();
        }

        private Queue<int> CreateIndexQueue(Faker faker) =>
            new(faker.Random.Shuffle(Enumerable.Range(0, 100)).Take(2));
    }

    public sealed class ExpectedIndex : ParameterCustomization<int>, IParameterCustomization
    {
        public ExpectedIndex(ParameterInfo parameter)
            : base(parameter)
        {
        }

        protected override int CreateParameterValue(ISpecimenContext context)
        {
            Queue<int> queue = context.Create<Queue<int>>();

            return queue.Dequeue();
        }

        public static ICustomization Create(ParameterInfo parameter) =>
            new ExpectedIndex(parameter);
    }
}