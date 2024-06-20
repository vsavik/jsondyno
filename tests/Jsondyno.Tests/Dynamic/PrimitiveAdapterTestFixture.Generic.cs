using Jsondyno.Internal;
using Jsondyno.Internal.Dynamic;

namespace Jsondyno.Tests.Dynamic;

partial class PrimitiveAdapterTestFixture
{
    internal sealed class TypecastTestFixture<TExpected> : ITypecastTestFixture
    {
        private readonly Mock<IJsonValue> _mock = new(MockBehavior.Strict);

        private readonly TExpected _expected;

        private readonly dynamic _adapter;
        
        private int _callCount;

        public TypecastTestFixture(TExpected expected)
        {
            _expected = expected;
            Context context = new(JsonSerializerOptions.Default);
            _adapter = new PrimitiveAdapter(_mock.Object, context);
            _mock.Setup(jsonValue => jsonValue.Deserialize(typeof(TExpected), context.Options))
                .Returns(expected)
                .Verifiable(Times.Once, "Caching doesn't work.");
        }

        public void AssertAdapterIsConvertedToType(ITestOutputHelper output)
        {
            // Act
            TExpected actual = _adapter;
            output.WriteLine($"Call {++_callCount}: expected is {_expected}, actual is {actual}");

            // Assert
            actual.ShouldBe(_expected);
            _mock.VerifyAll();
        }
    }
    
    public sealed class Value<T> : IValue
    {
        private readonly Func<Faker, T> _factory;

        private readonly string _description;

        public Value(Func<Faker, T> factory, string description)
        {
            _factory = factory;
            _description = description;
        }

        public static IValue FromValue(T value)
        {
            string description = $"{CreateTypeName()} {value}";

            return new Value<T>(_ => value, description);
        }

        public static IValue FromRandom(Func<Faker, T> factory, string additionalInfo = "-")
        {
            string description = $"Random {additionalInfo} {CreateTypeName()}";

            return new Value<T>(factory, description);
        }
        
        private static string CreateTypeName()
        {
            Type? underlyingType = Nullable.GetUnderlyingType(typeof(T));
            
            return underlyingType is not null ? underlyingType.Name + "?" : typeof(T).Name;
        }

        public ITypecastTestFixture CreateTestFixture(Faker faker)
        {
            T value = _factory(faker);

            return new TypecastTestFixture<T>(value);
        }

        public override string ToString() => _description;
    }
}