using Roomex.Distance.Calculator.Converters;
using Roomex.Distance.Calculator.ExtensionMethods;
using Roomex.Distance.Calculator.Models;

namespace Roomex.Distance.Calculator.Calculators;

public class SphericalLawOfCosineDistanceCalculator : ICoordinateDistanceCalculator
{
    public double CalculateDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB, IMetreConverter? converter = null)
    {
        const double radius = 6371008.7714d;
        var a = (90 - coordinateB.Latitude).ToRadians();
        var b = (90 - coordinateA.Latitude).ToRadians();
        var phi = (coordinateA.Longitude - coordinateB.Longitude).ToRadians();
        var cosP = Math.Cos(a) * Math.Cos(b) + Math.Sin(a) * Math.Sin(b) * Math.Cos(phi);
        var distance = Math.Acos(cosP) * radius;
        return converter?.ConvertFromMetres(distance) ?? distance;
    }
}