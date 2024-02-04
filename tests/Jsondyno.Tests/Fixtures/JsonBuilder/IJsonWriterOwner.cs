namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal interface IJsonWriterOwner
{
    Utf8JsonWriter JsonWriter { get; }
}