namespace Jsondyno.Tests.Adapters.Dynamic;

public static partial class PrimitiveAdapterTests
{
    public sealed class TypecastBoolean : Typecast
    {
        public TypecastBoolean(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetBoolean()
        {
            // Arrange
            bool expected = Faker.Random.Bool();
            Mock.JsondynoSetupTypecast(x => x.GetBoolean(), expected);

            // Act
            bool actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetBoolean());
            actual.ShouldBe(expected);
        }

        [Fact]
        public void CanGetBooleanNull()
        {
            // Arrange
            bool expected = Faker.Random.Bool();
            Mock.JsondynoSetupTypecast(x => x.GetBoolean(), expected);

            // Act
            bool? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetBoolean());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }
}