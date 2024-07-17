using System.Dynamic;

namespace Jsondyno.Tests;

[TestFixture(TestOf = typeof(JsonElementValue))]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class JsonElementValueTests
{
    private readonly JsonElementValueFixture _fixture = new();

    [TestCase("[]", 0)]
    [TestCase("[true]", 1)]
    [TestCase("""[1, "a", 5, {}]""", 4)]
    public void GetLength_ShouldReturnJsonArrayLength_WhenJsonIsValidArray(
        string json,
        int expectedLength)
    {
        // Arrange
        JsonElementValue value = _fixture.WithJson(json).Create<JsonElementValue>();

        // Act
        int actualLength = value.GetLength();

        // Assert
        actualLength.ShouldBe(expectedLength);
    }

    [TestCase("""[1, "a", true, {"name": 42}, null]""", 0, "1")]
    [TestCase("""[1, "a", true, {"name": 42}, null]""", 1, "\"a\"")]
    [TestCase("""[1, "a", true, {"name": 42}, null]""", 2, "true")]
    [TestCase("""[1, "a", true, {"name": 42}, null]""", 3, "{\"name\": 42}")]
    [TestCase("""[1, "a", true, {"name": 42}, null]""", 4, null)]
    public void GetElement_ShouldReturnJsonArrayElement_WhenJsonIsValidArray(
        string json,
        int index,
        string? elementJson)
    {
        // Arrange
        JsonElementValue value = _fixture.WithJson(json).Create<JsonElementValue>();

        // Act
        JsonElement? actualElement = value.GetElement(index)?.ToJsonElement();

        // Assert
        actualElement.ShouldBeJsonString(elementJson);
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
        JsonElementValue value = _fixture.WithJson(json).Create<JsonElementValue>();

        // Act
        JsonElement? actualElement = value.GetProperty(propertyName)?.ToJsonElement();

        // Assert
        actualElement.ShouldBeJsonString(elementJson);
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
        JsonElementValue value = _fixture.WithJson(json).CaseInsensitive().Create<JsonElementValue>();

        // Act
        JsonElement? actualElement = value.GetProperty(propertyName)?.ToJsonElement();

        // Assert
        actualElement.ShouldBeJsonString(elementJson);
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
        JsonElementValue value = _fixture.WithJson(json).Create<JsonElementValue>();

        // Act
        DynamicObject actualElement = value.ToDynamic();

        // Assert
        actualElement.ShouldBeOfType<T>();
    }

    private sealed class JsonElementValueFixture : Fixture
    {
        public JsonElementValueFixture()
        {
            this.Inject(JsonSerializerOptions.Default);
            this.Register<string, JsonElement>(CreateJsonElement);
            this.Register((JsonElement element, JsonSerializerOptions opts) =>
                JsonElementValue.Create(element, opts));
        }

        private JsonElement CreateJsonElement(string json)
        {
            using JsonDocument document = JsonDocument.Parse(json);

            return document.RootElement.Clone();
        }

        public JsonElementValueFixture WithJson(string json)
        {
            this.Inject(json);

            return this;
        }

        public JsonElementValueFixture CaseInsensitive()
        {
            this.Inject(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return this;
        }
    }
}