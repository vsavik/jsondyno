namespace Dynamic.SystemTextJson.Document;

internal sealed class ArrayProxy : DocumentProxy
{
    private readonly List<object?> _data;

    public ArrayProxy(in JsonElement element, JsonSerializerOptions options)
        : base(in element, options)
    {
        Length = Element.GetArrayLength();
        _data = new List<object?>(Length);
        
        foreach (JsonElement item in Element.EnumerateArray())
        {
            // TODO: initialize data
        }
    }

    public int Length { get; }

    public object? this[int index]
    {
        get => _data[index];
        set => throw new NotSupportedException(
            "Dynamic object based on JsonElement is read-only.");
    }
}