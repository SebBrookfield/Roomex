using Roomex.Distance.Api.Converters;
using Roomex.Distance.Api.Enums;
using Roomex.Distance.Api.Factories;
using Xunit;

namespace Roomex.Distance.Api.Tests.Factories;

public class LengthConverterFactoryTests
{
    public static IEnumerable<object[]> Factories =>
        new List<object[]>
        {
            new object[] {LengthConverters.Kilometres, typeof(KilometreConverter)},
            new object[] {LengthConverters.Miles, typeof(MilesConverter)},
            new object[] {LengthConverters.Parsecs, typeof(ParsecConverter)}
        };

    [Theory]
    [MemberData(nameof(Factories))]
    public void FactoryReturnsCorrectType(LengthConverters converter, Type expectedType)
    {
        var factory = new LengthConverterFactory();
        var metreConverter = factory.GetMetreConverter(converter);
        Assert.IsType(expectedType, metreConverter);
    }

    [Fact]
    public void FactoryThrowsArgumentExceptionIfEnumIsOutOfRange()
    {
        var factory = new LengthConverterFactory();
        Assert.Throws<ArgumentOutOfRangeException>(() => factory.GetMetreConverter((LengthConverters) int.MaxValue));
    }
}