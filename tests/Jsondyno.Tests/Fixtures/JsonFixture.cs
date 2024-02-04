using System.Diagnostics;
using System.Text;
using Jsondyno.Tests.Fixtures.JsonBuilder;

namespace Jsondyno.Tests.Fixtures;

public sealed class JsonFixture :
    IJsonResult,
    IJsonWriterOwner,
    IDisposable,
    IAsyncDisposable
{
    private readonly MemoryStream _stream;

    public JsonFixture()
    {
        _stream = new MemoryStream();
        var opts = new JsonWriterOptions { Indented = true, SkipValidation = false };
        JsonWriter = new Utf8JsonWriter(_stream, opts);
    }

    public Utf8JsonWriter JsonWriter { get; }

    internal IJsonBuilder Builder => JsonBuilderFactory.Create(this);

    public Stream GetStream()
    {
        JsonWriter.Flush();
        _stream.Seek(0L, SeekOrigin.Begin);

        return _stream;
    }

    public string GetString()
    {
        JsonWriter.Flush();
        bool isSuccess = _stream.TryGetBuffer(out ArraySegment<byte> buffer);
        Debug.Assert(isSuccess, $"Check {_stream} ctor.");

        return Encoding.UTF8.GetString(buffer);
    }

    public void Dispose()
    {
        JsonWriter.Dispose();
        _stream.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await JsonWriter.DisposeAsync();
        await _stream.DisposeAsync();
    }
}