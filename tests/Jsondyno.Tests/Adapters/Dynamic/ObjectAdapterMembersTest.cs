using Jsondyno.Adapters;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public sealed class ObjectAdapterMembersTest
{
    private const int MaxDataSize = 1024;

    private readonly Fixture _fixture;

    private readonly dynamic _adapter;

    private readonly Faker _faker;

    public ObjectAdapterMembersTest(ITestOutputHelper output)
    {
        _faker = Factory.CreateFaker(output);
        _fixture = Fixture.Create(this);
        _adapter = new ObjectAdapter(_fixture.Mock.Object);
    }

    [Fact]
    public void CanGetCount()
    {
        int actual = _adapter.Count;
        //actual.ShouldBe(_fixture.Data.Count);
        throw new NotImplementedException();
    }

    [Fact]
    public void CanGetItemByKey()
    {
        //int actual = _adapter.Count;
        //actual.ShouldBe(_fixture.Data.Count);
        throw new NotImplementedException();
    }

    [Fact]
    public void CanGetItemByProperty()
    {
        //int actual = _adapter.Count;
        //actual.ShouldBe(_fixture.Data.Count);
        throw new NotImplementedException();
    }

    private sealed class Fixture
    {
        private Fixture(IReadOnlyDictionary<string, object> data)
        {
            Data = data;
        }

        public Mock<IObject> Mock { get; } = new(MockBehavior.Strict);

        public IReadOnlyDictionary<string, object> Data { get; }

        public static Fixture Create(ObjectAdapterMembersTest testContainer)
        {
            Dictionary<string, object> data = new(StringComparer.Ordinal);
            for (int i = 0; i < MaxDataSize; i++)
            {
                string key = testContainer._faker.Random.String2(1, 20);
                string value = testContainer._faker.Random.String(minChar: 'a', maxChar: 'z');
                data[key] = value;
            }
            
            Fixture result = new(data);
            
            //result.Mock.Setup()
            
            return result;
        }
    }
}