using System.Collections;
using Jsondyno.Adapters;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public sealed partial class ArrayAdapterTests
{
    public sealed class ClassMembers : IClassFixture<FakerFixture>
    {
        private const int MaxDataSize = 1024;

        private readonly ArrayFixture _fixture;

        private readonly dynamic _adapter;

        private readonly Faker _faker;

        public ClassMembers(
            FakerFixture faker,
            ITestOutputHelper output)
        {
            _faker = faker;
            _fixture = ArrayFixture.Create(this);
            _adapter = new ArrayAdapter(_fixture.Mock);
            output.WriteLine($"Initializing Faker with seed: {faker.Seed}");
        }

        [Fact]
        public void CanGetCount()
        {
            int actualCount = _adapter.Count;
            int actualLength = _adapter.Length;

            actualCount.ShouldBe(_fixture.Length);
            actualLength.ShouldBe(_fixture.Length);
        }

        [Fact]
        public void CanGetItemByIndex()
        {
            int index = _faker.Random.Int(0, _fixture.Length - 1);
            object expected = _fixture[index];
            string actual = _adapter[index];
            actual.ShouldBe(expected);
        }

        [Fact]
        public void CanApplyForeach()
        {
            int index = 0;
            foreach (string actual in _adapter)
            {
                object expected = _fixture[index];
                actual.ShouldBe(expected);

                index++;
            }
        }

        private sealed class ArrayFixture
        {
            private readonly Mock<IArray> _mock = new(MockBehavior.Strict);

            private readonly string[] _data;

            private ArrayFixture(string[] data)
            {
                _data = data;
                SetupMock();
            }

            public IArray Mock => _mock.Object;

            public int Length => _data.Length;

            public object this[int index] => _data[index];

            private void SetupMock()
            {
                _mock.SetupGet(x => x.Length).Returns(_data.Length);
                _mock.SetupGet(x => x.Count).Returns(_data.Length);

                _mock.Setup(x => x[It.Is((int index) => index >= 0 && index < _data.Length)])
                    .Returns((int index) => _data[index]);

                _mock.Setup(x => x.ConvertTo(It.Is<Type>(type => type == typeof(IEnumerable))))
                    .Returns(_data);
            }

            public static ArrayFixture Create(ClassMembers testContainer)
            {
                int size = testContainer._faker.Random.Int(1, MaxDataSize);
                string[] data = testContainer._faker.Lorem.Words(size);

                return new(data);
            }
        }
    }
}