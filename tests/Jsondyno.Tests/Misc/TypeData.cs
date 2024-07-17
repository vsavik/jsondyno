using System.Numerics;

namespace Jsondyno.Tests.Misc;

public class TypeData
{
    private static readonly DateTime s_date = new(2023, 12, 28, 14, 47, 8, DateTimeKind.Utc);

    internal static IEnumerable BclTypes => CreateBclTypesTestCases();

    internal static IEnumerable UserTypes => CreateUserTypesTestCases();

    internal static IEnumerable JsonTypes => CreateJsonTypesTestCases();

    internal static IEnumerable TypeInstances => CreateTypeInstancesTestCases();

    private static IEnumerable<TestCaseData> CreateBclTypesTestCases()
    {
        yield return CreateTestCaseOfType<bool>();
        yield return CreateTestCaseOfType<sbyte>();
        yield return CreateTestCaseOfType<short>();
        yield return CreateTestCaseOfType<int>();
        yield return CreateTestCaseOfType<long>();
        yield return CreateTestCaseOfType<byte>();
        yield return CreateTestCaseOfType<ushort>();
        yield return CreateTestCaseOfType<uint>();
        yield return CreateTestCaseOfType<ulong>();
        yield return CreateTestCaseOfType<float>();
        yield return CreateTestCaseOfType<double>();
        yield return CreateTestCaseOfType<decimal>();
        yield return CreateTestCaseOfType<Guid>();
        yield return CreateTestCaseOfType<DateTime>();
        yield return CreateTestCaseOfType<DateTimeOffset>();

        yield return CreateTestCaseOfType<bool?>();
        yield return CreateTestCaseOfType<sbyte?>();
        yield return CreateTestCaseOfType<short?>();
        yield return CreateTestCaseOfType<int?>();
        yield return CreateTestCaseOfType<long?>();
        yield return CreateTestCaseOfType<byte?>();
        yield return CreateTestCaseOfType<ushort?>();
        yield return CreateTestCaseOfType<uint?>();
        yield return CreateTestCaseOfType<ulong?>();
        yield return CreateTestCaseOfType<float?>();
        yield return CreateTestCaseOfType<double?>();
        yield return CreateTestCaseOfType<decimal?>();
        yield return CreateTestCaseOfType<Guid?>();
        yield return CreateTestCaseOfType<DateTime?>();
        yield return CreateTestCaseOfType<DateTimeOffset?>();

        yield return CreateTestCaseOfType<string>();
        yield return CreateTestCaseOfType<byte[]>();
    }

    private static IEnumerable<TestCaseData> CreateJsonTypesTestCases()
    {
        yield return CreateTestCaseOfType<JsonElement>();
        yield return CreateTestCaseOfType<JsonElement?>();
        yield return CreateTestCaseOfType<JsonNode>();
    }

    private static IEnumerable<TestCaseData> CreateUserTypesTestCases()
    {
        yield return CreateTestCaseOfType<string[]>();
        yield return CreateTestCaseOfType<Dictionary<string, int?>>();
        yield return CreateTestCaseOfType<List<bool?>>();
        yield return CreateTestCaseOfType<Sample.Enum>();
        yield return CreateTestCaseOfType<Sample.Enum?>();
        yield return CreateTestCaseOfType<Sample.Struct>();
        yield return CreateTestCaseOfType<Sample.Struct?>();
        yield return CreateTestCaseOfType<Sample.Class>();
    }

    private static TestCaseData CreateTestCaseOfType<T>()
    {
        var testCase = new TestCaseData { TypeArgs = [typeof(T)] };
        testCase.SetName(typeof(T).ToPrettyString());

        return testCase;
    }

