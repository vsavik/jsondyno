using System.Collections;
using System.Collections.ObjectModel;
using Jsondyno.Adapters;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public sealed class ArrayAdapterCastTest
{
    private readonly Mock<IArray> _mock = new(MockBehavior.Strict);

    private readonly dynamic _adapter;

    private readonly Faker _faker;

    public ArrayAdapterCastTest(ITestOutputHelper output)
    {
        _adapter = new ArrayAdapter(_mock.Object);
        _faker = Factory.CreateFaker(output);
    }

    [Fact]
    public void CastToArray()
    {
        // Arrange
        object?[] expected = Array.Empty<object?>();
        _mock.JsondynoSetupTypecast(x => x.GetArray(), expected);

        // Act
        object?[] actual = _adapter;

        // Assert
        _mock.JsondynoVerifyTypecast(x => x.GetArray());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToList()
    {
        // Arrange
        List<object?> expected = new(1);
        _mock.JsondynoSetupTypecast(x => x.GetList(), expected);

        // Act
        List<object?> actual = _adapter;

        // Assert
        _mock.JsondynoVerifyTypecast(x => x.GetList());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToCollection()
    {
        // Arrange
        Collection<object?> expected = new();
        _mock.JsondynoSetupTypecast(x => x.GetCollection(), expected);

        // Act
        Collection<object?> actual = _adapter;

        // Assert
        _mock.JsondynoVerifyTypecast(x => x.GetCollection());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToArrayList()
    {
        // Arrange
        ArrayList expected = new(1);
        _mock.JsondynoSetupTypecast(x => x.GetArrayList(), expected);

        // Act
        ArrayList actual = _adapter;

        // Assert
        _mock.JsondynoVerifyTypecast(x => x.GetArrayList());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToLinkedList()
    {
        // Arrange
        LinkedList<object?> expected = new();
        _mock.JsondynoSetupTypecast(x => x.GetLinkedList(), expected);

        // Act
        LinkedList<object?> actual = _adapter;

        // Assert
        _mock.JsondynoVerifyTypecast(x => x.GetLinkedList());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToHashSet()
    {
        // Arrange
        HashSet<object?> expected = new(1);
        _mock.JsondynoSetupTypecast(x => x.GetHashSet(), expected);

        // Act
        HashSet<object?> actual = _adapter;

        // Assert
        _mock.JsondynoVerifyTypecast(x => x.GetHashSet());
        actual.ShouldBe(expected);
    }
}