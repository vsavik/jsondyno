namespace Jsondyno.Dynamic;

[SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
partial class Adapter
{
    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Boolean"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Boolean"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Boolean(Adapter adapter) =>
        adapter.GetValue<bool>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Boolean"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Boolean"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Boolean?(Adapter adapter) =>
        adapter.GetValue<bool?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Byte"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Byte"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Byte(Adapter adapter) =>
        adapter.GetValue<byte>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Byte"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Byte"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Byte?(Adapter adapter) =>
        adapter.GetValue<byte?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Int16"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Int16"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Int16(Adapter adapter) =>
        adapter.GetValue<short>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Int16"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Int16"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Int16?(Adapter adapter) =>
        adapter.GetValue<short?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Int32"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Int32"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Int32(Adapter adapter) =>
        adapter.GetValue<int>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Int32"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Int32"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Int32?(Adapter adapter) =>
        adapter.GetValue<int?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Int64"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Int64"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Int64(Adapter adapter) =>
        adapter.GetValue<long>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Int64"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Int64"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Int64?(Adapter adapter) =>
        adapter.GetValue<long?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="SByte"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="SByte"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator SByte(Adapter adapter) =>
        adapter.GetValue<sbyte>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="SByte"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="SByte"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator SByte?(Adapter adapter) =>
        adapter.GetValue<sbyte?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="UInt16"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="UInt16"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator UInt16(Adapter adapter) =>
        adapter.GetValue<ushort>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="UInt16"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="UInt16"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator UInt16?(Adapter adapter) =>
        adapter.GetValue<ushort?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="UInt32"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="UInt32"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator UInt32(Adapter adapter) =>
        adapter.GetValue<uint>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="UInt32"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="UInt32"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator UInt32?(Adapter adapter) =>
        adapter.GetValue<uint?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="UInt64"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="UInt64"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator UInt64(Adapter adapter) =>
        adapter.GetValue<ulong>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="UInt64"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="UInt64"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator UInt64?(Adapter adapter) =>
        adapter.GetValue<ulong?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Single"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Single"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Single(Adapter adapter) =>
        adapter.GetValue<float>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Single"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Single"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Single?(Adapter adapter) =>
        adapter.GetValue<float?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Double"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Double"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Double(Adapter adapter) =>
        adapter.GetValue<double>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Double"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Double"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Double?(Adapter adapter) =>
        adapter.GetValue<double?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Decimal"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Decimal"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Decimal(Adapter adapter) =>
        adapter.GetValue<decimal>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Decimal"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Decimal"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Decimal?(Adapter adapter) =>
        adapter.GetValue<decimal?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="string"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="string"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator string?(Adapter adapter) =>
        adapter.GetValue<string>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Guid"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Guid"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Guid(Adapter adapter) =>
        adapter.GetValue<Guid>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="Guid"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="Guid"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator Guid?(Adapter adapter) =>
        adapter.GetValue<Guid?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="DateTime"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="DateTime"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator DateTime(Adapter adapter) =>
        adapter.GetValue<DateTime>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="DateTime"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="DateTime"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator DateTime?(Adapter adapter) =>
        adapter.GetValue<DateTime?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="DateTimeOffset"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="DateTimeOffset"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator DateTimeOffset(Adapter adapter) =>
        adapter.GetValue<DateTimeOffset>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="DateTimeOffset"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="DateTimeOffset"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator DateTimeOffset?(Adapter adapter) =>
        adapter.GetValue<DateTimeOffset?>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="T:byte[]"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="T:byte[]"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator byte[]?(Adapter adapter) =>
        adapter.GetValue<byte[]>();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="JsonElement"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="JsonElement"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator JsonElement(Adapter adapter) =>
        adapter.JsonValue.ToJsonElement();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="JsonElement"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="JsonElement"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator JsonElement?(Adapter adapter) =>
        adapter.JsonValue.ToJsonElement();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="JsonNode"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="JsonNode"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator JsonNode(Adapter adapter) =>
        adapter.JsonValue.ToJsonNode();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="JsonValue"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="JsonValue"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator JsonValue(Adapter adapter) =>
        adapter.JsonValue.ToJsonNode().AsValue();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="JsonArray"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="JsonArray"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator JsonArray(Adapter adapter) =>
        adapter.JsonValue.ToJsonNode().AsArray();

    /// <summary>
    ///   Defines an implicit conversion of a given <see cref="Adapter"/> to a <see cref="JsonObject"/>.
    /// </summary>
    /// <param name="adapter">A <see cref="Adapter"/> to implicitly convert.</param>
    /// <returns>A <see cref="JsonObject"/> instance converted from the <paramref name="adapter"/> parameter.</returns>
    public static implicit operator JsonObject(Adapter adapter) =>
        adapter.JsonValue.ToJsonNode().AsObject();
}