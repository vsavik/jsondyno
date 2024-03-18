using System.Text.Json;
using Jsondyno;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]

string json = """
    {
        "lowercasekey": "lc",
        "UPPERCASEKEY": "uc",
        "camelCaseKey": "cc",
        "kebab-case-key": "kc"
    }
    """;

// ReSharper disable JoinDeclarationAndInitializer
JsonSerializerOptions opts;
dynamic obj;
string lowerCaseValue, uppperCaseValue, camelCaseValue, kebabCaseValue;

// ----------------------------------------------------------------------------
// Options with default JsonNamingPolicy and PropertyNameCaseInsensitive = false
opts = new JsonSerializerOptions
{
    Converters = { new DynamicConverter() }
};

obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;

// Properties are resolved as is
lowerCaseValue = obj.lowercasekey;
uppperCaseValue = obj.UPPERCASEKEY;
camelCaseValue = obj.camelCaseKey;
kebabCaseValue = obj["kebab-case-key"]; // dash (-) symbol is not allowed in C# member name 

WriteValues();

// ----------------------------------------------------------------------------
// Options with default JsonNamingPolicy and PropertyNameCaseInsensitive = true
opts = new JsonSerializerOptions
{
    Converters = { new DynamicConverter() },
    PropertyNameCaseInsensitive = true
};

obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;

// You can use default Pascal case coding style
lowerCaseValue = obj.LowerCaseKey;
uppperCaseValue = obj.UpperCaseKey;
camelCaseValue = obj.CamelCaseKey;
kebabCaseValue = obj["kebab-case-key"]; // dash (-) symbol is not allowed in C# member name 

WriteValues();

// ----------------------------------------------------------------------------
// JsonNamingPolicy: CamelCase
opts = new JsonSerializerOptions
{
    Converters = { new DynamicConverter() },
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;

lowerCaseValue = obj.Lowercasekey;      // Lowercasekey property -> lowercasekey json key.
uppperCaseValue = obj["UPPERCASEKEY"];  // Not possible: at least the first char will be lower case.
camelCaseValue = obj.CamelCaseKey;      // CamelCaseKey property -> camelCaseKey json key.
kebabCaseValue = obj["kebab-case-key"]; // dash (-) symbol is not allowed in C# member name 

WriteValues(JsonNamingPolicy.CamelCase);

// ----------------------------------------------------------------------------
// JsonNamingPolicy: KebabCaseLower
opts = new JsonSerializerOptions
{
    Converters = { new DynamicConverter() },
    PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
};

obj = JsonSerializer.Deserialize<dynamic>(json, opts)!;

lowerCaseValue = obj.Lowercasekey;     // lowercasekey is transformed to Lowercasekey by CamelCase policy.
uppperCaseValue = obj["UPPERCASEKEY"]; // KebabCaseLower policy can't transform upper case keys, use KebabCaseUpper.
camelCaseValue = obj["camelCaseKey"];  // KebabCaseLower policy can't transform to camel case.
kebabCaseValue = obj.KebabCaseKey;     // KebabCaseLower policy behaviour.

WriteValues(JsonNamingPolicy.KebabCaseLower);

// ----------------------------------------------------------------------------
// Helper method
void WriteValues(JsonNamingPolicy? policy = null)
{
    Console.Write($"{policy?.ToString() ?? "<default>"}: ");
    Console.WriteLine($"{lowerCaseValue}, {uppperCaseValue}, {camelCaseValue}, {kebabCaseValue}");
    lowerCaseValue = uppperCaseValue = camelCaseValue = kebabCaseValue = String.Empty; 
}