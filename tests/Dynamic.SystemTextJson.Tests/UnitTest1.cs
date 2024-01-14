using Dynamic.SystemTextJson.Document;
using Xunit.Abstractions;

namespace Dynamic.SystemTextJson.Tests;

public class UnitTest1
{
    private readonly ITestOutputHelper output;

    public UnitTest1(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Test1()
    {
        JsonSerializer.Deserialize<JsonElement>("null");
    }
}

public sealed class SampleTests : IClassFixture<SampleTests.Fixture11>
{
    private readonly Fixture11 _f;
    
    public SampleTests(Fixture11 f)
    {
        _f = f;
    }
    
    
    public sealed class Fixture11
    {
        
    }
}