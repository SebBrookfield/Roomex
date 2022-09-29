using Roomex.Distance.Api.Calculators;
using Roomex.Distance.Api.Enums;

namespace Roomex.Distance.Api.Factories;

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