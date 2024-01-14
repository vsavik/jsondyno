namespace Dynamic.SystemTextJson.Document;

internal abstract partial class DocumentProxy : DynamicObject
{
    private readonly JsonElement _element;

    protected DocumentProxy(
        in JsonElement element,
        JsonSerializerOptions options)
    {
        _element = element;
        Options = options;
    }

    protected JsonSerializerOptions Options { get; }

    protected ref readonly JsonElement Element => ref _element;

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = Element.Deserialize(binder.ReturnType, Options);

        return true;
    }

    public T As<T>() => (T)(dynamic)this;

    public T To<T>() => Element.Deserialize<T>(Options)!;
}