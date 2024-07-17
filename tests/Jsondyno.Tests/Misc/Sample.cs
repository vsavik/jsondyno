namespace Jsondyno.Tests.Misc;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class Sample
{
    public sealed class Class
    {
        public Class(string value)
        {
            StrPropertyValue = value;
        }

        public string StrPropertyValue { get; }

        public override string ToString() => $"Sample class ({StrPropertyValue})";
    }

    public readonly struct Struct
    {
        private readonly int _value;

        public Struct(int value)
        {
            _value = value;
        }

        public override string ToString() => $"Sample struct ({_value})";
    }

    public enum Enum
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
}