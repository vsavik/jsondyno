using System.Collections;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Dynamic.SystemTextJson;
using static DynamicConsole;


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
    Converters = { new DynamicProxyJsonConverter() }
};


//dynamic? e = JsonSerializer.Deserialize<dynamic>("null", opts);

//Wl(e);


Console.WriteLine(new Opp().First());

/*
[JsonSourceGenerationOptions(
    WriteIndented = true,
    Converters = new[] { typeof(DynamicProxyJsonConverter) },
    GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(WeatherForecast))]
internal partial class MySourceGenerationContext : JsonSerializerContext
{

}

public class WeatherForecast
{
    public object? Data { get; set; }
    public List<object>? DataList { get; set; }
}*/

public static class DynamicConsole
{
    public static void Wl(dynamic? obj)
    {
        if (obj is null)
        {
            Console.WriteLine("NULL");
        }
        else
        {
            Console.WriteLine(obj.ToString());
        }
    }
}


public class Opp : ICustomEnumerable<string>
{
    private readonly List<string> _items = new()
    {
        "test"
    };

    public static void Test()
    {
    }

    public List<string>.Enumerator GetEnumerator()
    {
        Console.WriteLine("Get list enumer");

        return _items.GetEnumerator();
    }
}


public interface ICustomEnumerable<T> : IEnumerable<T>
{
    new List<T>.Enumerator GetEnumerator();

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        Console.WriteLine("IEnumerable<T>");

        return GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        Console.WriteLine("IEnumerable");

        return GetEnumerator();
    }
}