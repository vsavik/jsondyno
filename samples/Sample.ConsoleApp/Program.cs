// See https://aka.ms/new-console-template for more information

using System.Collections;

Console.WriteLine("Hello, World!");

var opts = new JsonSerializerOptions(JsonSerializerDefaults.General)
{
    AllowTrailingCommas = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true,
    ReadCommentHandling = JsonCommentHandling.Skip,
    UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
    WriteIndented = true,
    Converters = { new DynamConverter() },
};

string json = """
              {"name": 17}
              """;

string nulljson = """
                  null
                  """;

string arrayJson = """
                   [ 42, 54 ]
                   """;

string objectJson = """
                    { "a": 17 }
                    """;


dynamic? x = JsonSerializer.Deserialize<dynamic>(json, opts);

Console.WriteLine(x is null);
object? o = x;
Console.WriteLine(o?.GetType());
Console.WriteLine(o?.ToString());

/*
JsonConverter c = opts.GetConverter(typeof(Sa));
Console.WriteLine(c.GetType());
Console.WriteLine(c.Type);
*/

JsonNodeOptions options = new()
{
    PropertyNameCaseInsensitive = true
};

var jo = new JsonObject(options)
{
    ["Obj"] = JsonValue.Create(new WeatherForecast { Data = 15, DataList = ["asd", 48] }, options)
};

//Console.WriteLine(jo["Obj"]!.);



public class Sa : IEnumerable<string>
{
    public SampleDynamic Name { get; set; } = new();
    public IEnumerator<string> GetEnumerator() => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}


[JsonSourceGenerationOptions(
    WriteIndented = true,
    //Converters = new[] { typeof(DynamicProxyJsonConverter) },
    GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(WeatherForecast))]
internal partial class MySourceGenerationContext : JsonSerializerContext
{
}

public class WeatherForecast
{
    public object? Data { get; set; }
    public List<object>? DataList { get; set; }
}

public class Empty
{
    public static implicit operator List<int>(Empty e) => [ 24 ];

    public override string ToString() => "Empty!!!";
}


public sealed class CustomStructConverter : JsonConverter<Sa>
{
    public override Sa Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        reader.Skip();
        return new Sa() { };
    }

    public override void Write(Utf8JsonWriter writer, Sa value, JsonSerializerOptions options) =>
        throw new NotImplementedException();
}

public sealed class SampleDynamic : DynamicObject
{
    private readonly int _v = 42;

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        Console.WriteLine(binder.Type);

        result = new Empty();

        return true;
    }
}

public sealed class DynamConverter : JsonConverter<dynamic?>
{
    public override dynamic? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Console.WriteLine($"i'm inside DynamConverter {typeToConvert}");
        return JsonSerializer.Deserialize<JsonElement>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, dynamic? value, JsonSerializerOptions options) => throw new NotImplementedException();
}