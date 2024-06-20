using System.Collections;
using System.Collections.ObjectModel;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public static partial class ArrayAdapterTests
{
    public sealed class Typecast
    {
        private readonly Mock<IArray> _mock = new(MockBehavior.Strict);

        private readonly dynamic _adapter;

        public Typecast()
        {
            _adapter = new ArrayAdapter(_mock.Object);
        }

        [Fact]
        public void ToArray()
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
        public void ToList()
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
        public void ToCollection()
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
        public void ToArrayList()
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
        public void ToLinkedList()
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
        public void ToHashSet()
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
}