// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using Sample.ConsoleApp;

Console.WriteLine("Hello, World!");

var opts = new JsonSerializerOptions(JsonSerializerDefaults.General)
{
    AllowTrailingCommas = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    //DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
    //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true,
    ReadCommentHandling = JsonCommentHandling.Skip,
    UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
    WriteIndented = true,
    //Converters = { new DynamConverter() },
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
                    {
                        "a": 17,
                        "b": 42,
                        "c": "test",
                        "Bv": 54546
                    }
                    """;




JsonNode node = JsonNode.Parse(objectJson, new JsonNodeOptions() {PropertyNameCaseInsensitive = true})!;
JsonObject objNode = node.AsObject();

Console.WriteLine(objNode["bs"] ?? "NULL");



/*
using JsonDocument doc = JsonDocument.Parse(objectJson);
if (doc.RootElement.TryGetProperty("A", out JsonElement element))
{
    Console.WriteLine(element);
}
else
{
    Console.WriteLine("No prop found");
}
*/


/*
dynamic? x = JsonSerializer.Deserialize<dynamic>(json, opts);

Console.WriteLine(x is null);
object? o = x;
Console.WriteLine(o?.GetType());
Console.WriteLine(o?.ToString());
*/
/*
JsonConverter c = opts.GetConverter(typeof(Sa));
Console.WriteLine(c.GetType());
Console.WriteLine(c.Type);
*/

JsonNodeOptions options = new() { PropertyNameCaseInsensitive = true };

var jo = new JsonObject(options)
{
    ["Obj"] = JsonValue.Create(new WeatherForecast { Data = 15, DataList = ["asd", 48] }, options)
};



//Console.WriteLine(jo["Obj"]!.);
/*
var result = JsonBuilderFactory.Create(default!)
            .ArrayStart()
            .___.Null()
            .___.ArrayStart()
            .___.___.Null()
            .___.___.Null()
            .___.___.ArrayStart()
            .___.___.___.Null()
            .___.___.___.ObjectStart()
            .___.___.___.___.Property("name").Null()
            .___.___.___.___.Property("val").Number(17)
            .___.___.___.___.ArrayStart("arr")
            .___.___.___.___.ArrayEnd()
            .___.___.___.ObjectEnd()
            .___.___.___.Null()
            .___.___.ArrayEnd()
            .___.___.Null()
            .___.ArrayEnd()
            .___.Null()
            .ArrayEnd();

*/


[JsonSourceGenerationOptions(
    WriteIndented = true,
    //Converters = new[] { typeof(DynamicProxyJsonConverter) },
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(WeatherForecast))]
internal partial class MySourceGenerationContext : JsonSerializerContext
{
}

public class WeatherForecast
{
    public object? Data { get; set; }
    public List<object>? DataList { get; set; }
}

public sealed class DynamicCollection : DynamicObject, ISample
{
    public List<string> Names { get; } = new();

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        Console.WriteLine($"From TryConvert: {binder.ReturnType}");

        if (binder.ReturnType == typeof(IEnumerable))
        {
            List<string> list = ["asd", "dsa"];
            result = list;

            return true;
        }

        return base.TryConvert(binder, out result);
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        Names.Add(binder.Name);

        result = 42;

        return true;
    }


    void ISample.Sample()
    {
        Console.WriteLine($"fr Sample ");
    }

    public static implicit operator bool(DynamicCollection c)
    {
        return true;
    }

    public static implicit operator int(DynamicCollection c)
    {
        return 17;
    }
}


internal interface ISample
{
    void Sample();
}