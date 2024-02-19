using System.Diagnostics.CodeAnalysis;

namespace Jsondyno.Internal.Dynamic;

[SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
partial class PrimitiveAdapter
{
    public static implicit operator Boolean(PrimitiveAdapter adapter) =>
        adapter.GetValue<bool>();

    public static implicit operator Byte(PrimitiveAdapter adapter) =>
        adapter.GetValue<byte>();

    public static implicit operator Int16(PrimitiveAdapter adapter) =>
        adapter.GetValue<short>();

    public static implicit operator Int32(PrimitiveAdapter adapter) =>
        adapter.GetValue<int>();

    public static implicit operator Int64(PrimitiveAdapter adapter) =>
        adapter.GetValue<long>();

    public static implicit operator SByte(PrimitiveAdapter adapter) =>
        adapter.GetValue<sbyte>();

    public static implicit operator UInt16(PrimitiveAdapter adapter) =>
        adapter.GetValue<ushort>();

    public static implicit operator UInt32(PrimitiveAdapter adapter) =>
        adapter.GetValue<uint>();

    public static implicit operator UInt64(PrimitiveAdapter adapter) =>
        adapter.GetValue<ulong>();

    public static implicit operator Single(PrimitiveAdapter adapter) =>
        adapter.GetValue<float>();

    public static implicit operator Double(PrimitiveAdapter adapter) =>
        adapter.GetValue<double>();

    public static implicit operator Decimal(PrimitiveAdapter adapter) =>
        adapter.GetValue<decimal>();

    public static implicit operator string?(PrimitiveAdapter adapter) =>
        adapter.GetValue<string>();

    public static implicit operator Guid(PrimitiveAdapter adapter) =>
        adapter.GetValue<Guid>();

    public static implicit operator DateTime(PrimitiveAdapter adapter) =>
        adapter.GetValue<DateTime>();

    public static implicit operator DateTimeOffset(PrimitiveAdapter adapter) =>
        adapter.GetValue<DateTimeOffset>();

    public static implicit operator byte[]?(PrimitiveAdapter adapter) =>
        adapter.GetValue<byte[]>();

    public static implicit operator Boolean?(PrimitiveAdapter adapter) => (Boolean)adapter;

    public static implicit operator Byte?(PrimitiveAdapter adapter) => (Byte)adapter;

    public static implicit operator Int16?(PrimitiveAdapter adapter) => (Int16)adapter;

    public static implicit operator Int32?(PrimitiveAdapter adapter) => (Int32)adapter;

    public static implicit operator Int64?(PrimitiveAdapter adapter) => (Int64)adapter;

    public static implicit operator SByte?(PrimitiveAdapter adapter) => (SByte)adapter;

    public static implicit operator UInt16?(PrimitiveAdapter adapter) => (UInt16)adapter;

    public static implicit operator UInt32?(PrimitiveAdapter adapter) => (UInt32)adapter;

    public static implicit operator UInt64?(PrimitiveAdapter adapter) => (UInt64)adapter;

    public static implicit operator Single?(PrimitiveAdapter adapter) => (Single)adapter;

    public static implicit operator Double?(PrimitiveAdapter adapter) => (Double)adapter;

    public static implicit operator Decimal?(PrimitiveAdapter adapter) => (Decimal)adapter;

    public static implicit operator Guid?(PrimitiveAdapter adapter) => (Guid)adapter;

    public static implicit operator DateTime?(PrimitiveAdapter adapter) => (DateTime)adapter;

    public static implicit operator DateTimeOffset?(PrimitiveAdapter adapter) => (DateTimeOffset)adapter;
}