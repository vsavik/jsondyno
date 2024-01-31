using System.Collections;
using Jsondyno.Adapters;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public sealed class ObjectAdapterCastTest
{
    private readonly Mock<IObject> _mock = new(MockBehavior.Strict);

    private readonly dynamic _adapter;

    public ObjectAdapterCastTest()
    {
        _adapter = new ObjectAdapter(_mock.Object);
    }

    [Fact]
    public void CastToDictionary()
    {
        // Arrange
        Dictionary<string, object?> expected = new(1);
        _mock.JsondynoSetupTypecast(x => x.GetDictionary(), expected);

        // Act
        Dictionary<string, object?> actual = _adapter;

        // Assert
        _mock.JsondynoVerifyTypecast(x => x.GetDictionary());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToHashtable()
    {
        // Arrange
        Hashtable expected = new(1);
        _mock.JsondynoSetupTypecast(x => x.GetHashtable(), expected);

        // Act
        Hashtable actual = _adapter;

        // Assert
        _mock.JsondynoVerifyTypecast(x => x.GetHashtable());
        actual.ShouldBe(expected);
    }
}