using Roomex.Distance.Api.Models;

namespace Roomex.Distance.Api.Calculators;

public interface ICoordinateDistanceCalculator
{
    double CalculateDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB, double radius);
}