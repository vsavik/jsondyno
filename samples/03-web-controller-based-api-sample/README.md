# MVC Example

This example shows how to use `dynamic` object as Controller action parameter.

## Configuration

In [Program.cs](./Program.cs) add `Jsondyno.DynamicConverter` to JsonSerializerOptions configuration as below:

```cs
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    JsonSerializerOptions options = opts.JsonSerializerOptions;

    // Required
    options.Converters.Add(new DynamicConverter());

    // Custom configs
    options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
```

## Usage

Use `dynamic` keyword in action parameter. Typical usage: POST request and JSON data in request body.

```cs
[HttpPost]
public IActionResult Submit([FromBody] dynamic body)
{
    // Implementation
}
```

See [DefaultController](./Controllers/DefaultController.cs) implementation.

Nullable context: if body can be null or empty, use `dynamic?` parameter.

## Run sample

Use `dotnet run` command to start API.

### Test using curl utility

```sh
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
