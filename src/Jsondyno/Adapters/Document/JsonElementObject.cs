using System.Collections;

namespace Jsondyno.Adapters.Document;

internal sealed partial class JsonElementObject : JsonElementValue<IObject>
{
    private readonly Dictionary<string, object?> _data;

    public JsonElementObject(in JsonElement element, JsonSerializerOptions options)
        : base(in element, options)
    {
        IEqualityComparer<string> comparer = Options.PropertyNameCaseInsensitive
            ? StringComparer.OrdinalIgnoreCase
            : StringComparer.Ordinal;

        _data = new Dictionary<string, object?>(comparer);
    }

    protected override IObject Self => this;
}