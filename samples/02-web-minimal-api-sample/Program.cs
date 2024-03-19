using System.Text.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(opts =>
{
    JsonSerializerOptions options = opts.SerializerOptions;
    options.Converters.Add(new Jsondyno.DynamicConverter());
    options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/", (dynamic body) => $"Result is First Name: {body.FirstName}, Last Name: {body.LastName}");

await app.RunAsync();