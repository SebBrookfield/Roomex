using Roomex.Distance.Api.ExtensionMethods;
using Roomex.Distance.Api.Models;

namespace Roomex.Distance.Api.Calculators;

public class SphericalLawOfCosineDistanceCalculator : ICoordinateDistanceCalculator
{
    public double CalculateDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB, double radius)
    {
        var a = (90 - coordinateB.Latitude).ToRadians();
        var b = (90 - coordinateA.Latitude).ToRadians();
        var phi = (coordinateA.Longitude - coordinateB.Longitude).ToRadians();
        var cosP = Math.Cos(a) * Math.Cos(b) + Math.Sin(a) * Math.Sin(b) * Math.Cos(phi);
        return Math.Acos(cosP) * radius;
    }
}