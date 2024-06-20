using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public static partial class PrimitiveAdapterTests
{
    public abstract class Typecast : IClassFixture<FakerFixture>
    {
        protected Typecast(
            FakerFixture faker,
            ITestOutputHelper output)
        {
            Faker = faker;
            Adapter = new PrimitiveAdapter(Mock.Object);
            output.WriteLine($"Initializing Faker with seed: {faker.Seed}");
        }

        private protected Mock<IPrimitive> Mock { get; } = new(MockBehavior.Strict);

        protected dynamic Adapter { get; }

        protected Faker Faker { get; }
    }
}