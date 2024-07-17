namespace Jsondyno.Tests;

[TestFixture(typeof(PrimitiveAdapter), TestOf = typeof(PrimitiveAdapter))]
[TestFixture(typeof(ArrayAdapter), TestOf = typeof(ArrayAdapter))]
[TestFixture(typeof(ObjectAdapter), TestOf = typeof(ObjectAdapter))]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class AdapterTests<TAdapter>
    where TAdapter : Adapter
{
    private readonly AdapterFixture _fixture = new();

    private IJsonValue Fake => _fixture.FakeValue;

    [Order(1)]
    [SuppressMessage("Structure", "NUnit1029")]
    [TestCaseSource(typeof(TypeData), nameof(TypeData.BclTypes))]
    [TestCaseSource(typeof(TypeData), nameof(TypeData.UserTypes))]
    public void ShouldDeserializeOnce_WhenConvertingToType<T>()
    {
        // Arrange
        dynamic adapter = _fixture.Create<TAdapter>();

        // Act
        T _ = adapter;

        // Assert
        A.CallTo(() => Fake.Deserialize(A<Type>._)).MustHaveHappenedOnceExactly();
        A.CallTo(() => Fake.Deserialize(typeof(T))).MustHaveHappenedOnceExactly();
    }

    [Order(2)]
    [TestCaseSource(typeof(TypeData), nameof(TypeData.TypeInstances))]
    public void ShouldReturnTheInstanceOfType_WhenConvertingToType<T>(T expected)
    {
        // Arrange
        dynamic adapter = _fixture.WithExpected(expected).Create<TAdapter>();

        // Act
        T actual = adapter;

        // Assert
        actual.ShouldBe(expected);
    }

    [Order(3)]
    [SuppressMessage("Structure", "NUnit1029")]
    [TestCaseSource(typeof(TypeData), nameof(TypeData.BclTypes))]
    [TestCaseSource(typeof(TypeData), nameof(TypeData.JsonTypes))]
    public void ShouldConvertByStaticOperator_WhenConvertingToType<T>()
    {
        // Arrange
        TestableAdapter testableAdapter = _fixture.Create<TestableAdapter>();
        dynamic adapter = testableAdapter;

        // Act
        T _ = adapter;

        // Assert
        testableAdapter.DynamicConversionCallCount.ShouldBe(0);
    }

    private sealed class AdapterFixture : Fixture
    {
        public AdapterFixture()
        {
            this.Register(() => JsonValue.Create(17));
            this.Register(() => new JsonArray());
            this.Register(() => new JsonObject());

            this.Register(() => A.Fake<IJsonValue>(opts => opts.Strict().Named("Value")));
            this.Register(() => A.Fake<IJsonArray>(opts => opts.Strict().Named("Array")));
            this.Register(() => A.Fake<IJsonObject>(opts => opts.Strict().Named("Object")));

            this.Register<IJsonValue, PrimitiveAdapter>(CreatePrimitiveAdapter);
            this.Register<IJsonArray, ArrayAdapter>(CreateArrayAdapter);
            this.Register<IJsonObject, ObjectAdapter>(CreateObjectAdapter);
            this.Register((TAdapter adapter, IJsonValue jsonValue)
                => new TestableAdapter(adapter, jsonValue));

            this.Freeze<TAdapter>();
            FakeValue = this.Create<IJsonValue>();

            A.CallTo(() => FakeValue.Deserialize(A<Type>._))
                .ReturnsLazily<object?, Type>(CreateSomeInstanceOfType);

            A.CallTo(() => FakeValue.ToJsonElement())
                .ReturnsLazily(CreateJsonElement);

            A.CallTo(() => FakeValue.ToJsonNode())
                .ReturnsLazily(this.Create<JsonNode>);
        }

        public IJsonValue FakeValue { get; }

        private object? CreateSomeInstanceOfType(Type type)
        {
            var context = new AutoFixture.Kernel.SpecimenContext(this);

            return context.Resolve(type);
        }

        private JsonElement CreateJsonElement()
        {
            using JsonDocument document = JsonDocument.Parse("{}");

            return document.RootElement.Clone();
        }

        private PrimitiveAdapter CreatePrimitiveAdapter(IJsonValue jsonValue)
        {
            this.Inject(jsonValue);
            JsonValue node = this.Create<JsonValue>();
            this.Inject<JsonNode>(node);

            return new PrimitiveAdapter(jsonValue);
        }

        private ArrayAdapter CreateArrayAdapter(IJsonArray jsonArray)
        {
            this.Inject<IJsonValue>(jsonArray);
            JsonArray node = this.Create<JsonArray>();
            this.Inject<JsonNode>(node);

            return new ArrayAdapter(jsonArray);
        }

        private ObjectAdapter CreateObjectAdapter(IJsonObject jsonObject)
        {
            this.Inject<IJsonValue>(jsonObject);
            JsonObject node = this.Create<JsonObject>();
            this.Inject<JsonNode>(node);

            return new ObjectAdapter(jsonObject, null);
        }

        public AdapterFixture WithExpected<T>(T instance)
        {
            A.CallTo(() => FakeValue.Deserialize(typeof(T))).Returns(instance);

            return this;
        }
    }

    public sealed class TestableAdapter : Adapter
    {
        private readonly TAdapter _adapter;

        internal TestableAdapter(
            TAdapter adapter,
            IJsonValue jsonValue)
        {
            _adapter = adapter;
            JsonValue = jsonValue;
        }

        private protected override IJsonValue JsonValue { get; }

        public int DynamicConversionCallCount { get; private set; }

        public override bool TryConvert(ConvertBinder binder, out object? result)
        {
            DynamicConversionCallCount++;

            return _adapter.TryConvert(binder, out result);
        }
    }
}