using System.Collections;
using Jsondyno.Adapters;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public sealed class ArrayAdapterTest
{
    private readonly DynamicAdapterFixture<IArray> _fixture = new();

    private readonly dynamic _adapter;

    private readonly Faker _faker;

    public ArrayAdapterTest(ITestOutputHelper output)
    {
        _adapter = new ArrayAdapter(_fixture.Mock.Object);
        int seed = Random.Shared.Next();
        _faker = new Faker { Random = new Randomizer(seed) };
        output.WriteLine($"Using seed: {seed}");
    }

    [Fact]
    public void CastToArray()
    {
        // Arrange
        object?[] expected = Array.Empty<object?>();
        _fixture.SetupCast(x => x.GetArray(), expected);

        // Act
        object?[] actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetArray());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToList()
    {
        // Arrange
        List<object?> expected = new(1);
        _fixture.SetupCast(x => x.GetList(), expected);

        // Act
        List<object?> actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetList());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToArrayList()
    {
        // Arrange
        ArrayList expected = new(1);
        _fixture.SetupCast(x => x.GetArrayList(), expected);

        // Act
        ArrayList actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetArrayList());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToLinkedList()
    {
        // Arrange
        LinkedList<object?> expected = new();
        _fixture.SetupCast(x => x.GetLinkedList(), expected);

        // Act
        LinkedList<object?> actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetLinkedList());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToHashSet()
    {
        // Arrange
        HashSet<object?> expected = new(1);
        _fixture.SetupCast(x => x.GetHashSet(), expected);

        // Act
        HashSet<object?> actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetHashSet());
        actual.ShouldBe(expected);
    }
}