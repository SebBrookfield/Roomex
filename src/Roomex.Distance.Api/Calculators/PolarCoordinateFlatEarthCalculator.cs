using Roomex.Distance.Api.ExtensionMethods;
using Roomex.Distance.Api.Models;

namespace Roomex.Distance.Api.Calculators;

public class PolarCoordinateFlatEarthCalculator : ICoordinateDistanceCalculator
{
    public double CalculateDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB, double radius)
    {
        var a = (90 - coordinateB.Latitude).ToRadians();
        var b = (90 - coordinateA.Latitude).ToRadians();
        var phi = (coordinateA.Longitude - coordinateB.Longitude).ToRadians();
        var fe = Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * Math.Cos(phi);
        return radius * Math.Sqrt(fe);
    }
}