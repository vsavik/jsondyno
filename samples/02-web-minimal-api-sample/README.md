# Minimal API Example

This example shows how to use `dynamic` object in AspNetCore [MinimalAPIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview).

## Configuration

In [Program.cs](./Program.cs) add `Jsondyno.DynamicObjectJsonConverter` to JsonSerializerOptions configuration as below:

```csharp
builder.Services.ConfigureHttpJsonOptions(opts =>
{
    // Required
    opts.SerializerOptions.Converters.Add(
        new Jsondyno.DynamicObjectJsonConverter());

    // Custom configs
    opts.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
```

## Usage

Use `dynamic` keyword in MapXxx method parameter. Typical usage: POST request and JSON data in request body.

```csharp
app.MapPost("/", (dynamic body) => /* Implementation */);
```

See [Program.cs](./Program.cs) implementation.

Nullable context: if body can be null, use `dynamic?` parameter.

## Run sample

Use `dotnet run` command to start API.

### Test using curl utility

```shell
curl -X 'POST' -H 'Content-Type: application/json'  -d '{ "firstName": "John", "lastName": "Doe" }' http://localhost:5182/
```

### Test using VS code REST Client extension:

Open [Jsondyno.MinimalWebApi.http](Jsondyno.MinimalWebApi.http) file and click `Send request`.