# Jsondyno

Use C# ```dynamic``` keyword to deserialzie json data provided by [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/overview) implementation.

Access json object properties without model class definition, including [JsonSerializerOptions](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions) configurations:

- [JsonSerializerOptions.PropertyNamingPolicy](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.propertynamingpolicy)
- [JsonSerializerOptions.PropertyNameCaseInsensitive](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.propertynamecaseinsensitive)

## Installation

You can add this library to your project using [NuGet](http://www.nuget.org/).

Run the following command from your favorite shell or terminal:

```sh
dotnet add package Jsondyno
```

## Quick start

Deserialize json manually using [JsonSerializer](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer) class.

```csharp
using Jsondyno;

var opts = new JsonSerializerOptions
{
    Converters = { new DynamicObjectJsonConverter() }
};

string json = """
    {
        "MyProperty": 11
    }
    """;

dynamic obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;
int myProperty = obj.MyProperty;

Console.WriteLine(myProperty); // Output: 11
```

## Documentation

TBD

## License

Jsondyno is licensed under the [MIT](LICENSE) license.