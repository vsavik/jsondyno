namespace Jsondyno.Tests;

[TestFixture(TestOf = typeof(PrimitiveAdapter))]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class PrimitiveAdapterTests
{
    private readonly AdapterFixture _fixture = new();

    [SuppressMessage("Structure", "NUnit1029")]
    [TestCaseSource(typeof(TypeData), nameof(TypeData.BclTypes))]
    [TestCaseSource(typeof(TypeData), nameof(TypeData.UserTypes))]
    public void ShouldNotRepeatDeserialization_WhenConvertingToTypeMultipleTimes<T>()
    {
        // Arrange
        dynamic adapter = _fixture.CreateAdapterWithCachedValue<T>();

        // Act
        T _ = adapter;

        // Assert
        A.CallTo(() => _fixture.FakeValue.Deserialize(A<Type>._)).MustNotHaveHappened();
    }

    [SuppressMessage("Structure", "NUnit1029")]
    [TestCaseSource(typeof(TypeData), nameof(TypeData.BclTypes))]
    [TestCaseSource(typeof(TypeData), nameof(TypeData.UserTypes))]
    public void ShouldReturnKnownValueOfT_WhenSampleIsCachedAndConvertingToType<T>()
    {
        // Arrange
        Sample expected = new();
        dynamic adapter = _fixture.CreateAdapterWithCachedValue<T>();

        // Act
        Sample actual = adapter;

        // Assert
        actual.ShouldBe(expected);
    }

    [TestCaseSource(typeof(TypeData), nameof(TypeData.TypeInstances))]
    public void ShouldReturnKnownSampleInstance_WhenTypeOfTIsCached<T>(T expected)
    {
        // Arrange
        dynamic adapter = _fixture.CreateAdapterWithCachedValue(expected);

        // Act
        T actual = adapter;

        // Assert
        actual.ShouldBe(expected);
    }

    private sealed class AdapterFixture : Fixture
    {
        private readonly PrimitiveAdapter _adapter;

        public AdapterFixture()
        {
            FakeValue = A.Fake<IJsonValue>(opts => opts.Strict());
            _adapter = new PrimitiveAdapter(FakeValue);

            A.CallTo(() => FakeValue.Deserialize(A<Type>._))
                .ReturnsLazily<object?, Type>(CreateSomeInstanceOfType);
        }

        public IJsonValue FakeValue { get; }

        private object? CreateSomeInstanceOfType(Type type)
        {
            var context = new AutoFixture.Kernel.SpecimenContext(this);

            return context.Resolve(type);
        }

        public PrimitiveAdapter CreateAdapterWithCachedValue<T>()
        {
            dynamic dynamicAdapter = _adapter;
            T _ = dynamicAdapter;
            Fake.ClearRecordedCalls(FakeValue);

            return _adapter;
        }

        public PrimitiveAdapter CreateAdapterWithCachedValue<T>(T value)
        {
            A.CallTo(() => FakeValue.Deserialize(typeof(T))).Returns(value);

            return CreateAdapterWithCachedValue<T>();
        }
    }

    private sealed record Sample;
}