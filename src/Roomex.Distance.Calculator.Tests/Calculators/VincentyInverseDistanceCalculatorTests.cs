using Roomex.Distance.Api.Calculators;
using Roomex.Distance.Api.Models;
using Roomex.Distance.Api.Tests.MockBuilders;
using Xunit;

namespace Roomex.Distance.Api.Tests.Calculators;

public class VincentyInverseDistanceCalculatorTests
{
    public static IEnumerable<object[]> Distances =>
        new List<object[]>
        {
            new object[] { CoordinatesFor.Dublin, CoordinatesFor.Usa, 5551627.48d },
            new object[] { CoordinatesFor.Dublin, CoordinatesFor.France, 781955.45d },
            new object[] { CoordinatesFor.Usa, CoordinatesFor.France, 6301353.69d }
        };

    [Theory]
    [MemberData(nameof(Distances))]
    public void CalculateDistanceReturnsCorrectDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB, double expectedDistance)
    {
        var calculator = new VincentyInverseDistanceCalculator();
        var distance = calculator.CalculateDistance(coordinateA, coordinateB);
        Assert.Equal(expectedDistance, distance, 2);
    }

    [Fact]
    public void CalculateDistanceConvertsTheDistanceIfAConverterIsProvided()
    {
        const double convertedValue = -1d;
        var calculator = new VincentyInverseDistanceCalculator();
        var mockKmBuilder = new MockMetreConverterBuilder().WithReturnValue(convertedValue).Build();
        var distance = calculator.CalculateDistance(CoordinatesFor.Dublin, CoordinatesFor.Usa, mockKmBuilder);
        Assert.Equal(convertedValue, distance);
    }
}