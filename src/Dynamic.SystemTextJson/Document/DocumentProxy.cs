namespace Dynamic.SystemTextJson.Document;

internal abstract class DocumentProxy : DynamicObject
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

    protected DocumentProxy? Create(in JsonElement element) =>
        Create(in element, Options);

    public static DocumentProxy? Create(in JsonElement element, JsonSerializerOptions options)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.String:
            case JsonValueKind.Number:
                return new ValueProxy(in element, options);

            case JsonValueKind.Array:
                return new ArrayProxy(in element, options);

            case JsonValueKind.Object:
                return new ObjectProxy(in element, options);

            case JsonValueKind.Null:
                return null;

            case JsonValueKind.Undefined:
            default:
                throw new InvalidOperationException(
                    $"Cannot create proxy object for value kind {element.ValueKind}.");
        }
    }

    public static implicit operator JsonElement(DocumentProxy wrapper) => wrapper.Element;
}