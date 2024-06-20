namespace Jsondyno.Tests.Adapters.Dynamic;

public static partial class PrimitiveAdapterTests
{
    public sealed class TypecastDate : Typecast
    {
        private static readonly DateTimeOffset s_refDate =
            new(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);

        public TypecastDate(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetDateTime()
        {
            // Arrange
            DateTime expected = Faker.Date.Past(refDate: s_refDate.DateTime);
            Mock.JsondynoSetupTypecast(x => x.GetDateTime(), expected);

            // Act
            DateTime actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetDateTime());
            actual.ShouldBe(expected);
        }

        [Fact]
        public void CanGetDateTimeNull()
        {
            // Arrange
            DateTime expected = Faker.Date.Past(refDate: s_refDate.DateTime);
            Mock.JsondynoSetupTypecast(x => x.GetDateTime(), expected);

            // Act
            DateTime? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetDateTime());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }

        [Fact]
        public void CanGetDateTimeOffset()
        {
            // Arrange
            DateTimeOffset expected = Faker.Date.PastOffset(refDate: s_refDate);
            Mock.JsondynoSetupTypecast(x => x.GetDateTimeOffset(), expected);

            // Act
            DateTimeOffset actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetDateTimeOffset());
            actual.ShouldBe(expected);
        }

        [Fact]
        public void CanGetDateTimeOffsetNull()
        {
            // Arrange
            DateTimeOffset expected = Faker.Date.PastOffset(refDate: s_refDate);
            Mock.JsondynoSetupTypecast(x => x.GetDateTimeOffset(), expected);

            // Act
            DateTimeOffset? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetDateTimeOffset());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }
}