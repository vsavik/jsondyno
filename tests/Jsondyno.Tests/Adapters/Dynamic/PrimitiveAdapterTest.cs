using Jsondyno.Adapters;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public sealed class PrimitiveAdapterTest
{
    private readonly DynamicAdapterFixture<IPrimitive> _fixture = new();

    private readonly dynamic _adapter;

    private readonly Faker _faker;

    public PrimitiveAdapterTest(ITestOutputHelper output)
    {
        _adapter = new PrimitiveAdapter(_fixture.Mock.Object);
        int seed = Random.Shared.Next();
        _faker = new Faker
        {
            Random = new Randomizer(seed)
        };
        
        output.WriteLine($"Using seed: {seed}");
    }

    [Fact]
    public void CastToString()
    {
        // Arrange
        string expected = _faker.Lorem.Word();
        _fixture.SetupCast(x => x.AsString(), expected);

        // Act
        string actual = _adapter;
        int sd = _adapter;

        // Assert
        _fixture.Verify(x => x.AsString());
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test1()
    {
    }
}