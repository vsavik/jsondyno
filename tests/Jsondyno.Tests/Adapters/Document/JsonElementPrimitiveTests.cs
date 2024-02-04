using Jsondyno.Adapters.Document;

namespace Jsondyno.Tests.Adapters.Document;

public sealed class JsonElementPrimitiveTests :
    IClassFixture<FakerFixture>,
    IClassFixture<JsonFixture>
{
    private readonly Faker _faker;
    
    private readonly JsonFixture _json;
    
    private readonly ITestOutputHelper _output;

    public JsonElementPrimitiveTests(
        FakerFixture faker,
        JsonFixture json,
        ITestOutputHelper output)
    {
        _faker = faker;
        _json = json;
        _output = output;
        output.WriteLine($"Initializing Faker with seed: {faker.Seed}");
    }

    [Fact]
    public void Sampletest()
    {
        string jsonStr = _json.Builder
            .ObjectStart()
            .___.ArrayStart("arr")
            .___.___.Number(17)
            .___.___.Null()
            .___.ArrayEnd()
            .___.Property("test").Number(42)
            .ObjectEnd()
            .GetString();

        _output.WriteLine("test");
        _output.WriteLine(jsonStr);
        _output.WriteLine("test");
    }
}
