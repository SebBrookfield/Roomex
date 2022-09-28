using Roomex.Distance.Api.Calculators;
using Roomex.Distance.Api.Models;
using Roomex.Distance.Api.Tests.Calculators.MockBuilders;
using Xunit;

namespace Roomex.Distance.Api.Tests.Calculators;

public class SphericalLawOfCosineDistanceCalculatorTests
{
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
        var distance = calculator.CalculateDistance(coordinateA, coordinateB);
        Assert.Equal(expectedDistance, distance, 2);
    }

    [Fact]
    public void CalculateDistanceConvertsTheDistanceIfAConverterIsProvided()
    {
        const double convertedValue = -1d;
        var calculator = new SphericalLawOfCosineDistanceCalculator();
        var mockKmBuilder = new MockKmConverterBuilder().WithReturnValue(convertedValue).Build();
        var distance = calculator.CalculateDistance(CoordinatesFor.Dublin, CoordinatesFor.Usa, mockKmBuilder);
        Assert.Equal(convertedValue, distance);
    }
}