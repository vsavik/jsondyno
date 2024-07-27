# Advanced

This document describes *Jsondyno* internals.

## Operators

[`Adapter`](./../src/Jsondyno/Dynamic/Adapter.Operators.cs) class provides several `static implicit operator` methods. They are used to improve dynamic type conversion perfrmance.

Also this improves usability and allows to use dynamic objects in control flow constructions and arithmetic operators:

```csharp
string json = """
    {
        "IsTrue": true,
        "Int": 17
    }
    """;

dynamic obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;

if (obj.IsTrue)
{
    Console.WriteLine(obj.Int + 1);
}
```

## Deserialization behaviour

Keep in mind, that `dynamic` conversion follows the rules specified in `JsonSerializerOptions`, including [type converters](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.converters), [`TypeInfoResolver`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.typeinforesolver) and other settings. That means you should be careful defining converters that transform JSON arrays to non-collection classes, numbers to objects, etc. In the example below, `MyIDJsonConverter` allows to create `MyID` object from JSON number:

```csharp
public record MyID(int Value);

public sealed class MyIDJsonConverter : JsonConverter<MyID>
{
    public override MyID Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        /* Read MyID from JSON number */
    }

    public override void Write(
        Utf8JsonWriter writer,
        MyID value,
        JsonSerializerOptions options)
    {
        /* ... */
    }
}

var opts = new JsonSerializerOptions
{
    Converters =
    {
        new DynamicObjectJsonConverter(),
        new MyIDJsonConverter()
    }
};

string json = """
    {
        "ID": 42
    }
    """;

dynamic obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;

MyID id = obj.ID;
```

## Memory optimizations & performance

*Jsondyno* allows to process large JSONs. Object will be deserialized only when requested. In some cases deserialized data will be cached when requested multiple times.

### Primitive types

The following JSON types will be cached on conversion:

- number
- true, false
- string

Requesting conversion multiple types will not cause multiple JSON deserialization.

In the example below dynamic object center will request JSON deserialization once even object type conversion called twice.

```csharp
dynamic center = JsonSerializer.Deserialize<dynamic>("11", opts)!;
(int, int) range = (center - 5, center + 5);
```

Dynamc adapter cache can be updated when object was re-converted to another type:

```csharp
int centerInt = center;
long centerLong = center;
```

In this case requesting `long` after `int` will trigger JSON deserialization.

### Arrays

In array *Jsondyno* adds to cache:

- array size (properties `Length` and `Count` are calculated once)
- last item used

Last item caching is useful in the following case:

```csharp
string name = obj[0].Name;
int age = obj[0].Age;
```

This allows not involving additional variable `obj[0]` for performance. When requred to access multuiple different indexes, it is better to convert `obj` into `dynamic[]` and work with .NET array.

### Objects

For objects *Jsondyno* adds to cache every property requested by index or by dynamic property name. As for arrays, cached properties will not reqest additional deserializations.

```csharp
string country = obj.Address.Country;
string city = obj.Address.City;

string country = obj.["Address"].Country;
string city = obj.["Address"].City;
```

In the example above `Address` property will be cached.

## `JsonElement` vs `JsonNode`

JSON data can be deserialized into [`JsonElement`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonelement) or [`JsonNode`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonnode). This behaviour is controlled via [`JsonSerializerOptions.UnknownTypeHandling`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonunknowntypehandling) option. Therefore *Jsondyno* will operate against `JsonElement` or `JsonNode` respectively. *Jsondyno* `dynamic` object can be converted into both types:

```csharp
dynamic obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;

JsonElement element = obj;
JsonNode node = obj;
```

When `JsonSerializerOptions.UnknownTypeHandling` matches target type then `dynamic` conversion will work much faster (without additional conversions). For example, when `JsonSerializerOptions.UnknownTypeHandling` is set to `JsonUnknownTypeHandling.JsonElement`, then conversion to `JsonNode` will require conversion from `JsonElement` to `JsonNode`.