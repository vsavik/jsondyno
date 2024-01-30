using System.Diagnostics.CodeAnalysis;

namespace Jsondyno.Adapters.Dynamic;

[SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
internal sealed class PrimitiveAdapter : ValueAdapter<IPrimitive>
{
    public PrimitiveAdapter(IPrimitive value)
        : base(value)
    {
    }

    public static implicit operator Boolean(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetBoolean());

    public static implicit operator Boolean?(PrimitiveAdapter adapter) => (Boolean)adapter;

    public static implicit operator Byte(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetByte());

    public static implicit operator Byte?(PrimitiveAdapter adapter) => (Byte)adapter;

    public static implicit operator Int16(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetInt16());

    public static implicit operator Int16?(PrimitiveAdapter adapter) => (Int16)adapter;

    public static implicit operator Int32(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetInt32());

    public static implicit operator Int32?(PrimitiveAdapter adapter) => (Int32)adapter;

    public static implicit operator Int64(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetInt64());

    public static implicit operator Int64?(PrimitiveAdapter adapter) => (Int64)adapter;

    public static implicit operator SByte(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetSByte());

    public static implicit operator SByte?(PrimitiveAdapter adapter) => (SByte)adapter;

    public static implicit operator UInt16(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetUInt16());

    public static implicit operator UInt16?(PrimitiveAdapter adapter) => (UInt16)adapter;

    public static implicit operator UInt32(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetUInt32());

    public static implicit operator UInt32?(PrimitiveAdapter adapter) => (UInt32)adapter;

    public static implicit operator UInt64(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetUInt64());

    public static implicit operator UInt64?(PrimitiveAdapter adapter) => (UInt64)adapter;

    public static implicit operator Single(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetSingle());

    public static implicit operator Single?(PrimitiveAdapter adapter) => (Single)adapter;

    public static implicit operator Double(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetDouble());

    public static implicit operator Double?(PrimitiveAdapter adapter) => (Double)adapter;

    public static implicit operator Decimal(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetDecimal());

    public static implicit operator Decimal?(PrimitiveAdapter adapter) => (Decimal)adapter;

    public static implicit operator string?(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetString());

    public static implicit operator Guid(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetGuid());

    public static implicit operator Guid?(PrimitiveAdapter adapter) => (Guid)adapter;

    public static implicit operator DateTime(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetDateTime());

    public static implicit operator DateTime?(PrimitiveAdapter adapter) => (DateTime)adapter;

    public static implicit operator DateTimeOffset(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetDateTimeOffset());

    public static implicit operator DateTimeOffset?(PrimitiveAdapter adapter) => (DateTimeOffset)adapter;

    public static implicit operator byte[]?(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetBytesFromBase64());
}