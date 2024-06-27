namespace Jsondyno.Tests.Dynamic.Auxiliary;

public static class Sample
{
    public sealed class Class
    {
        private readonly string _value;

        public Class(string value)
        {
            _value = value;
        }

        public override string ToString() => $"Sample class ({_value})";
    }

    public sealed class ClassData : TheoryData<Class>, ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var faker = fixture.Create<Faker>();
            Add(new Class(faker.Random.String2(5)));
            fixture.InjectTheoryData(this);
        }
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

    public sealed class StructData : TheoryData<Struct>, ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var faker = fixture.Create<Faker>();
            Add(new Struct(faker.Random.Int(-100, 100)));
            fixture.InjectTheoryData(this);
        }
    }

    public enum Enum
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public sealed class EnumData : TheoryData<Enum>, ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var faker = fixture.Create<Faker>();
            Add(faker.Random.Enum<Enum>());
            fixture.InjectTheoryData(this);
        }
    }
}