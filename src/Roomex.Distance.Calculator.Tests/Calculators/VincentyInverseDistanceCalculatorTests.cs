using Roomex.Distance.Api.Tests.MockBuilders;
using Roomex.Distance.Calculator.Calculators;
using Roomex.Distance.Calculator.Models;
using Xunit;

namespace Roomex.Distance.Api.Tests.Calculators;

public class VincentyInverseDistanceCalculatorTests
{
    public static IEnumerable<object[]> Distances =>
        new List<object[]>
        {
            new object[] { CoordinatesFor.Dublin, CoordinatesFor.Usa, 5551492.66d },
            new object[] { CoordinatesFor.Dublin, CoordinatesFor.France,781955.22d },
            new object[] { CoordinatesFor.Usa, CoordinatesFor.France, 6301136.43d }
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