using System.Reflection;
using AutoFixture.Kernel;
using Xunit.Sdk;

namespace Jsondyno.Tests.Misc;

[DataDiscoverer("Jsondyno.Tests.Misc." + nameof(FixtureDataDiscoverer), "Jsondyno.Tests")]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class FixtureDataAttribute<TCustomization> : DataAttribute
    where TCustomization : ICustomization, new()
{
    private readonly Fixture _fixture;

    public FixtureDataAttribute()
    {
        _fixture = new Fixture();
        _fixture.Register(() => new Faker());
        _fixture.Register((TheoryDataFactory factory) => factory.CreateTheoryData());
        _fixture.Customize(new TCustomization());
    }

    public override IEnumerable<object?[]> GetData(MethodInfo testMethod)
    {
        _fixture.Inject(new TheoryDataFactory(_fixture, testMethod));
        var data = _fixture.Create<TheoryData>();

        return data;
    }

    private sealed class TheoryDataFactory
    {
        private readonly Fixture _fixture;

        private readonly MethodInfo _testMethod;

        public TheoryDataFactory(Fixture fixture, MethodInfo testMethod)
        {
            _fixture = fixture;
            _testMethod = testMethod;
        }

        public TheoryData CreateTheoryData()
        {
            ParameterInfo[] parameters = _testMethod.GetParameters();
            object?[] result = new object?[parameters.Length];
            var context = new SpecimenContext(_fixture);

            for (int i = 0; i < parameters.Length; i++)
            {
                result[i] = CreateParameterValue(context, parameters[i]);
            }

            return new TheoryData<object?>(result);
        }

        private object? CreateParameterValue(SpecimenContext context, ParameterInfo parameter)
        {
            IEnumerable<ICustomization> customizations = parameter
                .GetCustomAttributes()
                .OfType<IParameterCustomizationSource>()
                .Select(x => x.GetCustomization(parameter));

            foreach (ICustomization customization in customizations)
            {
                _fixture.Customize(customization);
            }

            return context.Resolve(parameter);
        }
    }
}