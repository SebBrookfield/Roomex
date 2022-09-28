using Roomex.Distance.Api.Calculators;
using Roomex.Distance.Api.Models;
using Xunit;

namespace Roomex.Distance.Api.Tests.Calculators;

public class SphericalLawOfCosineDistanceCalculatorTests
{
    private const double Radius = 6371.00d;

    public static IEnumerable<object[]> Distances =>
        new List<object[]>
        {
            new object[] { CoordinatesFor.Dublin, CoordinatesFor.Usa, 5536.34 },
            new object[] { CoordinatesFor.Dublin, CoordinatesFor.France, 780.33 },
            new object[] { CoordinatesFor.Usa, CoordinatesFor.France, 6284 }
        };

    [Theory]
    [MemberData(nameof(Distances))]
    public void CalculateDistanceReturnsCorrectDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB, double expectedDistance)
    {
        var calculator = new SphericalLawOfCosineDistanceCalculator();
        var distance = calculator.CalculateDistance(coordinateA, coordinateB, Radius);
        Assert.Equal(expectedDistance, distance, 2);
    }
}