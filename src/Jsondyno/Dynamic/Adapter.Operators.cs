namespace Jsondyno.Dynamic;

[SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
partial class Adapter
{
    public static implicit operator Boolean(Adapter adapter) =>
        adapter.GetValue<bool>();

    public static implicit operator Boolean?(Adapter adapter) =>
        adapter.GetValue<bool?>();

    public static implicit operator Byte(Adapter adapter) =>
        adapter.GetValue<byte>();

    public static implicit operator Byte?(Adapter adapter) =>
        adapter.GetValue<byte?>();

    public static implicit operator Int16(Adapter adapter) =>
        adapter.GetValue<short>();

    public static implicit operator Int16?(Adapter adapter) =>
        adapter.GetValue<short?>();

    public static implicit operator Int32(Adapter adapter) =>
        adapter.GetValue<int>();

    public static implicit operator Int32?(Adapter adapter) =>
        adapter.GetValue<int?>();

    public static implicit operator Int64(Adapter adapter) =>
        adapter.GetValue<long>();

    public static implicit operator Int64?(Adapter adapter) =>
        adapter.GetValue<long?>();

    public static implicit operator SByte(Adapter adapter) =>
        adapter.GetValue<sbyte>();

    public static implicit operator SByte?(Adapter adapter) =>
        adapter.GetValue<sbyte?>();

    public static implicit operator UInt16(Adapter adapter) =>
        adapter.GetValue<ushort>();

    public static implicit operator UInt16?(Adapter adapter) =>
        adapter.GetValue<ushort?>();

    public static implicit operator UInt32(Adapter adapter) =>
        adapter.GetValue<uint>();

    public static implicit operator UInt32?(Adapter adapter) =>
        adapter.GetValue<uint?>();

    public static implicit operator UInt64(Adapter adapter) =>
        adapter.GetValue<ulong>();

    public static implicit operator UInt64?(Adapter adapter) =>
        adapter.GetValue<ulong?>();

    public static implicit operator Single(Adapter adapter) =>
        adapter.GetValue<float>();

    public static implicit operator Single?(Adapter adapter) =>
        adapter.GetValue<float?>();

    public static implicit operator Double(Adapter adapter) =>
        adapter.GetValue<double>();

    public static implicit operator Double?(Adapter adapter) =>
        adapter.GetValue<double?>();

    public static implicit operator Decimal(Adapter adapter) =>
        adapter.GetValue<decimal>();

    public static implicit operator Decimal?(Adapter adapter) =>
        adapter.GetValue<decimal?>();

    public static implicit operator string?(Adapter adapter) =>
        adapter.GetValue<string>();

    public static implicit operator Guid(Adapter adapter) =>
        adapter.GetValue<Guid>();

    public static implicit operator Guid?(Adapter adapter) =>
        adapter.GetValue<Guid?>();

    public static implicit operator DateTime(Adapter adapter) =>
        adapter.GetValue<DateTime>();

    public static implicit operator DateTime?(Adapter adapter) =>
        adapter.GetValue<DateTime?>();

    public static implicit operator DateTimeOffset(Adapter adapter) =>
        adapter.GetValue<DateTimeOffset>();

    public static implicit operator DateTimeOffset?(Adapter adapter) =>
        adapter.GetValue<DateTimeOffset?>();

    public static implicit operator byte[]?(Adapter adapter) =>
        adapter.GetValue<byte[]>();

    public static implicit operator JsonElement(Adapter adapter) =>
        adapter.JsonValue.ToJsonElement();

    public static implicit operator JsonElement?(Adapter adapter) =>
        adapter.JsonValue.ToJsonElement();

    public static implicit operator JsonNode(Adapter adapter) =>
        adapter.JsonValue.ToJsonNode();

    public static implicit operator JsonValue(Adapter adapter) =>
        adapter.JsonValue.ToJsonNode().AsValue();

    public static implicit operator JsonArray(Adapter adapter) =>
        adapter.JsonValue.ToJsonNode().AsArray();

    public static implicit operator JsonObject(Adapter adapter) =>
        adapter.JsonValue.ToJsonNode().AsObject();
}