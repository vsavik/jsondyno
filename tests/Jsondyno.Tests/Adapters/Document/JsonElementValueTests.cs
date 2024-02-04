using System.Text.Json.Serialization;
using Jsondyno.Adapters.Document;

namespace Jsondyno.Tests.Adapters.Document;

public sealed class JsonElementValueTests :
    IClassFixture<FakerFixture>,
    IClassFixture<JsonFixture>
{
    private readonly JsonFixture _json = new();

    private readonly ITestOutputHelper _output;

    private readonly Faker _faker;

    private readonly JsonSerializerOptions _options;

    private MockObject? _mock;

    public JsonElementValueTests(
        ITestOutputHelper output,
        FakerFixture faker)
    {
        _output = output;
        _faker = faker;
        _options = new JsonSerializerOptions(JsonSerializerDefaults.General);

        output.WriteLine($"Initializing Faker with seed: {faker.Seed}");
    }

    private MockObject Mock => _mock ??= new MockObject(_json, _options);

    [Fact]
    public void CanConvertToWithCustomConverter()
    {
        // Arrange
        string propertyName = _faker.Random.String2(5);
        string propertyValue = _faker.Random.String2(10);
        string jsonStr = _json.Builder
            .ObjectStart()
            .___.Property(propertyName).String(propertyValue)
            .ObjectEnd()
            .GetString();

        _output.WriteLine("Sample object json is:");
        _output.WriteLine(jsonStr);

        SampleDtoJsonConverter converter = new(propertyName);
        _options.Converters.Add(converter);

        // Act
        object? actual = Mock.ConvertTo(typeof(SampleDto));
        object? cached = Mock.ConvertTo(typeof(SampleDto));

        // Assert
        SampleDto actualDto = actual
            .ShouldNotBeNull()
            .ShouldBeOfType<SampleDto>();

        actualDto.Data.ShouldBe(propertyValue);
        converter.ReadCount.ShouldBe(1, "Converter was invoked more than 1 time. Cache doesn't work.");

        cached
            .ShouldNotBeNull()
            .ShouldBeOfType<SampleDto>()
            .ShouldBe(actualDto, ReferenceComparer<SampleDto>.Create());
    }

    [Fact]
    public void CanConvertUsingWithCustomConverter()
    {
        // Arrange
        string propertyName = _faker.Random.String2(5);
        string propertyValue = _faker.Random.String2(10);
        string jsonStr = _json.Builder
            .ObjectStart()
            .___.Property(propertyName).String(propertyValue)
            .ObjectEnd()
            .GetString();

        _output.WriteLine("Sample object json is:");
        _output.WriteLine(jsonStr);

        SampleDtoJsonConverter converter = new(propertyName);
        _options.Converters.Add(converter);

        // Act
        SampleDto? actual = Mock.ConvertUsing(_ => new SampleDto());
        SampleDto? cached = Mock.ConvertUsing(_ => new SampleDto());

        // Assert
        actual.ShouldNotBeNull();
        actual.Data.ShouldBe(propertyValue);
        converter.ReadCount.ShouldBe(1, "Converter was invoked more than 1 time. Cache doesn't work.");
        cached.ShouldBe(actual, ReferenceComparer<SampleDto>.Create());
    }

    [Fact]
    public void CanGetFromCacheCompatibleInterfaceCreatedByConvertTo()
    {
        // Arrange
        string propertyName = _faker.Random.String2(5);
        string propertyValue = _faker.Random.String2(10);
        string jsonStr = _json.Builder
            .ObjectStart()
            .___.Property(propertyName).String(propertyValue)
            .ObjectEnd()
            .GetString();

        _output.WriteLine("Sample object json is:");
        _output.WriteLine(jsonStr);

        SampleDtoJsonConverter converter = new(propertyName);
        _options.Converters.Add(converter);

        // Act
        object? actual = Mock.ConvertTo(typeof(SampleDto));
        object? cached = Mock.ConvertTo(typeof(ISampleDto));

        // Assert
        SampleDto actualDto = actual
            .ShouldNotBeNull()
            .ShouldBeOfType<SampleDto>();

        actualDto.Data.ShouldBe(propertyValue);
        converter.ReadCount.ShouldBe(1, "Converter was invoked more than 1 time. Cache doesn't work.");

        cached
            .ShouldNotBeNull()
            .ShouldBeAssignableTo<ISampleDto>()
            .ShouldBeOfType<SampleDto>()
            .ShouldBe(actualDto, ReferenceComparer<SampleDto>.Create());
    }

    [Fact]
    public void CanGetFromCacheCompatibleInterfaceCreatedByConvertUsing()
    {
        // Arrange
        string propertyName = _faker.Random.String2(5);
        string propertyValue = _faker.Random.String2(10);
        string jsonStr = _json.Builder
            .ObjectStart()
            .___.Property(propertyName).String(propertyValue)
            .ObjectEnd()
            .GetString();

        _output.WriteLine("Sample object json is:");
        _output.WriteLine(jsonStr);

        SampleDtoJsonConverter converter = new(propertyName);
        _options.Converters.Add(converter);

        // Act
        SampleDto? actual = Mock.ConvertUsing(_ => new SampleDto());
        object? cached = Mock.ConvertTo(typeof(ISampleDto));

        // Assert
        actual.ShouldNotBeNull();
        actual.Data.ShouldBe(propertyValue);
        converter.ReadCount.ShouldBe(1, "Converter was invoked more than 1 time. Cache doesn't work.");

        cached
            .ShouldNotBeNull()
            .ShouldBeAssignableTo<ISampleDto>()
            .ShouldBeOfType<SampleDto>()
            .ShouldBe(actual, ReferenceComparer<SampleDto>.Create());
    }

    [Fact]
    public void CanConvertUsingWithCompatibleInterface()
    {
        // Arrange
        string propertyName = _faker.Random.String2(5);
        string propertyValue = _faker.Random.String2(10);
        string jsonStr = _json.Builder
            .ObjectStart()
            .___.Property(propertyName).String(propertyValue)
            .ObjectEnd()
            .GetString();

        _output.WriteLine("Sample object json is:");
        _output.WriteLine(jsonStr);

        // Act
        object? actual = Mock.ConvertTo(typeof(ISampleDto));
        object? cached = Mock.ConvertTo(typeof(ISampleDto));

        // Assert
        ISampleDto actualDto = actual
            .ShouldBeAssignableTo<ISampleDto>()
            .ShouldNotBeNull()
            .ShouldBeOfType<MockObject>();

        actualDto.Data.ShouldBe(propertyValue);

        cached
            .ShouldBeAssignableTo<ISampleDto>()
            .ShouldNotBeNull()
            .ShouldBeOfType<MockObject>()
            .ShouldBe(actualDto, ReferenceComparer<ISampleDto>.Create());
    }

    [Fact]
    public void CanConvertTo()
    {
        // Arrange
        string propertyValue = _faker.Random.String2(10);
        string jsonStr = _json.Builder
            .ObjectStart()
            .___.Property(nameof(SampleDto.Data)).String(propertyValue)
            .ObjectEnd()
            .GetString();

        _output.WriteLine("Sample object json is:");
        _output.WriteLine(jsonStr);

        // Act
        object? actual = Mock.ConvertTo(typeof(SampleDto));
        object? cached = Mock.ConvertTo(typeof(SampleDto));

        // Assert
        SampleDto actualDto = actual
            .ShouldNotBeNull()
            .ShouldBeOfType<SampleDto>();

        actualDto.Data.ShouldBe(propertyValue);

        cached
            .ShouldNotBeNull()
            .ShouldBeOfType<SampleDto>()
            .ShouldBe(actualDto, ReferenceComparer<SampleDto>.Create());
    }

    [Fact]
    public void CanConvertUsing()
    {
        // Arrange
        string propertyValue = _faker.Random.String2(10);
        string jsonStr = _json.Builder
            .ObjectStart()
            .___.Property(nameof(SampleDto.Data)).String(propertyValue)
            .ObjectEnd()
            .GetString();

        _output.WriteLine("Sample object json is:");
        _output.WriteLine(jsonStr);

        // Act
        string dataValue = _faker.Random.String2(10);
        SampleDto? actual = Mock.ConvertUsing(_ => new SampleDto { Data = dataValue });
        SampleDto? cached = Mock.ConvertUsing(_ => new SampleDto());

        // Assert
        actual.ShouldNotBeNull();
        actual.Data.ShouldBe(dataValue);
        cached.ShouldBe(actual, ReferenceComparer<SampleDto>.Create());
    }

    private interface ISampleDto
    {
        string? Data { get; init; }
    }

    private sealed class SampleDto : ISampleDto
    {
        public string? Data { get; init; }
    }

    private sealed class SampleDtoJsonConverter : JsonConverter<SampleDto>
    {
        private readonly string _sampleProperty;

        public SampleDtoJsonConverter(string sampleProperty)
        {
            _sampleProperty = sampleProperty;
        }

        public int ReadCount { get; private set; }

        public override SampleDto? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            ReadCount++;
            JsonElement element = JsonElement.ParseValue(ref reader);
            string data = element.GetProperty(_sampleProperty).GetString()!;

            return new SampleDto { Data = data };
        }

        public override void Write(
            Utf8JsonWriter writer,
            SampleDto value,
            JsonSerializerOptions options) =>
            throw new NotSupportedException();
    }

    private sealed class MockObject : JsonElementValue<MockObject>, ISampleDto
    {
        public MockObject(JsonFixture fixture, JsonSerializerOptions options)
            : base(GetJsonElement(fixture, options), options)
        {
            Data = Element.EnumerateObject().First().Value.GetString()!;
        }

        protected override MockObject Self => this;

        public string? Data { get; init; }

        private static JsonElement GetJsonElement(JsonFixture fixture, JsonSerializerOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(
                fixture.GetStream(),
                options.ToDocumentOpts());

            return document.RootElement.Clone();
        }
    }
}