namespace Jsondyno.Tests;

[TestFixture(TestOf = typeof(ObjectAdapter))]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class ObjectAdapterTests
{
    private readonly AdapterFixture _fixture = new();

    private IJsonObject Fake => _fixture.FakeObject;

    public static IEnumerable TestPropertyNames => AdapterFixture.CreatePropertyNameTestCases();

    [Test, Order(1)]
    public void GetItemByIndex_ShouldReceiveIndexValue_WhenRequestPropertyByIndex()
    {
        // Arrange
        string key = _fixture.CreateKey();
        dynamic adapter = _fixture.Create<ObjectAdapter>();

        // Act
        _ = adapter[key];

        // Assert
        A.CallTo(() => Fake.GetProperty(A<string>._)).MustHaveHappenedOnceExactly();
        A.CallTo(() => Fake.GetProperty(key)).MustHaveHappenedOnceExactly();
    }

    [Test, Order(1)]
    public void GetItemByIndex_ShouldReturnTheValue_WhenRequestPropertyByIndex()
    {
        // Arrange
        string key = _fixture.CreateKey();
        object expected = _fixture.CreateExpectedPropertyValue();
        dynamic adapter = _fixture.Create<ObjectAdapter>();

        // Act
        object? actual = adapter[key];

        // Assert
        actual.ShouldBe(expected);
    }

    [Test, Order(2)]
    public void GetItemByIndex_ShouldReturnCachedValue_WhenRequestPropertyByIndexMultipleTypes()
    {
        // Arrange
        string key = _fixture.CreateKey();
        dynamic adapter = _fixture.CreateAdapterWithCachedProperty();

        // Act
        _ = adapter[key];

        // Assert
        A.CallTo(() => Fake.GetProperty(A<string>._)).MustNotHaveHappened();
    }

    [TestCaseSource(nameof(TestPropertyNames)), Order(1)]
    public void TryGetMember_ShouldReceivePropertyName_WhenMakeDynamicPropertyCall(
        JsonNamingPolicy? policy,
        string expectedKey)
    {
        // Arrange
        dynamic adapter = _fixture.WithPolicy(policy).Create<ObjectAdapter>();

        // Act
        _ = adapter.SomeTestProperty;

        // Assert
        A.CallTo(() => Fake.GetProperty(A<string>._)).MustHaveHappenedOnceExactly();
        A.CallTo(() => Fake.GetProperty(expectedKey)).MustHaveHappenedOnceExactly();
    }

    [Test, Order(1)]
    public void TryGetMember_ShouldReturnTheValue_WhenRequestPropertyByIndex()
    {
        // Arrange
        object expected = _fixture.CreateExpectedPropertyValue();
        dynamic adapter = _fixture.Create<ObjectAdapter>();

        // Act
        object? actual = adapter.SomeTestProperty;

        // Assert
        actual.ShouldBe(expected);
    }

    [Test, Order(2)]
    public void TryGetMember_ShouldReturnCachedValue_WhenRequestPropertyMultipleTypes()
    {
        // Arrange
        dynamic adapter = _fixture.CreateAdapterWithCachedProperty();

        // Act
        _ = adapter.SomeTestProperty;

        // Assert
        A.CallTo(() => Fake.GetProperty(A<string>._)).MustNotHaveHappened();
    }

    private sealed class AdapterFixture : Fixture
    {
        private const string IndexKey = "sample-key";

        private const string PropertyName = "SomeTestProperty";

        public AdapterFixture()
        {
            IJsonValue propertyValue = A.Fake<IJsonValue>();
            A.CallTo(() => FakeObject.GetProperty(A<string>._)).Returns(propertyValue);
            A.CallTo(() => propertyValue.ToDynamic()).ReturnsLazily(this.Create<DynamicStub>);

            this.Inject(PropertyName);
            this.Inject<JsonNamingPolicy?>(null);
            this.Inject(FakeObject);
            this.Inject(new DynamicStub());
            this.Register((IJsonObject jsonObject, JsonNamingPolicy? policy) =>
                new ObjectAdapter(jsonObject, policy));
        }

        public IJsonObject FakeObject { get; } = A.Fake<IJsonObject>();

        public string CreateKey()
        {
            this.Inject(IndexKey);

            return IndexKey;
        }

        public object CreateExpectedPropertyValue() => this.Create<DynamicStub>();

        public ObjectAdapter CreateAdapterWithCachedProperty()
        {
            ObjectAdapter adapter = this.Create<ObjectAdapter>();
            string propertyName = this.Create<string>();
            _ = adapter[propertyName];
            TestContext.WriteLine($"Caching property '{propertyName}'.");
            FakeObject.ClearFakeJsonCalls();

            return adapter;
        }

        public AdapterFixture WithPolicy(JsonNamingPolicy? policy)
        {
            this.Inject(policy);

            return this;
        }

        public static IEnumerable<TestCaseData> CreatePropertyNameTestCases()
        {
            yield return new TestCaseData(null, "SomeTestProperty").SetName("{1}");
            yield return new TestCaseData(JsonNamingPolicy.CamelCase, "someTestProperty").SetName("{1}");
            yield return new TestCaseData(JsonNamingPolicy.KebabCaseLower, "some-test-property").SetName("{1}");
            yield return new TestCaseData(JsonNamingPolicy.KebabCaseUpper, "SOME-TEST-PROPERTY").SetName("{1}");
            yield return new TestCaseData(JsonNamingPolicy.SnakeCaseLower, "some_test_property").SetName("{1}");
            yield return new TestCaseData(JsonNamingPolicy.SnakeCaseUpper, "SOME_TEST_PROPERTY").SetName("{1}");
        }
    }
}