    private static IEnumerable<TestCaseData> CreateTypeInstancesTestCases()
    {
        yield return CreateTestCaseOfType(String.Empty);
        yield return CreateTestCaseOfType("string test");
        yield return CreateTestCaseOfType<byte[]>([2, 3, 5, 8, 13]);
        yield return CreateTestCaseOfType<string[]>(["a", "1", "bc"]);
        yield return CreateTestCaseOfType<List<bool?>>([true, null, false, true]);
        yield return CreateTestCaseOfType(new Dictionary<string, int?>
        {
            ["Value"] = 24, ["Null"] = null, ["Value2"] = 17,
        });

        yield return CreateTestCaseOfType(true);
        yield return CreateTestCaseOfType(false);
        yield return CreateTestCaseOfType<bool?>(true);
        yield return CreateTestCaseOfType<bool?>(false);

        yield return CreateTestCaseOfType(Guid.Empty);
        yield return CreateTestCaseOfType(Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"));
        yield return CreateTestCaseOfType<Guid?>(Guid.Empty);
        yield return CreateTestCaseOfType<Guid?>(Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"));

        yield return CreateTestCaseOfType(DateTime.MinValue);
        yield return CreateTestCaseOfType(DateTime.MaxValue);
        yield return CreateTestCaseOfType(s_date);
        yield return CreateTestCaseOfType<DateTime?>(DateTime.MinValue);
        yield return CreateTestCaseOfType<DateTime?>(DateTime.MaxValue);
        yield return CreateTestCaseOfType<DateTime?>(s_date);

        yield return CreateTestCaseOfType(DateTimeOffset.MinValue);
        yield return CreateTestCaseOfType(DateTimeOffset.MaxValue);
        yield return CreateTestCaseOfType<DateTimeOffset>(s_date);
        yield return CreateTestCaseOfType<DateTimeOffset?>(DateTimeOffset.MinValue);
        yield return CreateTestCaseOfType<DateTimeOffset?>(DateTimeOffset.MaxValue);
        yield return CreateTestCaseOfType<DateTimeOffset?>(s_date);

        yield return CreateTestCaseOfType(new Sample.Class("Rock"));
        yield return CreateTestCaseOfType(Sample.Enum.Four);
        yield return CreateTestCaseOfType(new Sample.Struct(17));
        yield return CreateTestCaseOfType<Sample.Enum?>(Sample.Enum.Four);
        yield return CreateTestCaseOfType<Sample.Struct?>(new Sample.Struct(17));

        TestCaseData[] numberTestCases =
        [
            .. CreateTestCasesOfUnsignedNumber<byte>(),
            .. CreateTestCasesOfUnsignedNumber<ushort>(),
            .. CreateTestCasesOfUnsignedNumber<uint>(),
            .. CreateTestCasesOfUnsignedNumber<ulong>(),
            .. CreateTestCasesOfSignedNumber<sbyte>(),
            .. CreateTestCasesOfSignedNumber<short>(),
            .. CreateTestCasesOfSignedNumber<int>(),
            .. CreateTestCasesOfSignedNumber<long>(),
            .. CreateTestCasesOfSignedNumber<float>(),
            .. CreateTestCasesOfSignedNumber<double>(),
            .. CreateTestCasesOfSignedNumber<decimal>()
        ];

        foreach (TestCaseData testCaseData in numberTestCases)
        {
            yield return testCaseData;
        }
    }

    private static TestCaseData CreateTestCaseOfType<T>(T item)
    {
        var testCase = new TestCaseData(item) { TypeArgs = [typeof(T)] };
        testCase.SetName($"{typeof(T).ToPrettyString()}: {{p}}");

        return testCase;
    }

    private static IEnumerable<TestCaseData> CreateTestCasesOfSignedNumber<TNumber>()
        where TNumber : struct, ISignedNumber<TNumber>, IMinMaxValue<TNumber>
    {
        yield return CreateTestCaseOfType(TNumber.MinValue);
        yield return CreateTestCaseOfType(-TNumber.One);
        yield return CreateTestCaseOfType(TNumber.Zero);
        yield return CreateTestCaseOfType(TNumber.One);
        yield return CreateTestCaseOfType(TNumber.MaxValue);

        yield return CreateTestCaseOfType<TNumber?>(TNumber.MinValue);
        yield return CreateTestCaseOfType<TNumber?>(-TNumber.One);
        yield return CreateTestCaseOfType<TNumber?>(TNumber.Zero);
        yield return CreateTestCaseOfType<TNumber?>(TNumber.One);
        yield return CreateTestCaseOfType<TNumber?>(TNumber.MaxValue);
    }

    private static IEnumerable<TestCaseData> CreateTestCasesOfUnsignedNumber<TNumber>()
        where TNumber : struct, IUnsignedNumber<TNumber>, IMinMaxValue<TNumber>
    {
        yield return CreateTestCaseOfType(TNumber.Zero);
        yield return CreateTestCaseOfType(TNumber.One);
        yield return CreateTestCaseOfType(TNumber.MaxValue);

        yield return CreateTestCaseOfType<TNumber?>(TNumber.Zero);
        yield return CreateTestCaseOfType<TNumber?>(TNumber.One);
        yield return CreateTestCaseOfType<TNumber?>(TNumber.MaxValue);
    }
}