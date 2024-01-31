namespace Jsondyno.Adapters.Document;

partial class JsonElementPrimitive : IPrimitive
{
    public bool GetBoolean() => Element.GetBoolean();

    public byte GetByte() => Element.GetByte();

    public short GetInt16() => Element.GetInt16();

    public int GetInt32() => Element.GetInt32();

    public long GetInt64() => Element.GetInt64();

    public sbyte GetSByte() => Element.GetSByte();

    public ushort GetUInt16() => Element.GetUInt16();

    public uint GetUInt32() => Element.GetUInt32();

    public ulong GetUInt64() => Element.GetUInt64();

    public float GetSingle() => Element.GetSingle();

    public double GetDouble() => Element.GetDouble();

    public decimal GetDecimal() => Element.GetDecimal();

    public string GetString() => Element.GetString()
        // Impossible exception because JsonElementPrimitive cannot wrap JsonValueKind.Null
        ?? throw new InvalidOperationException(SR.NullStringData);

    public Guid GetGuid() => Element.GetGuid();

    public DateTime GetDateTime() => Element.GetDateTime();

    public DateTimeOffset GetDateTimeOffset() => Element.GetDateTimeOffset();

    public byte[] GetBytesFromBase64() => Element.GetBytesFromBase64();
}