using System.Text.Json;
using Jsondyno;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configure JsonSerializerOptions with Jsondyno converter
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.Converters.Add(new DynamicObjectJsonConverter());
    opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

await app.RunAsync();