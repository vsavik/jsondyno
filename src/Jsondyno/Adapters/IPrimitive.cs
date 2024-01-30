namespace Jsondyno.Adapters;

internal interface IPrimitive : IValue, IValue<IPrimitive>
{
    /*

    bool GetBoolean();

    GetByte()

    GetInt16()

    GetInt32()

    GetInt64()

    GetSByte()

    GetUInt16()

    GetUInt32()

    GetUInt64()

    GetSingle()

    GetDouble()

    GetDecimal()*/

    string GetString();

    /*
    Guid GetGuid();

    DateTime GetDateTime();

    DateTimeOffset GetDateTimeOffset();

    byte[] GetBytesFromBase64();*/
}