namespace Jsondyno.Tests.Dynamic.Auxiliary;

public static class DateTimeData
{
    private static readonly DateTime s_minDate = new(2023, 12, 28);

    private static readonly DateTime s_maxDate = new(2024, 6, 5);

    public sealed class MinMax : TheoryData<DateTime>
    {
        public MinMax()
        {
            Add(DateTime.MinValue);
            Add(DateTime.MaxValue);
        }
    }

    public sealed class MinMaxOffset : TheoryData<DateTimeOffset>
    {
        public MinMaxOffset()
        {            
            Add(DateTimeOffset.MinValue);
            Add(DateTimeOffset.MaxValue);
        }
    }

    public sealed class Random : TheoryData<DateTime>, ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize(new RandomPrimitives());
            var generator = fixture.Create<GenerateRandomBetweenDelegate<DateTime>>();

            Add(generator(s_minDate, s_maxDate));

            fixture.InjectTheoryData(this);
        }
    }

    public sealed class RandomOffset : TheoryData<DateTimeOffset>, ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize(new RandomPrimitives());
            var generator = fixture.Create<GenerateRandomBetweenDelegate<DateTimeOffset>>();

            Add(generator(s_minDate, s_maxDate));

            fixture.InjectTheoryData(this);
        }
    }
}