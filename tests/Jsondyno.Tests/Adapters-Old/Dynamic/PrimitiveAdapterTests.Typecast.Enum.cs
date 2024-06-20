namespace Jsondyno.Tests.Adapters.Dynamic;

public static partial class PrimitiveAdapterTests
{
    public sealed class TypecastEnum : Typecast
    {
        public TypecastEnum(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetEnum()
        {
            // Arrange
            SampleEnum expected = Faker.Random.Enum<SampleEnum>();
            Mock.JsondynoSetupTypeConversion(expected);

            // Act
            SampleEnum actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypeConversion();
            actual.ShouldBe(expected);
        }

        [Fact]
        public void CanGetEnumNull()
        {
            // Arrange
            SampleEnum? expected = Faker.Random.Enum<SampleEnum>();
            Mock.JsondynoSetupTypeConversion(expected);

            // Act
            SampleEnum? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypeConversion();
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }

        private enum SampleEnum
        {
            None = 0,
            Value1,
            Value2,
            Value3
        }
    }
}