# Usage

This page describes use cases of *Jsondyno*:

- [Integration scenarios](#integration-scenarios)
  - [Configure `JsonSerializerOptions`](#configure-jsonserializeroptions)
  - [Use `JsonConverter` Attribute](#use-jsonconverter-attribute)
  - [Minimal APIs](#minimal-apis)
  - [Controller-based APIs](#controller-based-apis)
- [Adapter behaviour](#adapter-behaviour)
  - [JSON Object](#json-object)
    - [Access by index](#access-by-index)
    - [Access by dynamic property](#access-by-dynamic-property)
    - [Name policy](#name-policy)
    - [Case-insensitive names](#case-insensitive-names)
    - [Missing properties](#missing-properties)
  - [JSON Array](#json-array)
    - [Access size](#access-size)
    - [Access elements](#access-elements)
    - [Enumerate items](#enumerate-items)
  - [Deserialization](#deserialization)

## Integration scenarios

This section explains how to integrate *Jsondyno* into an application.

### Configure `JsonSerializerOptions`

To convert JSON data into `dynamic` object an instance of `DynamicObjectJsonConverter` should be added to [`JsonSerializerOptions.Converters`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.converters) property.

```csharp
using Jsondyno;

var opts = new JsonSerializerOptions
{
    Converters = { new DynamicObjectJsonConverter() }
};
```

Then use [`JsonSerializer`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer) class:

```csharp
dynamic? obj = JsonSerializer.Deserialize<dynamic>(json, opts);
```

### Use `JsonConverter` Attribute

Mark class property with `dynamic` return type with [JsonConverterAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonconverterattribute).

```csharp
public class Response
{
    [JsonConverter(typeof(DynamicObjectJsonConverter))]
    public dynamic? Data { get; set; }
}
```

### Minimal APIs

Configure [`JsonSerializerOptions`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.httpjsonserviceextensions.configurehttpjsonoptions) used in [ASP.NET minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview):

```csharp
builder.Services.ConfigureHttpJsonOptions(opts =>
{
    opts.SerializerOptions.Converters.Add(
        new DynamicObjectJsonConverter());
});
```

Then use `dynamic` in endpoint definition:

```csharp
app.MapPost("/", (dynamic? body) => /* Process body */);
```

### Controller-based APIs

Configure [`JsonSerializerOptions`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.mvccoremvcbuilderextensions.addjsonoptions) used in [ASP.NET controller-based APIs](https://learn.microsoft.com/en-us/aspnet/core/web-api):

```csharp
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.Converters.Add(
        new DynamicObjectJsonConverter());
});
```

Then use `dynamic` in controller methods:

```csharp
[ApiController]
public sealed class DefaultController : ControllerBase
{
    [HttpPost]
    public IActionResult Submit([FromBody] dynamic? data)
    {
        /* Process data */
    }
}
```

## Adapter behaviour

This section describes capabilities of `dynamic` objects created by `DynamicObjectJsonConverter`.

### JSON Object

To demostrate object features the following JSON will be used:

```csharp
string json = """
    {
        "Name": "John Doe",
        "Age": 50
    }
    """;
dynamic obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;
```

#### Access by index

```chsarp
string name = obj["Name"]; // John Doe
int age = obj["Age"];      // 50
```

#### Access by dynamic property

JSON object data (within `{ ... }`) can be accessed by dynamic property name.

```chsarp
string name = obj.Name; // John Doe
int age = obj.Age;      // 50
```

##### Name policy

It is possible to use different [naming policies](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonnamingpolicy) to control dynamic properties names:

```csharp
var opts = new JsonSerializerOptions
{
    Converters = { new DynamicObjectJsonConverter() },
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};
```

Then use default C# coding convetions (pascal case) to access JSON propertes in casmel case.

```csharp
string json = """
    {
        "firstName": "John Doe",
        "age": 50
    }
    """;
dynamic obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;

string name = obj.FirstName; // John Doe
int age = obj.Age;           // 50
```

#### Case-insensitive names

Another option is to disable case-sensitive properties matching.

```csharp
var opts = new JsonSerializerOptions
{
    Converters = { new DynamicObjectJsonConverter() },
    PropertyNameCaseInsensitive = true
};
```

The following action will return the same result (age1-6 are equal):

```csharp
int age1 = obj.Age;
int age2 = obj.age;
int age3 = obj.AGE;

int age4 = obj["Age"];
int age5 = obj["age"];
int age6 = obj["AGE"];
```

#### Missing properties

When requrested property is missing then behaviour depends on return type:

- Any reference type or nullable value types: `null` is returned
- Non-nullable value types: exception is thrown

### JSON Array

*Jsondyno* provides additional features to JSON arrays (`[ ... ]`).

```csharp
string json = """[42, "John Doe", true]""";
dynamic obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;
```

#### Access size

The number of elements inside JSON array can be obtained by `Length` property. Also can be used `Count` property, which is an alias of `Length`.

```csharp
int length = obj.Length; // 3

int length = obj.Count; // also 3
```

#### Access elements

Use indexer to obtain array element:

```csharp
string item1 = obj[1]; // John Doe
```

#### Enumerate items

It is possible to use `foreach` keyword to enumerate array items:

```csharp
foreach (dynamic item in obj)
{
    // Process item
}
```

Note: when using `foreach` then `obj` is converted to [`IEnumerable`](https://learn.microsoft.com/fr-fr/dotnet/api/system.collections.ienumerable) interface. So be careful implementing `JsonConverter<IEnumerable>` converters.

### Deserialization

It is possible to deserialize `dynamic` objects to any model object: class, structs, collections, enums. Also `dynamic` can be a model property.

```csharp
string json = """
    {
        "Array": [
            {
                "Name": "John"
            },
            {
                "Name": "Jane"
            }
        ]
    }
    """;

public record User(string Name);

dynamic obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;

User user0 = obj.Array[0];
```

See [console sample](./../samples/01-console-basic-usage-sample/Program.cs) for more examples.