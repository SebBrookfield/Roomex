using Roomex.Distance.Calculator.Converters;
using Roomex.Distance.Calculator.Enums;
using Roomex.Distance.Calculator.Factories;
using Xunit;

namespace Roomex.Distance.Api.Tests.Factories;

public class LengthConverterFactoryTests
{
    public static IEnumerable<object[]> Factories =>
        new List<object[]>
        {
            new object[] {Lengths.Kilometres, typeof(KilometreConverter)},
            new object[] {Lengths.Miles, typeof(MilesConverter)},
            new object[] {Lengths.Parsecs, typeof(ParsecConverter)}
        };

    [Theory]
    [MemberData(nameof(Factories))]
    public void FactoryReturnsCorrectType(Lengths converter, Type expectedType)
    {
        var factory = new LengthConverterFactory();
        var metreConverter = factory.GetMetreConverter(converter);
        Assert.IsType(expectedType, metreConverter);
    }

    [Fact]
    public void FactoryThrowsArgumentExceptionIfEnumIsOutOfRange()
    {
        var factory = new LengthConverterFactory();
        Assert.Throws<ArgumentOutOfRangeException>(() => factory.GetMetreConverter((Lengths) int.MaxValue));
    }
}