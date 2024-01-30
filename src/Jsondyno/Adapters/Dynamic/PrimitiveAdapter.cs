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
        throw new NotImplementedException();

    public static implicit operator Boolean?(PrimitiveAdapter adapter) => (Boolean  )adapter;

    public static implicit operator Byte(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator Byte?(PrimitiveAdapter adapter) => (Byte)adapter;

    public static implicit operator Int16(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator Int16?(PrimitiveAdapter adapter) => (Int16)adapter;

    public static implicit operator Int32(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator Int32?(PrimitiveAdapter adapter) => (Int32)adapter;

    public static implicit operator Int64(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator Int64?(PrimitiveAdapter adapter) => (Int64)adapter;

    public static implicit operator SByte(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator SByte?(PrimitiveAdapter adapter) => (SByte)adapter;

    public static implicit operator UInt16(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator UInt16?(PrimitiveAdapter adapter) => (UInt16)adapter;

    public static implicit operator UInt32(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator UInt32?(PrimitiveAdapter adapter) => (UInt32)adapter;

    public static implicit operator UInt64(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator UInt64?(PrimitiveAdapter adapter) => (UInt64)adapter;

    public static implicit operator Single(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator Single?(PrimitiveAdapter adapter) => (Single)adapter;

    public static implicit operator Double(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator Double?(PrimitiveAdapter adapter) => (Double)adapter;

    public static implicit operator Decimal(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator Decimal?(PrimitiveAdapter adapter) => (Decimal)adapter;

    public static implicit operator string?(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetString());

    public static implicit operator Guid(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator Guid?(PrimitiveAdapter adapter) => (Guid)adapter;

    public static implicit operator DateTime(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator DateTime?(PrimitiveAdapter adapter)  => (DateTime)adapter;

    public static implicit operator DateTimeOffset(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator DateTimeOffset?(PrimitiveAdapter adapter) => (DateTimeOffset)adapter;

    public static implicit operator byte[]?(PrimitiveAdapter adapter) =>
        throw new NotImplementedException();
}