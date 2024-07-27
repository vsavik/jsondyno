# Jsondyno

Jsondyno is a C# library that allows you to use the `dynamic` keyword to access JSON object properties without model classes.

## Quick start

Install [NuGet](https://www.nuget.org/packages/Jsondyno) package and add `DynamicObjectJsonConverter` to [`JsonSerializerOptions`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions) instance:

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

*Jsondyno* uses [`System.Text.Json`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json) library to parse JSON, so `dynamic` object property name conversion fully satisfy configuration settings:

- [JsonSerializerOptions.PropertyNamingPolicy](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.propertynamingpolicy)
- [JsonSerializerOptions.PropertyNameCaseInsensitive](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.propertynamecaseinsensitive)

## Documentation

TBD

## Contributing

When contributing to the *Jsondyno* repo, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

Please note the [code of conduct](.github/CODE_OF_CONDUCT.md), please follow it in all your interactions with the project.

How to deal with security issues check security [page](.github/SECURITY.md).

## License

Jsondyno is licensed under the [MIT](LICENSE) license.