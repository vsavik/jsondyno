using System.Reflection;
using Jsondyno.Tests.Dynamic.Auxiliary;
using Xunit.Sdk;

namespace Jsondyno.Tests.Misc;

[DataDiscoverer("AutoFixture.Xunit2.NoPreDiscoveryDataDiscoverer", "AutoFixture.Xunit2")]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class RandomClassDataAttribute<T> : DataAttribute
    where T : TheoryData
{
    private readonly Fixture _fixture = new();

    public RandomClassDataAttribute()
    {
        _fixture.Inject(new Faker());
        _fixture.RegisterRandomNumbers().RegisterRandomGenerators();
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        TheoryData data = _fixture.Create<T>();

        return data;
    }
}