namespace Jsondyno;

public class DynamicJsonConverter : JsonConverter<dynamic?> {
    public override dynamic? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();

    public override void Write(Utf8JsonWriter writer, dynamic? value, JsonSerializerOptions options) => throw new NotImplementedException();
}