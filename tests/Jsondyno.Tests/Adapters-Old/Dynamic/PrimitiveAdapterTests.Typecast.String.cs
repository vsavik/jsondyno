namespace Jsondyno.Tests.Adapters.Dynamic;

public static partial class PrimitiveAdapterTests
{
    public sealed class TypecastString : Typecast
    {
        public TypecastString(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CastToString()
        {
            // Arrange
            string expected = Faker.Lorem.Word();
            Mock.JsondynoSetupTypecast(x => x.GetString(), expected);

            // Act
            string actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetString());
            actual.ShouldBe(expected);
        }

        [Fact]
        public void CastToBase64ByteArray()
        {
            // Arrange
            byte[] expected = Faker.Random.Bytes(16);
            Mock.JsondynoSetupTypecast(x => x.GetBytesFromBase64(), expected);

            // Act
            byte[] actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetBytesFromBase64());
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastGuid : Typecast
    {
        public TypecastGuid(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetGuid()
        {
            // Arrange
            Guid expected = Faker.Random.Uuid();
            Mock.JsondynoSetupTypecast(x => x.GetGuid(), expected);

            // Act
            Guid actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetGuid());
            actual.ShouldBe(expected);
        }

        [Fact]
        public void CanGetGuidNull()
        {
            // Arrange
            Guid expected = Faker.Random.Uuid();
            Mock.JsondynoSetupTypecast(x => x.GetGuid(), expected);

            // Act
            Guid? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetGuid());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }
}