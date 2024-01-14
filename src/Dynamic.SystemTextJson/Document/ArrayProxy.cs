using System.Collections.ObjectModel;

namespace Dynamic.SystemTextJson.Document;

internal sealed partial class ArrayProxy : DocumentProxy
{
    private readonly List<object?> _data;

    public ArrayProxy(in JsonElement element, JsonSerializerOptions options)
        : base(in element, options)
    {
        Length = Element.GetArrayLength();
        _data = new List<object?>(Length);

        foreach (JsonElement item in Element.EnumerateArray())
        {
            DocumentProxy? itemProxy = item.CreateProxy(Options);
            _data.Add(itemProxy);
        }
    }

    public int Length { get; }

    public List<object?>.Enumerator GetEnumerator() => _data.GetEnumerator();

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        bool isConverted = true;
        if (binder.ReturnType == typeof(object[]))
        {
            result = _data.ToArray();
        }
        else if (binder.ReturnType == typeof(List<object>))
        {
            result = _data;
        }
        else if (binder.ReturnType == typeof(Collection<object>))
        {
            result = new Collection<object?>(_data);
        }
        else if (binder.ReturnType == typeof(ReadOnlyCollection<object>))
        {
            result = new ReadOnlyCollection<object?>(_data);
        }
        else
        {
            isConverted = base.TryConvert(binder, out result);
        }

        return isConverted;
    }
}