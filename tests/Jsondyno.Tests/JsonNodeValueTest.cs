namespace Jsondyno.Tests;

[TestFixture(TestOf = typeof(JsonNodeValue<>))]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class JsonNodeValueTest
{
    private readonly JsonNodeValueFixture _fixture = new();

    [TestCase("[]", 0)]
    [TestCase("[true]", 1)]
    [TestCase("""[1, "a", 5, {}]""", 4)]
    public void GetLength_ShouldReturnJsonArrayLength_WhenJsonIsValidArray(
        string json,
        int expectedLength)
    {
        // Arrange
        IJsonArray value = _fixture.WithJson(json).Create<IJsonArray>();

        // Act
        int actualLength = value.GetLength();

        // Assert
        actualLength.ShouldBe(expectedLength);
    }

    [TestCase("""[1, "a", true, {"name":42}, null]""", 0, "1")]
    [TestCase("""[1, "a", true, {"name":42}, null]""", 1, "\"a\"")]
    [TestCase("""[1, "a", true, {"name":42}, null]""", 2, "true")]
    [TestCase("""[1, "a", true, {"name":42}, null]""", 3, "{\"name\":42}")]
    [TestCase("""[1, "a", true, {"name":42}, null]""", 4, null)]
    public void GetElement_ShouldReturnJsonArrayElement_WhenJsonIsValidArray(
        string json,
        int index,
        string? elementJson)
    {
        // Arrange
        IJsonArray value = _fixture.WithJson(json).Create<IJsonArray>();

        // Act
        JsonNode? actualNode = value.GetElement(index)?.ToJsonNode();

        // Assert
        actualNode.ShouldBeJsonString(elementJson);
    }

    [TestCase("""{ "name": "John", "age": 32}""", "name", "\"John\"")]
    [TestCase("""{ "name": "John", "age": 32}""", "Name", null)]
    [TestCase("""{ "name": "John", "age": 32}""", "age", "32")]
    [TestCase("""{ "name": "John", "age": 32}""", "AGE", null)]
    [TestCase("""{ "name": "John", "age": 32}""", "none", null)]
    public void GetProperty_ShouldReturnObjectProperty_WhenJsonIsValidObject(
        string json,
        string propertyName,
        string? elementJson)
    {
        // Arrange
        IJsonObject value = _fixture.WithJson(json).Create<IJsonObject>();

        // Act
        JsonNode? actualNode = value.GetProperty(propertyName)?.ToJsonNode();

        // Assert
        actualNode.ShouldBeJsonString(elementJson);
    }

    [TestCase("""{ "name": "John", "age": 32}""", "name", "\"John\"")]
    [TestCase("""{ "name": "John", "age": 32}""", "Name", "\"John\"")]
    [TestCase("""{ "name": "John", "age": 32}""", "age", "32")]
    [TestCase("""{ "name": "John", "age": 32}""", "AGE", "32")]
    [TestCase("""{ "name": "John", "age": 32}""", "none", null)]
    public void GetProperty_ShouldReturnObjectPropertyCaseInsensitive_WhenJsonIsValidObject(
        string json,
        string propertyName,
        string? elementJson)
    {
        // Arrange
        IJsonObject value = _fixture.WithJson(json).CaseInsensitive().Create<IJsonObject>();

        // Act
        JsonNode? actualNode = value.GetProperty(propertyName)?.ToJsonNode();

        // Assert
        actualNode.ShouldBeJsonString(elementJson);
    }

    [TestCase("true", TypeArgs = [typeof(PrimitiveAdapter)])]
    [TestCase("false", TypeArgs = [typeof(PrimitiveAdapter)])]
    [TestCase("42", TypeArgs = [typeof(PrimitiveAdapter)])]
    [TestCase("17.1", TypeArgs = [typeof(PrimitiveAdapter)])]
    [TestCase("\"str\"", TypeArgs = [typeof(PrimitiveAdapter)])]
    [TestCase("[]", TypeArgs = [typeof(ArrayAdapter)])]
    [TestCase("[42]", TypeArgs = [typeof(ArrayAdapter)])]
    [TestCase("{}", TypeArgs = [typeof(ObjectAdapter)])]
    [TestCase("""{"name": "John"}""", TypeArgs = [typeof(ObjectAdapter)])]
    public void ToDynamic_WhenStringIsValidNotNullJson_ShouldReturnAdapterOfType<T>(string json)
    {
        // Arrange
        IJsonValue value = _fixture.WithJson(json).Create<IJsonValue>();

        // Act
        DynamicObject actual = value.ToDynamic();

        // Assert
        actual.ShouldBeOfType<T>();
    }

    private sealed class JsonNodeValueFixture : Fixture
    {
        public JsonNodeValueFixture()
        {
            this.Inject(JsonSerializerOptions.Default);
            this.Register<string, JsonSerializerOptions, JsonNode>(CreateJsonNode);
            this.Register<JsonNode, JsonSerializerOptions, IJsonValue>(CreateJsonNode);
            this.Register((IJsonValue jsonValue) => (IJsonArray)jsonValue);
            this.Register((IJsonValue jsonValue) => (IJsonObject)jsonValue);
        }

        private JsonNode CreateJsonNode(string json, JsonSerializerOptions opts) =>
            JsonNode.Parse(json, opts.ToNodeOpts())!;

        private IJsonValue CreateJsonNode(JsonNode rootNode, JsonSerializerOptions opts) =>
            JsonNodeValue<JsonNode>.Convert(rootNode, opts);

        public JsonNodeValueFixture WithJson(string json)
        {
            this.Inject(json);

            return this;
        }

        public JsonNodeValueFixture CaseInsensitive()
        {
            this.Inject(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return this;
        }
    }
}