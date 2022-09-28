using Roomex.Distance.Api.Calculators;
using Roomex.Distance.Api.Models;
using Xunit;

namespace Roomex.Distance.Api.Tests.Calculators;

public class PolarCoordinateFlatEarthCalculatorTests
{
    private const double Radius = 6371.00d;

    public static IEnumerable<object[]> Distances =>
        new List<object[]>
        {
            new object[] { CoordinatesFor.Dublin, CoordinatesFor.Usa, 5874.34 },
            new object[] { CoordinatesFor.Dublin, CoordinatesFor.France, 818.63 },
            new object[] { CoordinatesFor.Usa, CoordinatesFor.France, 6689.78 },
        };

    [Theory]
    [MemberData(nameof(Distances))]
    public void CalculateDistanceReturnsCorrectDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB, double expectedDistance)
    {
        var calculator = new PolarCoordinateFlatEarthCalculator();
        var distance = calculator.CalculateDistance(coordinateA, coordinateB, Radius);
        Assert.Equal(expectedDistance, distance, 2);
    }
}