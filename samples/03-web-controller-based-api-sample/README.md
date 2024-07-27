# MVC Example

This example shows how to use `dynamic` object as Controller action parameter.

## Configuration

In [Program.cs](./Program.cs) add `Jsondyno.DynamicObjectJsonConverter` to JsonSerializerOptions configuration as below:

```csharp
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    // Required
    opts.JsonSerializerOptions.Converters.Add(
        new DynamicObjectJsonConverter());

    // Custom configs
    opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
```

## Usage

Use `dynamic` keyword in action parameter. Typical usage: POST request and JSON data in request body.

```csharp
[HttpPost]
public IActionResult Submit([FromBody] dynamic body)
{
    // Implementation
}
```

See [DefaultController](./Controllers/DefaultController.cs) implementation.

Nullable context: if body can be null, use `dynamic?` parameter.

## Run sample

Use `dotnet run` command to start API.

### Test using curl utility

```shell
curl -X 'POST' -H 'Content-Type: application/json'  -d '{ "firstName": "John", "lastName": "Doe" }' http://localhost:5056/
```

### Test using Swagger UI

Navigate http://localhost:5056 in your browser and use provided endpoint with the following sample body:

```json
{
    "firstName": "John",
    "lastName": "Doe"
}
```

### Test using VS code REST Client extension:

Open [Jsondyno.ControllerBasedApi.http](Jsondyno.ControllerBasedApi.http) file and click `Send request`.