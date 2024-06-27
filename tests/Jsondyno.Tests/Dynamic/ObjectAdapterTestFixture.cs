using Jsondyno.Tests.Dynamic.Auxiliary;

namespace Jsondyno.Tests.Dynamic;

public sealed class ObjectAdapterTestFixture
{
    private readonly Mock<IJsonObject> _jsonObjectMock = new(MockBehavior.Strict);

    private readonly Fixture _fixture = new();

    public ObjectAdapterTestFixture()
    {
        _fixture.RegisterObjectAdapter(_jsonObjectMock);
    }

    // convert to struct, class
    // get property by key
    // get property by property name

    // replace cache
}