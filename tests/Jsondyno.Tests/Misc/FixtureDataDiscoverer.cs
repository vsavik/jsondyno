using Xunit.Sdk;

namespace Jsondyno.Tests.Misc;

public sealed class FixtureDataDiscoverer : DataDiscoverer
{
    public override bool SupportsDiscoveryEnumeration(
        IAttributeInfo dataAttribute,
        IMethodInfo testMethod) => false;
}