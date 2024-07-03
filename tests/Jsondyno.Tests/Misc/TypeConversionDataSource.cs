using NUnit.Framework.Interfaces;

namespace Jsondyno.Tests.Misc;

public sealed class TypeConversionDataSource : IEnumerable
{
    private readonly Fixture _fixture = new();

    public IEnumerator GetEnumerator()
    {
        yield return Make(true);
        yield return Make(Random.Shared.Next(1, 10));
        yield return Make((int?)Random.Shared.Next(1, 10));
    }

    private ITestFixtureData Make<T>(T item)
    {
        return new Data<T>(item);
    }

    public sealed class Data<T> : NUnit.Framework.Internal.TestParameters, ITestFixtureData
    {
        public Data(T item)
            : base([item])
        {
            //TestName = $"Rand test {typeof(T)}";
        }

        public Type[]? TypeArgs { get; } = [typeof(T)];
    }
}