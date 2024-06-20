using System.Collections;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public static partial class ObjectAdapterTests
{
    public sealed class ClassMembers : IClassFixture<FakerFixture>
    {
        private const int MaxDataSize = 1024;

        private readonly Fixture _fixture;

        private readonly dynamic _adapter;

        private readonly Faker _faker;

        public ClassMembers(
            FakerFixture faker,
            ITestOutputHelper output)
        {
            _faker = faker;
            _fixture = Fixture.Create(this);
            _adapter = new ObjectAdapter(_fixture.Mock.Object);
            output.WriteLine($"Initializing Faker with seed: {faker.Seed}");
        }

        [Fact]
        public void CanGetCount()
        {
            int actual = _adapter.Count;
            actual.ShouldBe(_fixture.Data.Count);
        }

        [Fact]
        public void CanGetItemByKey()
        {
            (string key, object expected) = _faker.Random.CollectionItem(_fixture.Data);
            string actual = _adapter[key];
            actual.ShouldBe(expected);
        }

        [Fact]
        public void CanGetItemByProperty()
        {
            object expected = _faker.Lorem.Sentence();
            _fixture.Data["SampleProperty"] = expected;
            string actual = _adapter.SampleProperty;
            actual.ShouldBe(expected);
        }

        [Fact]
        public void CanApplyForeach()
        {
            foreach (KeyValuePair<string, object?> item in _adapter)
            {
                _fixture.Data.TryGetValue(item.Key, out object? expected).ShouldBeTrue();
                expected.ShouldBe(item.Value);
            }
        }

        private sealed class Fixture
        {
            private Fixture(Dictionary<string, object> data)
            {
                Data = data;
            }

            public Mock<IObject> Mock { get; } = new(MockBehavior.Strict);

            public Dictionary<string, object> Data { get; }

            public static Fixture Create(ClassMembers testContainer)
            {
                Dictionary<string, object> data = new(StringComparer.Ordinal);
                for (int i = 0; i < MaxDataSize; i++)
                {
                    string key = testContainer._faker.Random.String2(1, 20);
                    string value = testContainer._faker.Random.String(minChar: 'a', maxChar: 'z');
                    data[key] = value;
                }

                Fixture fixture = new(data);

                fixture.Mock.SetupGet(x => x.Count).Returns(data.Count);
                fixture.Mock.Setup(x => x.GetByKey(It.IsAny<string>())).Returns((string key) => data[key]);
                fixture.Mock.Setup(x => x.GetByRawKey(It.IsAny<string>())).Returns((string key) => data[key]);
                fixture.Mock.Setup(x => x.ConvertTo(It.Is<Type>(type => type == typeof(IEnumerable))))
                    .Returns(data);

                return fixture;
            }
        }
    }
}