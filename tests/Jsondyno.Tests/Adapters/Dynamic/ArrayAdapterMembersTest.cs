using System.Collections;
using Jsondyno.Adapters;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public sealed class ArrayAdapterMembersTest
{
    private const int MaxDataSize = 1024;

    private readonly DynamicArrayFixture _fixture;

    private readonly dynamic _adapter;

    private readonly Faker _faker;

    public ArrayAdapterMembersTest(ITestOutputHelper output)
    {
        _faker = Factory.CreateFaker(output);
        _fixture = DynamicArrayFixture.Create(this);
        _adapter = new ArrayAdapter(_fixture.Mock.Object);
    }

    [Fact]
    public void CanGetCount()
    {
        int actual = _adapter.Count;
        actual.ShouldBe(_fixture.Data.Count);
    }

    [Fact]
    public void CanGetCountByLengthProperty()
    {
        int actual = _adapter.Length;
        actual.ShouldBe(_fixture.Data.Count);
    }

    [Fact]
    public void CanGetItemByIndex()
    {
        int index = _faker.Random.Int(0, _fixture.Data.Count - 1);
        object expected = _fixture.Data[index];
        string actual = _adapter[index];
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CanApplyForeach()
    {
        int index = 0;
        foreach (string actual in _adapter)
        {
            object expected = _fixture.Data[index];
            actual.ShouldBe(expected);

            index++;
        }
    }

    private sealed class DynamicArrayFixture
    {
        private DynamicArrayFixture(IReadOnlyList<object> data)
        {
            Data = data;
        }

        public Mock<IArray> Mock { get; } = new(MockBehavior.Strict);

        public IReadOnlyList<object> Data { get; }

        public static DynamicArrayFixture Create(ArrayAdapterMembersTest testContainer)
        {
            int size = testContainer._faker.Random.Int(1, MaxDataSize);
            string[] data = testContainer._faker.Lorem.Words(size);
            DynamicArrayFixture fixture = new(data);

            fixture.Mock.SetupGet(x => x.Length).Returns(size);
            fixture.Mock.SetupGet(x => x.Count).Returns(size);

            fixture.Mock.Setup(x => x[It.Is((int index) => index >= 0 && index < size)])
                .Returns((int index) => data[index]);

            fixture.Mock.Setup(x => x.ConvertTo(It.Is<Type>(type => type == typeof(IEnumerable))))
                .Returns(data);

            return fixture;
        }
    }
}