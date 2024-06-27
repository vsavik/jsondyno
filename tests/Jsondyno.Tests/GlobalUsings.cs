global using System.Linq.Expressions;
global using System.Text.Json;
// External dependencies
global using Bogus;
global using AutoFixture;
global using Moq;
global using Shouldly;
global using Xunit;
global using Xunit.Abstractions;

// Internal dependencies
global using Jsondyno.Internal;
global using Jsondyno.Internal.Dynamic;
global using Jsondyno.Misc;
global using Jsondyno.Tests.Fixtures;
global using Jsondyno.Tests.Misc;
global using Jsondyno.Tests.Misc.Customizations;

// Type aliases
global using RandomInt32 = Jsondyno.Tests.Misc.RandomNumberAttribute<int>;
global using RandomWordsAttribute =
    Jsondyno.Tests.Misc.FixtureValueAttribute<Jsondyno.Tests.Misc.Customizations.RandomWords>;