using Roomex.Distance.Api.Converters;
using Xunit;

namespace Roomex.Distance.Api.Tests.Converters;

public class LengthConverterTests
{
    private const double Metres = 5551000;

    public static IEnumerable<object[]> Conversions =>
        new List<object[]>
        {
            new object[] { 1.798957e-10d, new ParsecConverter() },
            new object[] { 5551.0000d, new KilometreConverter() },
            new object[] { 3449.2315d, new MilesConverter() }
        };

    [Theory]
    [MemberData(nameof(Conversions))]
    public void ConvertsConvertCorrectly(double expected, ILengthConverter converter)
    {
        Assert.Equal(expected, converter.ConvertFromMetres(Metres), 4);
    }
}