namespace Jsondyno.Adapters;

internal interface IPrimitive : IValue, IValue<IPrimitive>
{
    bool GetBoolean();

    byte GetByte();

    short GetInt16();

    int GetInt32();

    long GetInt64();

    sbyte GetSByte();

    ushort GetUInt16();

    uint GetUInt32();

    ulong GetUInt64();

    float GetSingle();

    double GetDouble();

    decimal GetDecimal();

    string GetString();

    Guid GetGuid();

    DateTime GetDateTime();

    DateTimeOffset GetDateTimeOffset();

    byte[] GetBytesFromBase64();
}