namespace Jsondyno.Adapters.Document;

partial class JsonElementPrimitive : IPrimitive
{
    // TODO: null check
    //public string GetString() => Element.GetString()!;

    public bool GetBoolean() => throw new NotImplementedException();

    public byte GetByte() => throw new NotImplementedException();

    public short GetInt16() => throw new NotImplementedException();

    public int GetInt32() => throw new NotImplementedException();

    public long GetInt64() => throw new NotImplementedException();

    public sbyte GetSByte() => throw new NotImplementedException();

    public ushort GetUInt16() => throw new NotImplementedException();

    public uint GetUInt32() => throw new NotImplementedException();

    public ulong GetUInt64() => throw new NotImplementedException();

    public float GetSingle() => throw new NotImplementedException();

    public double GetDouble() => throw new NotImplementedException();

    public decimal GetDecimal() => throw new NotImplementedException();

    public string GetString() => throw new NotImplementedException();

    public Guid GetGuid() => throw new NotImplementedException();

    public DateTime GetDateTime() => throw new NotImplementedException();

    public DateTimeOffset GetDateTimeOffset() => throw new NotImplementedException();

    public byte[] GetBytesFromBase64() => throw new NotImplementedException();
}