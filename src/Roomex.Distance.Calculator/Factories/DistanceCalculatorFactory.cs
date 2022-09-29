using Roomex.Distance.Calculator.Calculators;
using Roomex.Distance.Calculator.Enums;

namespace Roomex.Distance.Calculator.Factories;

public interface IDistanceCalculatorFactory
{
    ICoordinateDistanceCalculator GetDistanceCalculator(DistanceCalculators calculator);
}

public class DistanceCalculatorFactory : IDistanceCalculatorFactory
{
    public ICoordinateDistanceCalculator GetDistanceCalculator(DistanceCalculators calculator)
    {
        return calculator switch
        {
            DistanceCalculators.PolarCoordinateFlatEarth => new PolarCoordinateFlatEarthCalculator(),
            DistanceCalculators.SphericalLawOfCosine => new SphericalLawOfCosineDistanceCalculator(),
            DistanceCalculators.VincentyInverse => new VincentyInverseDistanceCalculator(),
            _ => throw new ArgumentOutOfRangeException(nameof(calculator), calculator, null)
        };
    }
}