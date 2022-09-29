using Roomex.Distance.Calculator.Calculators;
using Roomex.Distance.Calculator.Enums;
using Roomex.Distance.Calculator.Factories;
using Xunit;

namespace Roomex.Distance.Api.Tests.Factories;

public class DistanceCalculatorFactoryTests
{
    public static IEnumerable<object[]> Factories =>
        new List<object[]>
        {
            new object[] {DistanceCalculators.PolarCoordinateFlatEarth, typeof(PolarCoordinateFlatEarthCalculator)},
            new object[] {DistanceCalculators.SphericalLawOfCosine, typeof(SphericalLawOfCosineDistanceCalculator)},
            new object[] {DistanceCalculators.VincentyInverse, typeof(VincentyInverseDistanceCalculator)}
        };

    [Theory]
    [MemberData(nameof(Factories))]
    public void FactoryReturnsCorrectType(DistanceCalculators calculator, Type expectedType)
    {
        var factory = new DistanceCalculatorFactory();
        var distanceCalculator = factory.GetDistanceCalculator(calculator);
        Assert.IsType(expectedType, distanceCalculator);
    }

    [Fact]
    public void FactoryThrowsArgumentExceptionIfEnumIsOutOfRange()
    {
        var factory = new DistanceCalculatorFactory();
        Assert.Throws<ArgumentOutOfRangeException>(() => factory.GetDistanceCalculator((DistanceCalculators) int.MaxValue));
    }
}